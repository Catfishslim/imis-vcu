using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CameraControl.Devices;
using CameraControl.Devices.Classes;

namespace pyscheImagerUi
{
    public partial class Form1 : Form
    {
        public CameraDeviceManager DeviceManager { get; set; }
        public string FolderForPhotos { get; set; }
        public string fileName;
        FrontSideForm frontSide;
        public string catalog = "foo";

        public Form1()
        {
            InitializeComponent();
            DeviceManager = new CameraDeviceManager();
            DeviceManager.CameraSelected += DeviceManager_CameraSelected;
            DeviceManager.CameraConnected += DeviceManager_CameraConnected;
            DeviceManager.PhotoCaptured += DeviceManager_PhotoCaptured;
            DeviceManager.CameraDisconnected += DeviceManager_CameraDisconnected;
            FolderForPhotos = textBox1.Text + DateTime.Today.ToString("ddMMyyyy");
            FolderForPhotos = Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), FolderForPhotos);
            pathBox.Text = FolderForPhotos;
            pathBox.Select(pathBox.Text.Length, 0);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void RefreshDisplay()
        {
            MethodInvoker method = delegate
            {
                cmb_cameras.BeginUpdate();
                cmb_cameras.Items.Clear();
                foreach (ICameraDevice cameraDevice in DeviceManager.ConnectedDevices)
                {
                    cmb_cameras.Items.Add(cameraDevice);
                }
                cmb_cameras.DisplayMember = "DeviceName";
                cmb_cameras.SelectedItem = DeviceManager.SelectedCameraDevice;
                // check if camera support live view
                cmb_cameras.EndUpdate();
            };

            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        
        private void PhotoCaptured(object o)
        {
            PhotoCapturedEventArgs eventArgs = o as PhotoCapturedEventArgs;
            if (eventArgs == null)
                return;
            try
            {
                
                if (frontSide.frontSide)
                {
                    fileName = Path.Combine(FolderForPhotos, catalog + "front"+  Path.GetExtension(eventArgs.FileName));
                }
                else
                {
                    fileName = Path.Combine(FolderForPhotos, catalog + "back"+  Path.GetExtension(eventArgs.FileName));
                }
                // if file exist try to generate a new filename
                if (File.Exists(fileName))
                    fileName =
                      StaticHelper.GetUniqueFilename(
                        Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_", 0,
                        Path.GetExtension(fileName));

                // check the folder of filename, if not found create it
                if (!Directory.Exists(Path.GetDirectoryName(fileName)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(fileName));
                }
                eventArgs.CameraDevice.TransferFile(eventArgs.Handle, fileName);
                eventArgs.CameraDevice.IsBusy = false;
                UpdateImage();
            }
            catch (Exception exception)
            {
                eventArgs.CameraDevice.IsBusy = false;
                MessageBox.Show("Error download photo from camera :\n" + exception.Message);
            }
        }

        void UpdateImage()
        {
            MethodInvoker method = delegate
            {
                frontSide.LoadPreview(fileName);
            };
            frontSide.Invoke(method);
            
        }

        void DeviceManager_CameraDisconnected(ICameraDevice cameraDevice)
        {
            RefreshDisplay();
        }

        void DeviceManager_PhotoCaptured(object sender, PhotoCapturedEventArgs eventArgs)
        {
            Thread thread = new Thread(PhotoCaptured);
            thread.Start(eventArgs);
        }

        void DeviceManager_CameraConnected(ICameraDevice cameraDevice)
        {
            RefreshDisplay();
        }

        void DeviceManager_CameraSelected(ICameraDevice oldcameraDevice, ICameraDevice newcameraDevice)
        {
            MethodInvoker method = delegate
            {
                beginButton.Enabled = newcameraDevice.GetCapability(CapabilityEnum.LiveView);
            };
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        private void beginButton_Click(object sender, EventArgs e)
        {
            frontSide = new FrontSideForm(this, DeviceManager.SelectedCameraDevice);
            frontSide.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DeviceManager.ConnectToCamera();
            RefreshDisplay();
        }

        private void cmb_cameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            DeviceManager.SelectedCameraDevice = (ICameraDevice)cmb_cameras.SelectedItem;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FolderForPhotos = textBox1.Text + DateTime.Today.ToString("ddMMyyyy");
        }

        private void catalogBox_TextChanged(object sender, EventArgs e)
        {
            catalog = catalogBox.Text;
        }

        private void pathButton_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.SelectedPath = FolderForPhotos;
            var result = fbd.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                
                pathBox.Text = fbd.SelectedPath;
                pathBox.Select(pathBox.Text.Length, 0);
                FolderForPhotos = fbd.SelectedPath +"\\" +  textBox1.Text + DateTime.Today.ToString("ddMMyyyy"); ;
            }

        }

        private void pathBox_TextChanged(object sender, EventArgs e)
        {
            FolderForPhotos = pathBox.Text + "\\" + textBox1.Text + DateTime.Today.ToString("ddMMyyyy"); ;
        }
    }
}
