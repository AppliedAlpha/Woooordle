
namespace Woooordle
{
    partial class Finder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Finder));
            this.resultList = new System.Windows.Forms.ListBox();
            this.guidelbl = new System.Windows.Forms.Label();
            this.countlbl = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.TextBox();
            this.guidelbl2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resultList
            // 
            this.resultList.Font = new System.Drawing.Font("Consolas", 11F);
            this.resultList.FormattingEnabled = true;
            this.resultList.ItemHeight = 22;
            this.resultList.Location = new System.Drawing.Point(36, 134);
            this.resultList.Name = "resultList";
            this.resultList.Size = new System.Drawing.Size(361, 202);
            this.resultList.TabIndex = 0;
            // 
            // guidelbl
            // 
            this.guidelbl.AutoSize = true;
            this.guidelbl.Font = new System.Drawing.Font("Consolas", 13F);
            this.guidelbl.Location = new System.Drawing.Point(31, 16);
            this.guidelbl.Name = "guidelbl";
            this.guidelbl.Size = new System.Drawing.Size(384, 26);
            this.guidelbl.TabIndex = 2;
            this.guidelbl.Text = "Input letters (A-Z, *) to find.";
            // 
            // countlbl
            // 
            this.countlbl.AutoSize = true;
            this.countlbl.Font = new System.Drawing.Font("Consolas", 12F);
            this.countlbl.Location = new System.Drawing.Point(32, 346);
            this.countlbl.Name = "countlbl";
            this.countlbl.Size = new System.Drawing.Size(285, 23);
            this.countlbl.TabIndex = 3;
            this.countlbl.Text = "0 word(s) found in match.";
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Consolas", 14F);
            this.input.Location = new System.Drawing.Point(36, 85);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(361, 35);
            this.input.TabIndex = 4;
            this.input.TextChanged += new System.EventHandler(this.Input_TextChanged);
            // 
            // guidelbl2
            // 
            this.guidelbl2.AutoSize = true;
            this.guidelbl2.Font = new System.Drawing.Font("Consolas", 8F);
            this.guidelbl2.Location = new System.Drawing.Point(31, 52);
            this.guidelbl2.Name = "guidelbl2";
            this.guidelbl2.Size = new System.Drawing.Size(384, 17);
            this.guidelbl2.TabIndex = 5;
            this.guidelbl2.Text = "[* corresponds to a blank or any character(s).]";
            // 
            // Finder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 405);
            this.Controls.Add(this.guidelbl2);
            this.Controls.Add(this.input);
            this.Controls.Add(this.countlbl);
            this.Controls.Add(this.guidelbl);
            this.Controls.Add(this.resultList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Finder";
            this.Text = "Woooordle Finder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox resultList;
        private System.Windows.Forms.Label guidelbl;
        private System.Windows.Forms.Label countlbl;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Label guidelbl2;
    }
}