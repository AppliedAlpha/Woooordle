
namespace Woooordle
{
    partial class CustomGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomGame));
            this.normalGuideBtn = new System.Windows.Forms.Button();
            this.backTitleBtn = new System.Windows.Forms.Button();
            this.keyBoardBtnPanel = new System.Windows.Forms.TableLayoutPanel();
            this.inputPanel = new System.Windows.Forms.Panel();
            this.enterBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.focusCtrl = new System.Windows.Forms.Button();
            this.startBtn = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.MaskedTextBox();
            this.answerInputTextBox = new System.Windows.Forms.MaskedTextBox();
            this.inputPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // normalGuideBtn
            // 
            this.normalGuideBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.normalGuideBtn.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalGuideBtn.Location = new System.Drawing.Point(504, 13);
            this.normalGuideBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.normalGuideBtn.Name = "normalGuideBtn";
            this.normalGuideBtn.Size = new System.Drawing.Size(66, 66);
            this.normalGuideBtn.TabIndex = 11;
            this.normalGuideBtn.TabStop = false;
            this.normalGuideBtn.Text = "How To";
            this.normalGuideBtn.UseVisualStyleBackColor = true;
            this.normalGuideBtn.Click += new System.EventHandler(this.NormalGuideBtn_Click);
            // 
            // backTitleBtn
            // 
            this.backTitleBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backTitleBtn.Font = new System.Drawing.Font("Consolas", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backTitleBtn.Location = new System.Drawing.Point(12, 13);
            this.backTitleBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.backTitleBtn.Name = "backTitleBtn";
            this.backTitleBtn.Size = new System.Drawing.Size(66, 66);
            this.backTitleBtn.TabIndex = 12;
            this.backTitleBtn.TabStop = false;
            this.backTitleBtn.Text = "←";
            this.backTitleBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.backTitleBtn.UseVisualStyleBackColor = true;
            this.backTitleBtn.Click += new System.EventHandler(this.BackTitleBtn_Click);
            // 
            // keyBoardBtnPanel
            // 
            this.keyBoardBtnPanel.ColumnCount = 10;
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.keyBoardBtnPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.keyBoardBtnPanel.Location = new System.Drawing.Point(3, 2);
            this.keyBoardBtnPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.keyBoardBtnPanel.Name = "keyBoardBtnPanel";
            this.keyBoardBtnPanel.RowCount = 3;
            this.keyBoardBtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.keyBoardBtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.keyBoardBtnPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.keyBoardBtnPanel.Size = new System.Drawing.Size(367, 168);
            this.keyBoardBtnPanel.TabIndex = 6;
            // 
            // inputPanel
            // 
            this.inputPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.inputPanel.Controls.Add(this.enterBtn);
            this.inputPanel.Controls.Add(this.deleteBtn);
            this.inputPanel.Controls.Add(this.keyBoardBtnPanel);
            this.inputPanel.Location = new System.Drawing.Point(55, 571);
            this.inputPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(475, 174);
            this.inputPanel.TabIndex = 13;
            // 
            // enterBtn
            // 
            this.enterBtn.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.enterBtn.Location = new System.Drawing.Point(379, 98);
            this.enterBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.enterBtn.Name = "enterBtn";
            this.enterBtn.Size = new System.Drawing.Size(85, 56);
            this.enterBtn.TabIndex = 9;
            this.enterBtn.TabStop = false;
            this.enterBtn.Text = "Enter";
            this.enterBtn.UseVisualStyleBackColor = true;
            this.enterBtn.Click += new System.EventHandler(this.EnterBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold);
            this.deleteBtn.Location = new System.Drawing.Point(379, 26);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(85, 56);
            this.deleteBtn.TabIndex = 8;
            this.deleteBtn.TabStop = false;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // focusCtrl
            // 
            this.focusCtrl.BackColor = System.Drawing.SystemColors.Control;
            this.focusCtrl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.focusCtrl.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.focusCtrl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusCtrl.Location = new System.Drawing.Point(12, 763);
            this.focusCtrl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.focusCtrl.Name = "focusCtrl";
            this.focusCtrl.Size = new System.Drawing.Size(1, 1);
            this.focusCtrl.TabIndex = 10;
            this.focusCtrl.UseVisualStyleBackColor = false;
            this.focusCtrl.Click += new System.EventHandler(this.FocusCtrl_Click);
            this.focusCtrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FocusCtrl_KeyDown);
            this.focusCtrl.Leave += new System.EventHandler(this.Reset_Focus);
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.startBtn.Location = new System.Drawing.Point(255, 355);
            this.startBtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(80, 56);
            this.startBtn.TabIndex = 10;
            this.startBtn.TabStop = false;
            this.startBtn.Text = "START";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.AsciiOnly = true;
            this.inputTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputTextBox.BeepOnError = true;
            this.inputTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            this.inputTextBox.Font = new System.Drawing.Font("Consolas", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.inputTextBox.Location = new System.Drawing.Point(90, 26);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.RejectInputOnFirstFailure = true;
            this.inputTextBox.Size = new System.Drawing.Size(400, 59);
            this.inputTextBox.TabIndex = 14;
            this.inputTextBox.Text = "_________";
            this.inputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // answerInputTextBox
            // 
            this.answerInputTextBox.Culture = new System.Globalization.CultureInfo("en-US");
            this.answerInputTextBox.Font = new System.Drawing.Font("Consolas", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answerInputTextBox.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Insert;
            this.answerInputTextBox.Location = new System.Drawing.Point(140, 274);
            this.answerInputTextBox.Mask = ">?????????";
            this.answerInputTextBox.Name = "answerInputTextBox";
            this.answerInputTextBox.RejectInputOnFirstFailure = true;
            this.answerInputTextBox.Size = new System.Drawing.Size(300, 63);
            this.answerInputTextBox.TabIndex = 15;
            this.answerInputTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.answerInputTextBox.Click += new System.EventHandler(this.AnswerInputTextBox_Click);
            // 
            // CustomGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 776);
            this.Controls.Add(this.answerInputTextBox);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.normalGuideBtn);
            this.Controls.Add(this.backTitleBtn);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.focusCtrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomGame";
            this.Text = "Woooordle";
            this.inputPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button normalGuideBtn;
        private System.Windows.Forms.Button backTitleBtn;
        private System.Windows.Forms.TableLayoutPanel keyBoardBtnPanel;
        private System.Windows.Forms.Panel inputPanel;
        private System.Windows.Forms.Button enterBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button focusCtrl;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.MaskedTextBox inputTextBox;
        private System.Windows.Forms.MaskedTextBox answerInputTextBox;
    }
}