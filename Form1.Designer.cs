namespace SurvMapViewer
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ZoomUp = new System.Windows.Forms.Button();
            this.ZoomDown = new System.Windows.Forms.Button();
            this.bgThread = new System.ComponentModel.BackgroundWorker();
            this.xposLabel = new System.Windows.Forms.Label();
            this.yposLabel = new System.Windows.Forms.Label();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.camspdchangerthing = new System.Windows.Forms.TrackBar();
            this.rndlabel1 = new System.Windows.Forms.Label();
            this.movup = new System.Windows.Forms.Button();
            this.movdown = new System.Windows.Forms.Button();
            this.movL = new System.Windows.Forms.Button();
            this.movR = new System.Windows.Forms.Button();
            this.wseedbox = new System.Windows.Forms.TextBox();
            this.applyseed = new System.Windows.Forms.Button();
            this.MousePosLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.camspdchangerthing)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(26, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(783, 800);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ZoomUp
            // 
            this.ZoomUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomUp.Location = new System.Drawing.Point(869, 485);
            this.ZoomUp.Name = "ZoomUp";
            this.ZoomUp.Size = new System.Drawing.Size(261, 42);
            this.ZoomUp.TabIndex = 1;
            this.ZoomUp.Text = "Zoom IN";
            this.ZoomUp.UseVisualStyleBackColor = true;
            this.ZoomUp.Click += new System.EventHandler(this.ZoomUp_Click);
            // 
            // ZoomDown
            // 
            this.ZoomDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ZoomDown.Location = new System.Drawing.Point(869, 533);
            this.ZoomDown.Name = "ZoomDown";
            this.ZoomDown.Size = new System.Drawing.Size(261, 42);
            this.ZoomDown.TabIndex = 2;
            this.ZoomDown.Text = "Zoom OUT";
            this.ZoomDown.UseVisualStyleBackColor = true;
            this.ZoomDown.Click += new System.EventHandler(this.ZoomDown_Click);
            // 
            // bgThread
            // 
            this.bgThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgThread_DoWork);
            this.bgThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgThread_RunWorkerCompleted);
            // 
            // xposLabel
            // 
            this.xposLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xposLabel.AutoSize = true;
            this.xposLabel.Location = new System.Drawing.Point(865, 170);
            this.xposLabel.Name = "xposLabel";
            this.xposLabel.Size = new System.Drawing.Size(53, 20);
            this.xposLabel.TabIndex = 3;
            this.xposLabel.Text = "XPOS";
            this.xposLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yposLabel
            // 
            this.yposLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yposLabel.AutoSize = true;
            this.yposLabel.Location = new System.Drawing.Point(865, 139);
            this.yposLabel.Name = "yposLabel";
            this.yposLabel.Size = new System.Drawing.Size(53, 20);
            this.yposLabel.TabIndex = 4;
            this.yposLabel.Text = "YPOS";
            this.yposLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // zoomLabel
            // 
            this.zoomLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(865, 200);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(80, 20);
            this.zoomLabel.TabIndex = 5;
            this.zoomLabel.Text = "CurrZoom";
            this.zoomLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // camspdchangerthing
            // 
            this.camspdchangerthing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.camspdchangerthing.Location = new System.Drawing.Point(833, 288);
            this.camspdchangerthing.Maximum = 100;
            this.camspdchangerthing.Minimum = 1;
            this.camspdchangerthing.Name = "camspdchangerthing";
            this.camspdchangerthing.Size = new System.Drawing.Size(314, 69);
            this.camspdchangerthing.TabIndex = 6;
            this.camspdchangerthing.Value = 1;
            this.camspdchangerthing.Scroll += new System.EventHandler(this.camspdchangerthing_Scroll);
            // 
            // rndlabel1
            // 
            this.rndlabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rndlabel1.AutoSize = true;
            this.rndlabel1.Location = new System.Drawing.Point(942, 265);
            this.rndlabel1.Name = "rndlabel1";
            this.rndlabel1.Size = new System.Drawing.Size(116, 20);
            this.rndlabel1.TabIndex = 7;
            this.rndlabel1.Text = "Camera Speed";
            this.rndlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // movup
            // 
            this.movup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movup.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.movup.Location = new System.Drawing.Point(988, 365);
            this.movup.Name = "movup";
            this.movup.Size = new System.Drawing.Size(32, 42);
            this.movup.TabIndex = 8;
            this.movup.Text = "^";
            this.movup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.movup.UseVisualStyleBackColor = true;
            this.movup.Click += new System.EventHandler(this.movup_Click);
            // 
            // movdown
            // 
            this.movdown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.movdown.Location = new System.Drawing.Point(988, 413);
            this.movdown.Name = "movdown";
            this.movdown.Size = new System.Drawing.Size(32, 42);
            this.movdown.TabIndex = 9;
            this.movdown.Text = "v";
            this.movdown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.movdown.UseVisualStyleBackColor = true;
            this.movdown.Click += new System.EventHandler(this.movdown_Click);
            // 
            // movL
            // 
            this.movL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movL.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.movL.Location = new System.Drawing.Point(949, 413);
            this.movL.Name = "movL";
            this.movL.Size = new System.Drawing.Size(32, 42);
            this.movL.TabIndex = 10;
            this.movL.Text = "<";
            this.movL.UseVisualStyleBackColor = true;
            this.movL.Click += new System.EventHandler(this.movL_Click);
            // 
            // movR
            // 
            this.movR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.movR.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.movR.Location = new System.Drawing.Point(1026, 413);
            this.movR.Name = "movR";
            this.movR.Size = new System.Drawing.Size(32, 42);
            this.movR.TabIndex = 11;
            this.movR.Text = ">";
            this.movR.UseVisualStyleBackColor = true;
            this.movR.Click += new System.EventHandler(this.movR_Click);
            // 
            // wseedbox
            // 
            this.wseedbox.Location = new System.Drawing.Point(850, 40);
            this.wseedbox.Name = "wseedbox";
            this.wseedbox.Size = new System.Drawing.Size(297, 26);
            this.wseedbox.TabIndex = 12;
            this.wseedbox.Text = "SEED";
            // 
            // applyseed
            // 
            this.applyseed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.applyseed.Location = new System.Drawing.Point(850, 72);
            this.applyseed.Name = "applyseed";
            this.applyseed.Size = new System.Drawing.Size(297, 39);
            this.applyseed.TabIndex = 13;
            this.applyseed.Text = "Apply";
            this.applyseed.UseVisualStyleBackColor = true;
            this.applyseed.Click += new System.EventHandler(this.applyseed_Click);
            // 
            // MousePosLabel
            // 
            this.MousePosLabel.AutoSize = true;
            this.MousePosLabel.Location = new System.Drawing.Point(26, 827);
            this.MousePosLabel.Name = "MousePosLabel";
            this.MousePosLabel.Size = new System.Drawing.Size(135, 20);
            this.MousePosLabel.TabIndex = 14;
            this.MousePosLabel.Text = "MOUSE POS X Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 859);
            this.Controls.Add(this.MousePosLabel);
            this.Controls.Add(this.applyseed);
            this.Controls.Add(this.wseedbox);
            this.Controls.Add(this.movR);
            this.Controls.Add(this.movL);
            this.Controls.Add(this.movdown);
            this.Controls.Add(this.movup);
            this.Controls.Add(this.rndlabel1);
            this.Controls.Add(this.camspdchangerthing);
            this.Controls.Add(this.zoomLabel);
            this.Controls.Add(this.yposLabel);
            this.Controls.Add(this.xposLabel);
            this.Controls.Add(this.ZoomDown);
            this.Controls.Add(this.ZoomUp);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surv Map Viewer (highly intelligent)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.camspdchangerthing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ZoomUp;
        private System.Windows.Forms.Button ZoomDown;
        public System.ComponentModel.BackgroundWorker bgThread;
        private System.Windows.Forms.Label xposLabel;
        private System.Windows.Forms.Label yposLabel;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.TrackBar camspdchangerthing;
        private System.Windows.Forms.Label rndlabel1;
        private System.Windows.Forms.Button movup;
        private System.Windows.Forms.Button movdown;
        private System.Windows.Forms.Button movL;
        private System.Windows.Forms.Button movR;
        private System.Windows.Forms.TextBox wseedbox;
        private System.Windows.Forms.Button applyseed;
        private System.Windows.Forms.Label MousePosLabel;
    }
}

