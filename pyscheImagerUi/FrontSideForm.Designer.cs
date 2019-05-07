namespace pyscheImagerUi
{
    partial class FrontSideForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrontSideForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.staticTextBox = new System.Windows.Forms.TextBox();
            this.dynamicTextBox = new System.Windows.Forms.TextBox();
            this.confirmControl1 = new pyscheImagerUi.ConfirmControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(190, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(424, 316);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(316, 382);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(154, 37);
            this.captureButton.TabIndex = 1;
            this.captureButton.Text = "Capture";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // staticTextBox
            // 
            this.staticTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staticTextBox.Location = new System.Drawing.Point(629, 127);
            this.staticTextBox.Multiline = true;
            this.staticTextBox.Name = "staticTextBox";
            this.staticTextBox.ReadOnly = true;
            this.staticTextBox.Size = new System.Drawing.Size(148, 98);
            this.staticTextBox.TabIndex = 3;
            this.staticTextBox.Text = "Twisting the zoom lens, adjust the zoom to ensure the entire sample is in frame a" +
    "nd as large as possible";
            this.staticTextBox.TextChanged += new System.EventHandler(this.staticTextbox_TextChanged);
            // 
            // dynamicTextBox
            // 
            this.dynamicTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dynamicTextBox.Location = new System.Drawing.Point(10, 158);
            this.dynamicTextBox.Multiline = true;
            this.dynamicTextBox.Name = "dynamicTextBox";
            this.dynamicTextBox.ReadOnly = true;
            this.dynamicTextBox.Size = new System.Drawing.Size(174, 51);
            this.dynamicTextBox.TabIndex = 4;
            this.dynamicTextBox.Text = "Place the sample in the light box and close the door";
            // 
            // confirmControl1
            // 
            this.confirmControl1.Location = new System.Drawing.Point(0, 0);
            this.confirmControl1.Name = "confirmControl1";
            this.confirmControl1.Size = new System.Drawing.Size(800, 480);
            this.confirmControl1.TabIndex = 6;
            // 
            // FrontSideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.confirmControl1);
            this.Controls.Add(this.dynamicTextBox);
            this.Controls.Add(this.staticTextBox);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FrontSideForm";
            this.Text = "Front of Sample";
            this.Load += new System.EventHandler(this.FrontSideForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.TextBox staticTextBox;
        private System.Windows.Forms.TextBox dynamicTextBox;
        private ConfirmControl confirmControl1;
    }
}