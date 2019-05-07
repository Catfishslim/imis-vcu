namespace pyscheImagerUi
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.title = new System.Windows.Forms.Label();
            this.cmbLabel = new System.Windows.Forms.Label();
            this.cmb_cameras = new System.Windows.Forms.ComboBox();
            this.beginButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sessionLabel = new System.Windows.Forms.Label();
            this.catalogBox = new System.Windows.Forms.TextBox();
            this.catalogBoxLabel = new System.Windows.Forms.Label();
            this.pathButton = new System.Windows.Forms.Button();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(3, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(785, 59);
            this.title.TabIndex = 0;
            this.title.Text = "VCU Meteorite Imaging System";
            // 
            // cmbLabel
            // 
            this.cmbLabel.AutoSize = true;
            this.cmbLabel.Location = new System.Drawing.Point(76, 158);
            this.cmbLabel.Name = "cmbLabel";
            this.cmbLabel.Size = new System.Drawing.Size(43, 13);
            this.cmbLabel.TabIndex = 1;
            this.cmbLabel.Text = "Camera";
            // 
            // cmb_cameras
            // 
            this.cmb_cameras.FormattingEnabled = true;
            this.cmb_cameras.Location = new System.Drawing.Point(79, 174);
            this.cmb_cameras.Name = "cmb_cameras";
            this.cmb_cameras.Size = new System.Drawing.Size(121, 21);
            this.cmb_cameras.TabIndex = 2;
            // 
            // beginButton
            // 
            this.beginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.beginButton.Location = new System.Drawing.Point(301, 344);
            this.beginButton.Name = "beginButton";
            this.beginButton.Size = new System.Drawing.Size(177, 57);
            this.beginButton.TabIndex = 3;
            this.beginButton.Text = "Begin Session";
            this.beginButton.UseVisualStyleBackColor = true;
            this.beginButton.Click += new System.EventHandler(this.beginButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(541, 174);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "Smithsonian";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // sessionLabel
            // 
            this.sessionLabel.AutoSize = true;
            this.sessionLabel.Location = new System.Drawing.Point(538, 158);
            this.sessionLabel.Name = "sessionLabel";
            this.sessionLabel.Size = new System.Drawing.Size(53, 13);
            this.sessionLabel.TabIndex = 5;
            this.sessionLabel.Text = "Collection";
            // 
            // catalogBox
            // 
            this.catalogBox.Location = new System.Drawing.Point(541, 223);
            this.catalogBox.Name = "catalogBox";
            this.catalogBox.Size = new System.Drawing.Size(100, 20);
            this.catalogBox.TabIndex = 6;
            this.catalogBox.Text = "1";
            this.catalogBox.TextChanged += new System.EventHandler(this.catalogBox_TextChanged);
            // 
            // catalogBoxLabel
            // 
            this.catalogBoxLabel.AutoSize = true;
            this.catalogBoxLabel.Location = new System.Drawing.Point(538, 207);
            this.catalogBoxLabel.Name = "catalogBoxLabel";
            this.catalogBoxLabel.Size = new System.Drawing.Size(82, 13);
            this.catalogBoxLabel.TabIndex = 7;
            this.catalogBoxLabel.Text = "Sample Number";
            // 
            // pathButton
            // 
            this.pathButton.Location = new System.Drawing.Point(185, 221);
            this.pathButton.Name = "pathButton";
            this.pathButton.Size = new System.Drawing.Size(50, 23);
            this.pathButton.TabIndex = 8;
            this.pathButton.Text = "Browse";
            this.pathButton.UseVisualStyleBackColor = true;
            this.pathButton.Click += new System.EventHandler(this.pathButton_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(79, 223);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(100, 20);
            this.pathBox.TabIndex = 9;
            this.pathBox.TextChanged += new System.EventHandler(this.pathBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Folder";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::pyscheImagerUi.Properties.Resources.Capture;
            this.pictureBox1.Location = new System.Drawing.Point(301, 94);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.pathButton);
            this.Controls.Add(this.catalogBoxLabel);
            this.Controls.Add(this.catalogBox);
            this.Controls.Add(this.sessionLabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.beginButton);
            this.Controls.Add(this.cmb_cameras);
            this.Controls.Add(this.cmbLabel);
            this.Controls.Add(this.title);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Imaging System";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label cmbLabel;
        private System.Windows.Forms.ComboBox cmb_cameras;
        private System.Windows.Forms.Button beginButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label sessionLabel;
        private System.Windows.Forms.TextBox catalogBox;
        private System.Windows.Forms.Label catalogBoxLabel;
        private System.Windows.Forms.Button pathButton;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

