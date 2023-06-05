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
    public partial class Finder : Form
    {

        private string[] wordsList;
        private Regex regexLeft, regexRight, regexBoth;
        public Finder()
        {
            InitializeComponent();

            string filePath = "./wordsList.txt";

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    wordsList = reader.ReadLine().Split(' ');
                    wordsList = Array.ConvertAll(wordsList, str => str.ToUpper());

                    Array.Sort(wordsList);
                }
            }
            else
            {
                MessageBox.Show("No Word List File Exists!");
                this.Close();
            }

            InsertAll();
        }
        private void InsertAll()
        {
            resultList.Items.Clear();
            resultList.Items.AddRange(wordsList);

            countlbl.Text = $"{resultList.Items.Count} word(s) found in match.";
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            input.Text = input.Text.ToUpper();

            if (input.Text.Length == 0)
            {
                InsertAll();
                return;
            }

            if (input.Text.Length > 5)
            {
                input.Text = input.Text.Substring(0, 5);
            }

            input.Select(input.Text.Length, 0);

            if (Regex.IsMatch(input.Text, @"^[A-Z*]+$"))
            {
                ValidateInput();
            }
            
        }

        private void ValidateInput()
        {
            resultList.Items.Clear();

            regexLeft = new Regex(("^*" + input.Text + "$").Replace("*", ".*"));
            regexRight = new Regex(("^" + input.Text + "*$").Replace("*", ".*"));
            regexBoth = new Regex(("^*" + input.Text + "*$").Replace("*", ".*"));

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
