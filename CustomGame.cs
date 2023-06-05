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
    // Custom Game Class: Guessing custom user input
    public partial class CustomGame : Form
    {
        /// <summary>
        ///  Case is used to check status of the block.
        ///  It is determined when the user inputs the guess.
        ///  Default is Case.Null
        /// </summary>
        public enum Case
        {
            Null = 0, Absent, Exist, Correct
        }

        /// <summary>
        /// Keyboard class deals with buttons which are connected with keyboard buttons.
        /// Those buttons from this class can be used to substitute keyboard inputs.
        /// </summary>
        public class KeyBoard
        {
            public Button button;
            public char key;
            public Case currentStatus;

            /// <summary>
            /// Keyboard button class constructor.
            /// </summary>
            /// <param name="ch">The letter represents the button.</param>
            public KeyBoard(char ch)
            {
                // if character is null, button is also null.
                if (ch == '\0') this.button = null;

                // creating a keyboard button
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

                // setting the key and status of button.
                this.key = ch;
                this.currentStatus = Case.Null;
            }

            /// <summary>
            /// Setting the backcolor of the button by the case status.
            /// </summary>
            /// <param name="other">Updated case status.</param>
            public void UpdateStatus(Case other)
            {
                // updating current case status by priority
                if (other > this.currentStatus) this.currentStatus = other;

                // changing color of the button by the case status
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

        // defining variables
        private int TRY_SIZE = 6;  // Row
        private int ANSWER_SIZE;  // Column
        private const int HASH_NUM = 0b10000000001110110;  // used to get input of master key command

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

        // constructor
        public CustomGame()
        {
            // initializing components
            InitializeComponent();

            // notice player to input custom answer
            MessageBox.Show("Input your custom answer to textbox in the center, \nand press 'START' button.", "Notice");
        }

        /// <summary>
        /// Invoked when user inputs custom answer and clicks the button.
        /// After checking the input, game is started.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            // check input fits the format
            // if not, dismisses click
            if (!Regex.IsMatch(this.answerInputTextBox.Text, @"^[A-Z]{1,9}$"))
            {
                MessageBox.Show("Your word is invalid!\n\n- Only consist A~Z letters.\n- Length should be 1 to 9.", "Input Error!");
                
                return;
            }

            // when condition is satisfied
            MessageBox.Show("Your answer is now submitted!", "Notice");

            // start game
            InitAfterInput();
        }

        /// <summary>
        /// Starting the game after getting input as answer.
        /// </summary>
        private void InitAfterInput()
        {
            // setting input as answer, enabling game screen
            answer = answerInputTextBox.Text;
            inputTextBox.Text = inputTextBox.Text.Substring(0, answer.Length);
            ANSWER_SIZE = answer.Length;
            answerDisplayBtn = new Button[TRY_SIZE, ANSWER_SIZE];

            // disabling user custom input (at first)
            this.answerInputTextBox.Enabled = false;
            this.answerInputTextBox.Visible = false;

            this.startBtn.Enabled = false;
            this.startBtn.Visible = false;

            // set game status running
            isRunning = true;

            // creating the panel as length is dynamic
            this.answerPanel = new TableLayoutPanel
            {
                ColumnCount = ANSWER_SIZE,
                RowCount = TRY_SIZE,
                Location = new Point(262 - 28 * ANSWER_SIZE, 110),
                Size = new Size(54 * ANSWER_SIZE, 54 * TRY_SIZE),
                // Margin = new Padding(3, 4, 3, 4),
                Name = "answerPanel",
            };

            // showing panel in the screen
            this.Controls.Add(this.answerPanel);

            // setting panel layout style
            for (int i = 0; i < ANSWER_SIZE; i++)
            {
                this.answerPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / ANSWER_SIZE));
            }

            for (int i = 0; i < TRY_SIZE; i++)
            {
                this.answerPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / TRY_SIZE));
            }

            // initializing button array
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

                    // adding create buttons to panel
                    this.answerPanel.Controls.Add(answerDisplayBtn[row, col], col, row);
                }
            }

            // initializing keyboard button array
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 10; col++)
                {
                    keyBoards[row, col] = new KeyBoard(keyBoardChar[row, col]);

                    // if keyboard button is valid
                    if (keyBoardChar[row, col] != '\0')
                    {
                        // connecting button with click event and adding to panel
                        keyBoards[row, col].button.Click += new System.EventHandler(this.KeyBtn_Click);
                        this.keyBoardBtnPanel.Controls.Add(keyBoards[row, col].button, col, row);
                    }
                }
            }

            // to get focus
            focusCtrl.BringToFront();
            focusCtrl.Focus();

            // enabling enter button action and key input
            this.AcceptButton = enterBtn;
            this.KeyPreview = true;
        }

        /// <summary>
        /// Opens the guide form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NormalGuideBtn_Click(object sender, EventArgs e)
        {
            // defining new form
            var frm = new NormalGuide
            {
                Location = this.Location,
                StartPosition = FormStartPosition.Manual,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false
            };

            // making new form to call this form when it closes
            frm.FormClosing += delegate {
                this.Enabled = true;
                this.Focus();
            };

            // enabling guide form
            this.Enabled = false;
            frm.Show();
        }

        /// <summary>
        /// Getting input from the button click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                InsertKey((Keys)(sender as Button).Text[0]);
            }
            this.Focus();
        }

        /// <summary>
        /// Getting input from the certain key character.
        /// </summary>
        /// <param name="key"></param>
        private void InsertKey(Keys key)
        {
            // if new input is longer than answer, input is dismissed
            if (currentInput.Length >= ANSWER_SIZE)
            {
                return;
            }

            // updating new input
            currentInput += key;
            UpdateDisplayInput();
        }

        /// <summary>
        /// Erasing input
        /// </summary>
        private void EraseKey()
        {
            // if input is empty, request is dismissed
            if (currentInput.Length <= 0)
            {
                return;
            }

            // cutting the last letter from input, and update
            currentInput = currentInput.Substring(0, currentInput.Length - 1);
            UpdateDisplayInput();
        }

        /// <summary>
        /// Checking the guess and compare with the answer.
        /// Invoked when gets 'ENTER' input.
        /// </summary>
        private void CheckAnswer()
        {
            // length of the guess should be same with answer
            if (currentInput.Length < ANSWER_SIZE)
            {
                MessageBox.Show("Your input is too short!", "Input Error!");
                return;
            }

            // array to check cases of curren input and answer
            Case[] cases = Enumerable.Repeat(Case.Null, ANSWER_SIZE).ToArray();

            // copying guess and answer to compare and check them
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

            // Second loop - check whether the character exists, or not
            for (int i = 0; i < ANSWER_SIZE; i++)
            {
                // skips correct case
                if (cases[i] == Case.Correct || copyInput[i] == '\0') 
                    continue;

                // traverses array of answer characters
                for (int j = 0; j < ANSWER_SIZE; j++)
                {
                    // if current character is left in answer array
                    if (copyInput[i] == copyAnswer[j])
                    {
                        cases[i] = Case.Exist;

                        copyInput[i] = '\0';
                        copyAnswer[j] = '\0';

                        break;
                    }

                    // if current characyer not exists in answer array
                    if (j == ANSWER_SIZE - 1)
                    {
                        copyInput[i] = '\0';
                        cases[i] = Case.Absent;
                        break;
                    }
                }
            }

            // updating color displaying
            UpdateKeyBoardColor(currentInput.ToCharArray(), cases);
            UpdateDisplayColor(cases);

            // reset input and increases try count
            currentInput = "";
            tryCount++;

            // if guess is correct
            if (Array.FindAll(cases, (x => x == Case.Correct)).Length == ANSWER_SIZE)
            {
                // finish the game
                isRunning = false;
                MessageBox.Show($"You're correct!\n" +
                    $"You got answer in {tryCount} guess(s).", "You Won!");

                return;
            }

            // if failed to get answer in limited try count
            if (tryCount == TRY_SIZE)
            {
                // finish the game
                isRunning = false;
                MessageBox.Show($"You didn't get the answer!\n" +
                    $"The answer is: {answer}");

                // reveal the answer
                inputTextBox.Text = answer;
                return;
            }

            // updating display
            UpdateDisplayInput();

            this.Focus();
        }

        /// <summary>
        /// Updating status of keyboard button
        /// </summary>
        /// <param name="input"></param>
        /// <param name="cases"></param>
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

        /// <summary>
        /// Changing answer display color
        /// </summary>
        /// <param name="cases"></param>
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

                        // if correct, also renew the answer string
                        var tmp = inputTextBox.Text.ToCharArray();
                        tmp[i] = answer[i];
                        inputTextBox.Text = new string(tmp);
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Updating input to dusplay
        /// </summary>
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

        /// <summary>
        /// Erase the input when pressed DELETE key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                EraseKey();
            }

            this.Focus();
        }

        /// <summary>
        /// zvheck answer when pressed ENTER key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterBtn_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                CheckAnswer();
            }

            this.Select();
        }

        /// <summary>
        /// Setting focus to specific control to get keyboard input and button selection focus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Reset_Focus(object sender, EventArgs e)
        {
            if (isRunning)
            {
                focusCtrl.BringToFront();
                focusCtrl.Focus();
            }
        }

        /// <summary>
        /// KeyDown control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Enter key control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FocusCtrl_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                EnterBtn_Click(sender, e);
            }
        }

        /// <summary>
        /// Back to title (Closes this game screen)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackTitleBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Enforces click range to 0.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnswerInputTextBox_Click(object sender, EventArgs e)
        {
            this.answerInputTextBox.Select(answerInputTextBox.Text.Length, 0);
        }
    }
}
