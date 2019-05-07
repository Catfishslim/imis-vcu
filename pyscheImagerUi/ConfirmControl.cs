using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pyscheImagerUi
{
    public partial class ConfirmControl : UserControl
    {
        FrontSideForm parent;
        Image img;

        public ConfirmControl(FrontSideForm form)
        {
            InitializeComponent();
            parent = form;
        }
        
        public ConfirmControl()
        {
            InitializeComponent();
        }

        public void ConfirmControlInit(FrontSideForm form)
        {
            parent = form;
        }

        public void SetImgLocation(string location)
        {
            pictureBox1.WaitOnLoad = false;
         
            try
            {

                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox1.Visible = true;
                pictureBox1.LoadAsync(location);
                pictureBox1.Refresh();
            }
            catch { throw; }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void retryButton_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(pictureBox1.ImageLocation);
            }
            catch { }
            this.Hide();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(parent.frontSide)
            {
                parent.backsideMode();
            }
            else
            {
                parent.Close();
            }
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
        }

        private void ConfirmControl_VisibleChanged(object sender, EventArgs e)
        {

            if (this.Visible)
            {
               // parent.SetLiveViewStatusAsync(false);
            }
            else
            {
                try
                {
                    parent.SetLiveViewStatusAsync(true);
                }
                catch { }
            }
        }
    }
}
