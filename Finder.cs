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
    // Finder Class: Finding 5-letter words that can be answers
    public partial class Finder : Form
    {

        private string[] wordsList;
        private Regex regexLeft, regexRight, regexBoth;
        
        // Constructor
        public Finder()
        {
            InitializeComponent();

            string filePath = "./wordsList.txt";

            // if word list file exists
            if (File.Exists(filePath))
            {
                // read world list file and put in list array
                using (StreamReader reader = new StreamReader(filePath))
                {
                    wordsList = reader.ReadLine().Split(' ');
                    wordsList = Array.ConvertAll(wordsList, str => str.ToUpper());

                    Array.Sort(wordsList);
                }
            }
            else
            {
                // this can't be executed with word list file
                MessageBox.Show("No Word List File Exists!");
                this.Close();
            }

            InsertAll();
        }

        /// <summary>
        /// Putting all items in list
        /// </summary>
        private void InsertAll()
        {
            resultList.Items.Clear();
            resultList.Items.AddRange(wordsList);

            countlbl.Text = $"{resultList.Items.Count} word(s) found in match.";
        }

        /// <summary>
        /// Called when text is changed. Checks the input and updates the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Input_TextChanged(object sender, EventArgs e)
        {
            // Automatically make the letters uppercase
            input.Text = input.Text.ToUpper();

            // if input is blank, display all words available.
            if (input.Text.Length == 0)
            {
                InsertAll();
                return;
            }

            // input can't be longer than 5 letters. 
            if (input.Text.Length > 5)
            {
                input.Text = input.Text.Substring(0, 5);
            }

            // Enforce the selection position
            input.Select(input.Text.Length, 0);

            // if input is matched with format, renew the list
            if (Regex.IsMatch(input.Text, @"^[A-Z*]+$"))
            {
                ValidateInput();
            }
            
        }

        /// <summary>
        /// Renew the list with text as query.
        /// </summary>
        private void ValidateInput()
        {
            // clearing all items in list
            resultList.Items.Clear();

            // enabling both-side wildcard letter
            regexLeft = new Regex(("^*" + input.Text + "$").Replace("*", ".*"));
            regexRight = new Regex(("^" + input.Text + "*$").Replace("*", ".*"));
            regexBoth = new Regex(("^*" + input.Text + "*$").Replace("*", ".*"));

            // if each word matches the input query, add to list
            foreach (string str in wordsList)
            {
                if (regexLeft.IsMatch(str) || regexRight.IsMatch(str) || regexBoth.IsMatch(str))
                {
                    resultList.Items.Add(str);
                }
            }

            countlbl.Text = $"{resultList.Items.Count} word(s) found in match.";
        }
    }
}
