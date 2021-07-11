using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Calculator : Form
    {
        Double resultValue = 0;

        string opPerformed = "";
        bool isopPerformed = false;
        public Calculator()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {   //чтобы стерень 0 в текст боксе и заменить его на число
            if ((textBox.Text == "0") || (isopPerformed))
                textBox.Clear();
            //получаем число 
            Button button = (Button)sender;
         /*   if ((textBox.Text == "0") || (!isopPerformed))
            {
                if ((button.Text == ","))
                {
                    textBox.Text = textBox.Text + "0,";
                }
                else
                    textBox.Text = textBox.Text + button.Text;*/
                //проверка что это не +-*/
                isopPerformed = false;



            //чтобы бесконечно нельзя было ставить .
            if ((button.Text == ","))
            {
                if   (!textBox.Text.Contains(","))
                    textBox.Text = textBox.Text + ",";
               
            }
            else
                textBox.Text = textBox.Text + button.Text;

        }
    
            private void op_click(object sender, EventArgs e)
            {
                Button button = (Button)sender;


                opPerformed = button.Text;
                try
                {
                    resultValue = Convert.ToDouble(textBox.Text);
                }
                catch { MessageBox.Show("Введите правильные данные"); }
                label.Text = resultValue + " " + opPerformed;
                isopPerformed = true;

            }

            private void button_clickCE(object sender, EventArgs e)
            {
                textBox.Text = "0";

            }

            private void button_clickC(object sender, EventArgs e)
            {
                textBox.Text = "0";
                resultValue = 0;

            }



            private void op_clickEqual(object sender, EventArgs e)
            {


                switch (opPerformed)
                {

                    case "+":
                        textBox.Text = (resultValue + Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "-":
                        textBox.Text = (resultValue - Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "/":
                        textBox.Text = (resultValue / Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    case "*":
                        textBox.Text = (resultValue * Convert.ToDouble(textBox.Text)).ToString();
                        break;
                    default:
                        break;
                }
                //resultValue = Double.Parse(textBox.Text);
                label.Text = " ";
            }


        
    }
}

