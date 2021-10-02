using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dohod
{
    public partial class Form1 : Form
    {
        int ID;
        string param1;
        string param2;
        decimal param3;
        decimal param4;
        string param5;
        string param6;

        decimal q;
        decimal w;
        decimal qw;
        public Form1()
        {
            InitializeComponent();
        }

        private void Balance()
        {
           /* try
            {
                
                decimal.Parse(sourcesBindingSource.Filter = "Income - Usage");               


                label2.Text = Math.Round(double.Parse(sourcesBindingSource.Filter = "Income - Usage"), 2).ToString() + " руб.";
                
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.sourcesTableAdapter.Fill(this.mmDataSet.Sources);
            Balance();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            sourcesBindingSource.Filter = "Usage=0";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sourcesBindingSource.Filter = "Income=0";
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.yesno == "Yes")
            {
                param1 = form.textBox1.Text;
                param2 = form.textBox2.Text;
                param3 = decimal.Parse(form.textBox3.Text);
                param4 = decimal.Parse(form.textBox4.Text);
                param5 = form.textBox5.Text;
                param6 = form.dateTimePicker1.Value.Date.ToString("s").Substring(0, 10);
                mmDataSet.SourcesRow row = mmDataSet.Sources.NewSourcesRow();
                row.Name = param1;
                row.CategoryName = param2;
                row.Income = param3;
                row.Usage = param4;
                row.Comment = param5;
                row.Date = param6;
                mmDataSet.Sources.AddSourcesRow(row);
                this.sourcesTableAdapter.Update(this.mmDataSet.Sources);
                Balance();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.sourcesTableAdapter.Update(this.mmDataSet.Sources);
            Balance(); 

        }



       
    }
}

