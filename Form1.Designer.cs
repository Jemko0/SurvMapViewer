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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ZoomUp
            // 
            this.ZoomUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ZoomUp.Location = new System.Drawing.Point(851, 45);
            this.ZoomUp.Name = "ZoomUp";
            this.ZoomUp.Size = new System.Drawing.Size(261, 42);
            this.ZoomUp.TabIndex = 1;
            this.ZoomUp.Text = "Zoom [+]";
            this.ZoomUp.UseVisualStyleBackColor = true;
            this.ZoomUp.Click += new System.EventHandler(this.ZoomUp_Click);
            // 
            // ZoomDown
            // 
            this.ZoomDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.ZoomDown.Location = new System.Drawing.Point(851, 93);
            this.ZoomDown.Name = "ZoomDown";
            this.ZoomDown.Size = new System.Drawing.Size(261, 42);
            this.ZoomDown.TabIndex = 2;
            this.ZoomDown.Text = "Zoom [-]";
            this.ZoomDown.UseVisualStyleBackColor = true;
            this.ZoomDown.Click += new System.EventHandler(this.ZoomDown_Click);
            // 
            // bgThread
            // 
            this.bgThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgThread_DoWork);
            this.bgThread.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgThread_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 859);
            this.Controls.Add(this.ZoomDown);
            this.Controls.Add(this.ZoomUp);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Surv Map Viewer (highly intelligent)";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ZoomUp;
        private System.Windows.Forms.Button ZoomDown;
        public System.ComponentModel.BackgroundWorker bgThread;
    }
}

