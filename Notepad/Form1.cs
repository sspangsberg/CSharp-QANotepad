#region Imports

//C# imports
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;



#endregion

namespace Notepad
{
    public partial class Form1 : Form
    {
        #region Class Variables

        List<string> fonts = new List<string>();

        #endregion

        #region Class Methods

        public Form1()
        {
            InitializeComponent();

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts.Add(font.Name);
                comboBox1.Items.Add(font.Name);
            }

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;


            comboBox2.Items.Add(10);
            comboBox2.Items.Add(15);
            comboBox2.Items.Add(20);
            comboBox2.Items.Add(30);
            comboBox2.Items.Add(50);
            comboBox2.SelectedIndex = 0;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            richTextBox1.LoadFile(ofdOpenFile.FileName, RichTextBoxStreamType.RichText);
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ofdOpenFile.Filter = "Rich Text Files (*.rtf)|*.rtf|Text Files (*.txt)|*.txt";
            ofdOpenFile.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        #endregion

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {



        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            richTextBox1.SaveFile(saveFileDialog1.FileName);

            /*
            FileInfo f = new FileInfo(saveFileDialog1.FileName);
            
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,false, Encoding.UTF8))
            {
                sw.Write(richTextBox1.Text);
            }  
            */
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {



        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (FontFamily font in System.Drawing.FontFamily.Families)
                {
                    if (comboBox1.Text.Equals(font.Name))
                    {


                        richTextBox1.SelectionFont = new Font(font, Convert.ToInt16(comboBox2.Text));
                        break;
                    }
                }
            }
            catch (Exception err) { }
        }
               

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont.FontFamily, (float)Convert.ToInt16(comboBox2.Text));
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mistake. not implemented
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int len = this.richTextBox1.TextLength;
            int index = 0;
            int lastIndex = this.richTextBox1.Text.LastIndexOf(this.textBox1.Text);

            //while (index < lastIndex) mistake, only first search found
            //{
                this.richTextBox1.Find(this.textBox1.Text, index, len, RichTextBoxFinds.None);
                this.richTextBox1.SelectionBackColor = Color.Yellow;
                index = this.richTextBox1.Text.IndexOf(this.textBox1.Text, index) + 1;
            //}


            if (richTextBox1.Text.IndexOf(textBox1.Text) != -1)
            {
                textBox1.BackColor = Color.LightGreen;
            }
            else
            {
                textBox1.BackColor = Color.Pink;
                richTextBox1.SelectAll();
                richTextBox1.SelectionBackColor = System.Drawing.Color.White;
                richTextBox1.DeselectAll();
            }

            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FontStyle fs = richTextBox1.SelectionFont.Style;


            if (!richTextBox1.SelectionFont.Bold)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, fs | FontStyle.Bold);
            else
            {
                if (richTextBox1.SelectionFont.Italic)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Italic);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
            }

            richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionFont = richTextBox1.Font;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //mistake italic not working
            /*
            FontStyle fs = richTextBox1.SelectionFont.Style;


            if (!richTextBox1.SelectionFont.Italic)
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, fs | FontStyle.Italic);
            else
            {
                if (richTextBox1.SelectionFont.Bold)
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Bold);
                else
                    richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, FontStyle.Regular);
            }

            richTextBox1.SelectionStart = richTextBox1.SelectionStart + richTextBox1.SelectionLength;
            richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionFont = richTextBox1.Font;
             * */
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.richTextBox1.SelectionBackColor = Color.White;
        }
    }
}
