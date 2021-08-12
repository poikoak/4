using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsNote
{
    public partial class Form1 : Form
    {
        int count = 1;
        public string filename;
        public bool isFileChanged;
        public Form1()
        {
            InitializeComponent();
            Initialize();
            saveFileDialog1.Filter = "*.*(*.txt)|*.txt";
            openFileDialog1.Filter = "*.*(*.txt)|*.txt";

            /*TabPage tab = new TabPage("Безымянный " + count);
            TextBox rtb = new TextBox();
            rtb.Dock = DockStyle.Fill;
            tab.Controls.Add(rtb);
            tabControl1.TabPages.Add(tab);*/
            /*count++;*/
            filename = "";
            isFileChanged = false;
           // rtb.TextChanged += textBox1_TextChanged;

        }

        public void Initialize()
        {
            filename = "";
            isFileChanged = false;
            UpdateText();
            
            
        }
        //проверка и написание заголовка файла
        public void UpdateText()
        {
            if (filename != "")//если фаил нейм равен пустоте
            {
                this.Text = filename + " - Notepad";
            }
            else this.Text = "NoNameFile - Notepad";

        }
        //создаем новую вкладку
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TabPage tab = new TabPage("Безымянный " + count);
            RichTextBox rtb = new RichTextBox();
            rtb.Dock = DockStyle.Fill;
            tab.Controls.Add(rtb);
            tabControl1.TabPages.Add(tab);
            count++;
            filename = "";
            isFileChanged = false;
            UpdateText();
            rtb.TextChanged += textBox1_TextChanged;
        }
        //чтобы взаимодеиствовать с вкладками
        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }

            return rtb;
        }
        //вырезать
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }
        //скопировать
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }
        //вставить
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";//в строке заменет слово openFileDialog1 на пустое место
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader stream = new StreamReader(openFileDialog1.FileName);
                    GetRichTextBox().Text = stream.ReadToEnd();
                    stream.Close();
                    filename = openFileDialog1.FileName;
                    isFileChanged = false;
                }
                catch { MessageBox.Show("cant open file"); }
            }
            UpdateText();
            RichTextBox rtb = new RichTextBox();
            rtb.TextChanged += textBox1_TextChanged;
        }
        public void Save(string files)
        {

            if (files == "")
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    files = saveFileDialog1.FileName;
                }
            }
            try
            {
                StreamWriter str = new StreamWriter(files);
                str.Write(GetRichTextBox().Text);
                str.Close();
                filename = files;
                isFileChanged = false;
            }
            catch { MessageBox.Show("cant save file"); }
            UpdateText();
        }
        //Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Save(filename);
        }
        //Save as
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save("");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Close program?", "Program close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
        //отслеживаем был ли изменен фаил вверху файла
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (!isFileChanged)
            {
                this.Text = this.Text.Replace('*', ' ');//заменяет лишние звезды при сохр
                isFileChanged = true;
                this.Text = "*" + this.Text;

            }

        }

        SearchandReplace replaceDialog = null;

    

        private void ReplaceDialog_PerformReplace(string Source, string ReplaceStr)
        {
            if (tabControl1.SelectedTab.Controls[0] is TextBox)
            {
                TextBox mainTextBox = tabControl1.SelectedTab.Controls[0] as TextBox;
                string doc = mainTextBox.Text;
                string newDoc = doc.Replace(Source, ReplaceStr);
                mainTextBox.Text = newDoc;
            }
        }

        private void serchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (replaceDialog == null)
            {
                replaceDialog = new SearchandReplace();
                replaceDialog.PerformReplace += ReplaceDialog_PerformReplace;
            }

            replaceDialog.Show();
            replaceDialog.Focus();
        }
    }
}

