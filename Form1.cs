using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VigenerCoder
{
    public partial class Form1 : Form
    {
        private bool mode = true;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
            updateResult();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            mode = radioButton1.Checked;
            updateResult();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            mode = radioButton1.Checked;
            updateResult();
        } 
        private void word_textBox_TextChanged(object sender, EventArgs e)
        {
            updateResult();
        }
        private void key_textBox_TextChanged(object sender, EventArgs e)
        {
            updateResult();
        }

        private void updateResult()
        {
            if (word_textBox.Text == "" || key_textBox.Text == "")
            {
                result_textBox.Text = null;
                return;
            }

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    result_textBox.Text = crypt(word_textBox.Text, key_textBox.Text, mode, 'а', 'я');
                    break;
                case 1:
                    result_textBox.Text = crypt(word_textBox.Text, key_textBox.Text, mode, 'a', 'z');
                    break;
            }
            
        }
        private string crypt(string word, string key, bool mode, char fAlphSym, char lAlphSym)
        {
            word = word.ToLower();
            key = key.ToLower();

            string result = null;

            int[] dWord = new int[word.Length];
            int[] dKey = new int[key.Length];

            for (int i = 0; i < word.Length; i++)
            {
                char temp = word[i];
                if ((int)temp >= (int)fAlphSym && (int)temp <= (int)lAlphSym)
                {
                    temp = mode ? (char)((int)temp + ((int)key[(i) % (key.Length)] - fAlphSym + 1))
                        : (char)((int)temp - ((int)key[(i) % (key.Length)] - fAlphSym + 1));

                    if ((int)temp < (int)fAlphSym) temp = (char)(lAlphSym - (fAlphSym - temp - 1));
                    else if ((int)temp > (int)lAlphSym) temp = (char)(fAlphSym + (temp - lAlphSym - 1));

                }

                result = result + temp;
            }

            return result;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateResult();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vigener coder v0.1\nby aDron", "About", MessageBoxButtons.OK);
        }
    }
}
