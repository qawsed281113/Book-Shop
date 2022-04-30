using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yaMachina.Models;

namespace yaMachina
{
    public partial class FrmAddBook : Form
    {
        BookShopDBContext db = null;
        public FrmAddBook()
        {
            InitializeComponent();
            db = new BookShopDBContext();
            db.FIOs.Load();
        }
        private void ShowData()
        {

            //var lis_of_books = db.FIOs.Include("FIO").Select(p => new
            //{
            //    FioID = p.ID,
            //    BookName = p.Name ,
            //    BookSurname = p.SurName ,
            //    BookLastName=p.LastName ,
                
            //}).ToList();

            //dataGridView1.DataSource = lis_of_books;

        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

            ShowData();

        }
            private void button1_Click(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void FrmAddBook_Load(object sender, EventArgs e)
        {

            ShowData();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        
        
        }

        private void numericUpDownYear_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
