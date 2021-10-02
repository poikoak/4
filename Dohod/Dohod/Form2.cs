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
    public partial class Form2 : Form
    {

        public string yesno;
        public Form2()
        {
            InitializeComponent();
        }

       
        private void button1_Click_1(object sender, EventArgs e)
        {
            yesno = "Yes";
            if (yesno == "Yes")
            {
                /*   MDataSet.sourcesRow row = MDataSet.sources.NewsourcesRow();*/
                /* row.Name = this.textBox1.Text;*/

            }
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                yesno = "No";
                this.Close();
            
        }
    }
}
