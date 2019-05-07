using CameraControl.Devices;
using CameraControl.Devices.Classes;
using CameraControl.Devices.Others;
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
using Timer = System.Windows.Forms.Timer;

namespace pyscheImagerUi
{
    public partial class FrontSideForm : Form
    {
        public ICameraDevice CameraDevice { get; set; }
        private Timer _liveViewTimer = new Timer();
        public bool frontSide = true;
        Form1 parentForm;

        public void LoadPreview(string location)
        {
            try
            {
                confirmControl1.SetImgLocation(location);
            }
            catch { throw; }
        }

       

        public FrontSideForm(Form1 parentForm, ICameraDevice cameraDevice)
        {
            _liveViewTimer.Interval = 1000 / 15;
            _liveViewTimer.Stop();
            _liveViewTimer.Tick += _liveViewTimer_Tick;
            CameraDevice = cameraDevice;
            CameraDevice.CameraDisconnected += CameraDevice_CameraDisconnected;
            InitializeComponent();
            this.parentForm = parentForm;
            confirmControl1.ConfirmControlInit(this);
            staticTextBox.SelectedText = "";
            //experimental
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            frontsideMode();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        public void backsideMode()
        {
            this.Text = "Back of Sample";
            this.dynamicTextBox.Text = "Flip the sample over and close the door";
            dynamicTextBox.SelectedText = "";
            frontSide = false;
        }

        public void frontsideMode()
        {
            this.Text = "Front of Sample";
            this.dynamicTextBox.Text = "Using gloves, place the sample in the light box and close the door";
            dynamicTextBox.SelectedText = "";
            frontSide = true;
        }

        void CameraDevice_CameraDisconnected(object sender, DisconnectCameraEventArgs eventArgs)
        {
            MethodInvoker method = delegate
            {
                _liveViewTimer.Stop();
                Thread.Sleep(100);
                Close();
            };
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();
        }

        void _liveViewTimer_Tick(object sender, EventArgs e)
        {
            LiveViewData liveViewData = null;
            try
            {
                liveViewData = CameraDevice.GetLiveViewImage();
            }
            catch (Exception)
            {
                return;
            }

            if (liveViewData == null || liveViewData.ImageData == null)
            {
                return;
            }
            try
            {
                pictureBox1.Image = new Bitmap(new MemoryStream(liveViewData.ImageData,
                                                                liveViewData.ImageDataPosition,
                                                                liveViewData.ImageData.Length -
                                                                liveViewData.ImageDataPosition));
            }
            catch (Exception)
            {

            }
        }

      

        private void StartLiveView()
        {
            bool retry;
            do
            {
                retry = false;
                try
                {
                    CameraDevice.StartLiveView();
                    CameraDevice.AutoFocus();
                }
                catch (DeviceException exception)
                {
                    if (exception.ErrorCode == ErrorCodes.MTP_Device_Busy || exception.ErrorCode == ErrorCodes.ERROR_BUSY)
                    {
                        Thread.Sleep(100);
                        retry = true;
                    }
                    else
                    {
                        MessageBox.Show("Error occurred :" + exception.Message);
                    }
                }

            } while (retry);
            MethodInvoker method = () => _liveViewTimer.Start();
            if (InvokeRequired)
                BeginInvoke(method);
            else
                method.Invoke();

        }


        private void StopLiveView()
        {
            bool retry;
            do
            {
                retry = false;
                try
                {
                    _liveViewTimer.Stop();
                    // wait for last get live view image
                    Thread.Sleep(500);
                    CameraDevice.StopLiveView();
                }
                catch (DeviceException exception)
                {
                    if (exception.ErrorCode == ErrorCodes.MTP_Device_Busy || exception.ErrorCode == ErrorCodes.ERROR_BUSY)
                    {
                        Thread.Sleep(100);
                        retry = true;
                    }
                    else
                    {
                        MessageBox.Show("Error occurred :" + exception.Message);
                    }
                }

            } while (retry);
        }

        private void LiveViewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetLiveViewStatusAsync(false);
        }

        public void SetLiveViewStatusAsync(bool start)
        {
            if (start)
            {
                new Thread(StartLiveView).Start();
            }
            else
            {
                new Thread(StopLiveView).Start();
            }

        }

        private void FrontSideForm_Load(object sender, EventArgs e)
        {

            confirmControl1.Hide();
            SetLiveViewStatusAsync(true);
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            Capture();
            confirmControl1.Show();
        }

        private void Capture()
        {
            bool retry;

           do
            {
                retry = false;
                try
                {
                    var liveViewData = CameraDevice.GetLiveViewImage();
                    MemoryStream stream = new MemoryStream(liveViewData.ImageData, liveViewData.ImageDataPosition,
                                            liveViewData.ImageData.Length - liveViewData.ImageDataPosition);

                    parentForm.DeviceManager.OnPhotoCaptured(null, new PhotoCapturedEventArgs()
                    {
                        CameraDevice = new FileTransferDevice(),
                        FileName = "file.jpg",
                        Handle = stream.ToArray()
                    });
                }
                catch (DeviceException exception)
                {
                    // if device is busy retry after 100 miliseconds
                    if (exception.ErrorCode == ErrorCodes.MTP_Device_Busy ||
                        exception.ErrorCode == ErrorCodes.ERROR_BUSY)
                    {
                      
                        Thread.Sleep(100);
                        retry = true;
                    }
                    else
                    {
                        MessageBox.Show("Error occurred :" + exception.Message);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred :" + ex.Message);
                }

            } while (retry);
        }

        private void staticTextbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
