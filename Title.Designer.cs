
namespace Woooordle
{
    partial class Title
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Title));
            this.startNormalBtn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.startCustomBtn = new System.Windows.Forms.Button();
            this.openFinderBtn = new System.Windows.Forms.Button();
            this.infoBtn = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // startNormalBtn
            // 
            this.startNormalBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startNormalBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startNormalBtn.Location = new System.Drawing.Point(10, 5);
            this.startNormalBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.startNormalBtn.Name = "startNormalBtn";
            this.startNormalBtn.Size = new System.Drawing.Size(181, 60);
            this.startNormalBtn.TabIndex = 0;
            this.startNormalBtn.Text = "Start Normal Game";
            this.startNormalBtn.UseVisualStyleBackColor = true;
            this.startNormalBtn.Click += new System.EventHandler(this.startNormalBtn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.startNormalBtn);
            this.flowLayoutPanel1.Controls.Add(this.startCustomBtn);
            this.flowLayoutPanel1.Controls.Add(this.openFinderBtn);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(250, 185);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 215);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // startCustomBtn
            // 
            this.startCustomBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startCustomBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startCustomBtn.Location = new System.Drawing.Point(10, 75);
            this.startCustomBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.startCustomBtn.Name = "startCustomBtn";
            this.startCustomBtn.Size = new System.Drawing.Size(181, 60);
            this.startCustomBtn.TabIndex = 1;
            this.startCustomBtn.Text = "Start Custom Game";
            this.startCustomBtn.UseVisualStyleBackColor = true;
            this.startCustomBtn.Click += new System.EventHandler(this.startCustomBtn_Click);
            // 
            // openFinderBtn
            // 
            this.openFinderBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFinderBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFinderBtn.Location = new System.Drawing.Point(10, 145);
            this.openFinderBtn.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.openFinderBtn.Name = "openFinderBtn";
            this.openFinderBtn.Size = new System.Drawing.Size(181, 60);
            this.openFinderBtn.TabIndex = 2;
            this.openFinderBtn.Text = "Open Finder";
            this.openFinderBtn.UseVisualStyleBackColor = true;
            this.openFinderBtn.Click += new System.EventHandler(this.openFinderBtn_Click);
            // 
            // infoBtn
            // 
            this.infoBtn.Location = new System.Drawing.Point(640, 370);
            this.infoBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.infoBtn.Name = "infoBtn";
            this.infoBtn.Size = new System.Drawing.Size(50, 50);
            this.infoBtn.TabIndex = 3;
            this.infoBtn.Text = "i";
            this.infoBtn.UseVisualStyleBackColor = true;
            this.infoBtn.Click += new System.EventHandler(this.infoBtn_Click);
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logo.BackgroundImage = global::Woooordle.Properties.Resources.WoooordleTitle;
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.logo.Location = new System.Drawing.Point(12, 30);
            this.logo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(678, 125);
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            this.logo.WaitOnLoad = true;
            // 
            // Title
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 432);
            this.Controls.Add(this.infoBtn);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.logo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Title";
            this.Text = "Woooordle";
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button startNormalBtn;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button startCustomBtn;
        private System.Windows.Forms.Button openFinderBtn;
        private System.Windows.Forms.Button infoBtn;
    }
}

