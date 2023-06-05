using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woooordle
{
    public partial class CustomGame : Form
    {
        public enum Case
        {
            Null = 0, Absent, Exist, Correct
        }

        public class KeyBoard
        {
            public Button button;
            public char key;
            public Case currentStatus;

            public KeyBoard(char ch)
            {
                if (ch == '\0') this.button = null;
                else this.button = new Button
                {
                    Font = new Font("Consolas", 12F, FontStyle.Bold),
                    Margin = new Padding(2, 2, 2, 2),
                    Name = $"{ch}Btn",
                    Size = new Size(26, 40),
                    TabStop = false,
                    Text = $"{ch}",
                    UseVisualStyleBackColor = true
                };
                this.key = ch;
                this.currentStatus = Case.Null;
            }

            public void UpdateStatus(Case other)
            {
                if (other > this.currentStatus) this.currentStatus = other;

                switch (this.currentStatus)
                {
                    case Case.Absent:
                        this.button.BackColor = Color.DarkGray;
                        break;

                    case Case.Exist:
                        this.button.BackColor = Color.LightYellow;
                        break;

                    case Case.Correct:
                        this.button.BackColor = Color.LightGreen;
                        break;

                    default:
                        break;
                }
            }
        }

        private int TRY_SIZE = 6;  // Row
        private int ANSWER_SIZE;  // Column
        private const int HASH_NUM = 0b10000000001110110;

        private int tryCount = 0;
        public Button[,] answerDisplayBtn;
        public KeyBoard[,] keyBoards = new KeyBoard[3, 10];
        public TableLayoutPanel answerPanel;

        public char[,] keyBoardChar = new char[,]
        {
            {'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P'},
            {'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', '\0' },
            {'Z', 'X', 'C', 'V', 'B', 'N', 'M', '\0', '\0', '\0' }
        };

        private string answer;
        private string currentInput = "";

        public bool isRunning = false;

        public CustomGame()
        {
            InitializeComponent();

            MessageBox.Show("Input your custom answer to textbox in the center, \nand press 'START' button.", "Notice");
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(this.answerInputTextBox.Text, @"^[A-Z]{1,9}$"))
            {
                MessageBox.Show("Your word is invalid!\n\n- Only consist A~Z letters.\n- Length should be 1 to 9.", "Input Error!");
                
                return;
            }

            MessageBox.Show("Your answer is now submitted!", "Notice");

            InitAfterInput();
        }

        private void InitAfterInput()
        {
            answer = answerInputTextBox.Text;
            inputTextBox.Text = inputTextBox.Text.Substring(0, answer.Length);
            ANSWER_SIZE = answer.Length;
            answerDisplayBtn = new Button[TRY_SIZE, ANSWER_SIZE];

            this.answerInputTextBox.Enabled = false;
            this.answerInputTextBox.Visible = false;

            this.startBtn.Enabled = false;
            this.startBtn.Visible = false;

            isRunning = true;

            this.answerPanel = new TableLayoutPanel
            {
                ColumnCount = ANSWER_SIZE,
                RowCount = TRY_SIZE,
                Location = new Point(262 - 28 * ANSWER_SIZE, 110),
                Size = new Size(54 * ANSWER_SIZE, 54 * TRY_SIZE),
                // Margin = new Padding(3, 4, 3, 4),
                Name = "answerPanel",
            };

            this.Controls.Add(this.answerPanel);

            for (int i = 0; i < ANSWER_SIZE; i++)
            {
                this.answerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / ANSWER_SIZE));
            }

            for (int i = 0; i < TRY_SIZE; i++)
            {
                this.answerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / TRY_SIZE));
            }

            for (int row = 0; row < TRY_SIZE; row++)
            {
                for (int col = 0; col < ANSWER_SIZE; col++)
                {
                    answerDisplayBtn[row, col] = new Button
                    {
                        Font = new Font("Consolas", 24F, FontStyle.Bold, GraphicsUnit.Point, 0),
                        Text = $"",
                        Size = new Size(50, 50),
                        AutoSize = true,
                        AutoSizeMode = AutoSizeMode.GrowOnly,
                        FlatStyle = FlatStyle.Flat,
                        FlatAppearance =
                        {
                            BorderColor = Color.Gray
                        },
                        TabStop = false
                    };

                    this.answerPanel.Controls.Add(answerDisplayBtn[row, col], col, row);
                }
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    keyBoards[row, col] = new KeyBoard(keyBoardChar[row, col]);

                    if (keyBoardChar[row, col] != '\0')
                    {
                        keyBoards[row, col].button.Click += new System.EventHandler(this.KeyBtn_Click);
                        this.keyBoardBtnPanel.Controls.Add(keyBoards[row, col].button, col, row);
                    }
                }
            }

            focusCtrl.BringToFront();
            focusCtrl.Focus();

            this.AcceptButton = enterBtn;
            this.KeyPreview = true;
        }

        private void NormalGuideBtn_Click(object sender, EventArgs e)
        {
            var frm = new NormalGuide
            {
                Location = this.Location,
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };
            frm.FormClosing += delegate
            {
                this.Enabled = true;
                this.Focus();
            };
            this.Enabled = false;
            frm.Show();
        }

        private void KeyBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                InsertKey((Keys)(sender as Button).Text[0]);
            }
            this.Focus();
        }

        private void InsertKey(Keys key)
        {
            if (currentInput.Length >= ANSWER_SIZE)
            {
                return;
            }

            currentInput += key;
            UpdateDisplayInput();
        }

        private void EraseKey()
        {
            if (currentInput.Length <= 0)
            {
                return;
            }

            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplayInput();
        }

        private void CheckAnswer()
        {
            if (currentInput.Length < ANSWER_SIZE)
            {
                MessageBox.Show("Your input is too short!", "Input Error!");
                return;
            }

            Case[] cases = Enumerable.Repeat(Case.Null, ANSWER_SIZE).ToArray();

            var copyInput = currentInput.ToCharArray();
            var copyAnswer = answer.ToCharArray();

            // First loop - check correct
            for (int i = 0; i < ANSWER_SIZE; i++)
            {
                if (copyInput[i] == copyAnswer[i])
                {
                    cases[i] = Case.Correct;

                    copyInput[i] = '\0';
                    copyAnswer[i] = '\0';
                }
            }

            // Second loop - check exist, or not
            for (int i = 0; i < ANSWER_SIZE; i++)
            {
                if (cases[i] == Case.Correct || copyInput[i] == '\0') continue;

                for (int j = 0; j < ANSWER_SIZE; j++)
                {
                    if (copyInput[i] == copyAnswer[j])
                    {
                        cases[i] = Case.Exist;

                        copyInput[i] = '\0';
                        copyAnswer[j] = '\0';

                        break;
                    }

                    if (j == ANSWER_SIZE - 1)
                    {
                        copyInput[i] = '\0';
                        cases[i] = Case.Absent;
                        break;
                    }
                }
            }

            UpdateKeyBoardColor(currentInput.ToCharArray(), cases);
            UpdateDisplayColor(cases);

            currentInput = "";
            tryCount++;

            // correct -> finish
            if (Array.FindAll(cases, (x => x == Case.Correct)).Length == ANSWER_SIZE)
            {
                isRunning = false;
                MessageBox.Show($"You're correct!\n" +
                    $"You got answer in {tryCount} guess(s).", "You Won!");

                return;
            }

            if (tryCount == TRY_SIZE)
            {
                isRunning = false;
                MessageBox.Show($"You didn't get the answer!\n" +
                    $"The answer is: {answer}");

                inputTextBox.Text = answer;
                return;
            }

            UpdateDisplayInput();

            this.Focus();
        }

        private void UpdateKeyBoardColor(char[] input, Case[] cases)
        {
            for (int i = 0; i < cases.Length; i++)
            {
                int idx = Array.IndexOf(keyBoardChar.Cast<char>().ToArray(), input[i]);

                int row = idx / keyBoardChar.GetLength(1);
                int col = idx % keyBoardChar.GetLength(1);

                keyBoards[row, col].UpdateStatus(cases[i]);
            }
        }

        private void UpdateDisplayColor(Case[] cases)
        {

            for (int i = 0; i < cases.Length; i++)
            {
                switch (cases[i])
                {
                    case Case.Absent:
                        answerDisplayBtn[tryCount, i].BackColor = Color.DarkGray;
                        break;

                    case Case.Exist:
                        answerDisplayBtn[tryCount, i].BackColor = Color.LightYellow;
                        break;

                    case Case.Correct:
                        answerDisplayBtn[tryCount, i].BackColor = Color.LightGreen;

                        var tmp = inputTextBox.Text.ToCharArray();
                        tmp[i] = answer[i];
                        inputTextBox.Text = new string(tmp);
                        break;

                    default:
                        break;
                }
            }
        }

        private void UpdateDisplayInput()
        {
            for (int i = 0; i < currentInput.Length; i++)
            {
                answerDisplayBtn[tryCount, i].Text = currentInput[i].ToString();
            }

            for (int i = currentInput.Length; i < answer.Length; i++)
            {
                answerDisplayBtn[tryCount, i].Text = "";
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                EraseKey();
            }

            this.Focus();
        }

        private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                CheckAnswer();
            }

            this.Select();
        }

        private void Reset_Focus(object sender, EventArgs e)
        {
            if (isRunning)
            {
                focusCtrl.BringToFront();
                focusCtrl.Focus();
            }
        }

        private void FocusCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (isRunning)
            {

                if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    InsertKey(e.KeyCode);
                }

                if (e.KeyCode == Keys.Back)
                {
                    EraseKey();
                }

                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    CheckAnswer();
                }
            }

            if (e.KeyData.GetHashCode() == HASH_NUM)
            {
                MessageBox.Show(
                    $"The Answer is {answer}!",
                    "Master Key: Answer"
                    );
            }
        }

        private void FocusCtrl_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                EnterBtn_Click(sender, e);
            }
        }

        private void BackTitleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnswerInputTextBox_Click(object sender, EventArgs e)
        {
            this.answerInputTextBox.Select(answerInputTextBox.Text.Length, 0);
        }
    }
}
