
namespace Woooordle
{
    partial class NormalGuide
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NormalGuide));
            this.guidePicture = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.guidePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // guidePicture
            // 
            this.guidePicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.guidePicture.Image = global::Woooordle.Properties.Resources.normalGuide;
            this.guidePicture.InitialImage = global::Woooordle.Properties.Resources.normalGuide;
            this.guidePicture.Location = new System.Drawing.Point(17, 17);
            this.guidePicture.Name = "guidePicture";
            this.guidePicture.Size = new System.Drawing.Size(400, 400);
            this.guidePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guidePicture.TabIndex = 0;
            this.guidePicture.TabStop = false;
            this.guidePicture.WaitOnLoad = true;
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.closeBtn.Font = new System.Drawing.Font("굴림", 11F, System.Drawing.FontStyle.Bold);
            this.closeBtn.Location = new System.Drawing.Point(174, 426);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 37);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "OK";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // NormalGuide
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 477);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.guidePicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NormalGuide";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "How to Play?";
            ((System.ComponentModel.ISupportInitialize)(this.guidePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox guidePicture;
        private System.Windows.Forms.Button closeBtn;
    }
}