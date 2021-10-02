using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   
    public partial class Form1 : Form
    {
        string param1;
        string param2;
        string param3;
        string param4;
        string param5;
        MyDataContext k = new MyDataContext();
        public Form1()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var result = k.actors.Select(t => new
            {
                Id = t.a_id,
                Name = t._name,
                Birthdate = t._birthdate,   
                State=t._state
            });

            dataGridView1.DataSource = result;
            // Заполнение выпадающего списка
            var states = k.actors.Select(t => t._state).Distinct();

            comboBox1.DataSource = states;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();           
            param1 = form.textBox1.Text;
            param2 = form.textBox2.Text;
            if (form.yesno == "Yes")
            {
                actor au = new actor
                {                   
                    _name = param1,
                   _birthdate = form.dateTimePicker1.Value.Date,
                    _state = param2
                };

                // Добавление в локальную таблицу                
                k.actors.InsertOnSubmit(au);               
                // Синхронизация с БД
                k.SubmitChanges();
                button1_Click(this, null);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = k.actors.Select(t => new
            {
                Id = t.a_id,
                Name = t._name,
                Birthdate = t._birthdate,
                State = t._state
            }).Where(n => n.State == comboBox1.Text);

            dataGridView1.DataSource = result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string del_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            // Выбрать удаляемый набор объектов
            actor au = k.actors.First(a => a._name == del_id);
            k.actors.DeleteOnSubmit(au);         
            // Синхронизировать БД
            k.SubmitChanges();
            button1_Click(this, null);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            param1 = form.textBox1.Text;
            
            if (form.yesno == "Yes")
            {
                string del_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                // Выбрать объект для изменения свойств
                actor au = k.actors.First(a => a._name == del_id);

                // Изменить свойства


                au._name = param1;
                au._birthdate = form.dateTimePicker1.Value.Date;
                au._state = param2;
                // Синхронизировать БД
                k.SubmitChanges();

                button1_Click(this, null);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var result = k.films.Select(t => new
            {
                Id = t.f_id,
                Film_Name = t._film,
                Birthdate = t._relise,
                
            });
            dataGridView1.DataSource = result;            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            form.ShowDialog();
            param1 = form.textBox1.Text;          
            if (form.yesno == "Yes")
            {
                film au = new film
                {
                    _film = param1,
                    _relise = form.dateTimePicker1.Value.Date
                   
                };

                // Добавление в локальную таблицу                
                k.films.InsertOnSubmit(au);
                // Синхронизация с БД
                k.SubmitChanges();
                button1_Click(this, null);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string del_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            // Выбрать удаляемый набор объектов
            film au = k.films.First(a => a._film == del_id);
            k.films.DeleteOnSubmit(au);
            // Синхронизировать БД
            k.SubmitChanges();
            button1_Click(this, null);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.ShowDialog();
            param1 = form.textBox1.Text;
            param2 = form.textBox2.Text;
            if (form.yesno == "Yes")
            {
                actorsfilm au = new actorsfilm
                {
                    a_id = Int32.Parse(param1),
                    f_id = Int32.Parse(param2)
                };

                // Добавление в локальную таблицу                
                k.actorsfilms.InsertOnSubmit(au);
                // Синхронизация с БД
                k.SubmitChanges();
               
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var result = k.actorsfilms.Select(t => new
            {
                Id_Actor = t.a_id,
                Id_Film = t.f_id
            });

            dataGridView1.DataSource = result;
        }

        private void button11_Click(object sender, EventArgs e)
        {
          /*  var result = k.actors.Select(t => new
            {
                Id = t.a_id,
                Name = t._name,
                Birthdate = t._birthdate,
                State = t._state
            }).Where(n => n.State == comboBox1.Text);

            dataGridView1.DataSource = result;*/
            var result = (from t in k.actors
                          join p in k.actorsfilms on t.a_id equals p.a_id
                          join a in k.films on p.f_id equals a.f_id
                          select new
                          {
                              Name = t._name,
                              Birthdate = t._birthdate,
                              State = t._state,
                              Film = a._film,
                              Relise = a._relise,
                              
                          });
            //dataGridView1.DataSource = result;
        }
    }
    
}
