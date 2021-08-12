using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsNote
{
    public delegate void Delegate(string Source, string ReplaceStr);
    public partial class SearchandReplace : Form
    {
        public event Delegate PerformReplace;

        public SearchandReplace()
        {
            InitializeComponent();
        }

     

        private void ReplaceDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            PerformReplace?.Invoke(textBox1.Text, textBox2.Text);
        }
        
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            /*int index = 0;
            String temp = GetRichTextBox().Text;
            GetRichTextBox().Text = "";
            GetRichTextBox().Text = temp;*/
           // while(index< GetRichTextBox())
        }
    }
}

