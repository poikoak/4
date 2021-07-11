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

namespace WindowsFormsApptxt
{
    public partial class Notepad : System.Windows.Forms.Form
    {
        public string filename;
        public bool isFileChanged;

        public Notepad()
        {
            InitializeComponent();
            Initialize();
            saveFileDialog1.Filter = "*.*(*.txt)|*.txt";
            openFileDialog1.Filter = "*.*(*.txt)|*.txt";
        }

        public void Initialize()
        {
            filename = "";
            isFileChanged = false;
            UpdateText();
        }
        //Создать новый документ
        public void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            filename = "";
            isFileChanged = false;
            UpdateText();
        }
        //Открыть новый документ
        public void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";//в строке заменет слово openFileDialog1 на пустое место
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader stream = new StreamReader(openFileDialog1.FileName);
                    textBox1.Text = stream.ReadToEnd();
                    stream.Close();
                    filename = openFileDialog1.FileName;
                    isFileChanged = false;
                }
                catch { MessageBox.Show("cant open file"); }
            }
            UpdateText();
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
                str.Write(textBox1.Text);
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
        //проверка и написание заголовка файла
        public void UpdateText()
        {
            if (filename != "")//если фаил нейм равен пустоте
            {
                this.Text = filename + " - Notepad";
            }
            else this.Text = "NoNameFile - Notepad";

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета формы
            this.BackColor = colorDialog1.Color;

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Font = dialog.Font;


                }


            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Close program?", "Program close", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }

        }

     

        private void toolStripStatusLabel3_MouseMove(object sender, MouseEventArgs e)
        {
           /* int CursorX = Cursor.Position.X;
            int CursorY = Cursor.Position.Y;*/
          /*  toolStripStatusLabel3.Text = "X: " + e.X.ToString() + " Y: " + e.Y.ToString();*/
           
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel3.Text = "X: " + e.X.ToString() + " Y: " + e.Y.ToString();
        }

        private void darkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor=Color.DimGray;
        }

        private void whiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.BackColor = Color.White;
        }
    }
}
