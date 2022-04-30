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
    public partial class Author : Form
    {
        BookShopDBContext db = null;
        public Author()
        {
            InitializeComponent();
            db = new BookShopDBContext();
            db.FIOs.Load();
        }

        private void ShowData()
        {
            var list_of_autor = db.FIOs.Include("FIOs").Select(p => new
            {
                id=p.ID,
                Name = p.Name,
                Surname = p.SurName,
                LastName = p.LastName,



            }).ToList();

            dataGridView1.DataSource = list_of_autor;

        }


        private void Author_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void textBoxAutorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)//add
        {

            AddAuthor frmAddAuthor = new AddAuthor();

            var res = frmAddAuthor.ShowDialog();
            if (res == DialogResult.OK)
            {
                FIO fio = new FIO();


                fio.Name = frmAddAuthor.textBoxAutorName.Text;
                fio.SurName = frmAddAuthor.textBoxAutorSurname.Text;
                fio.LastName = frmAddAuthor.textBoxAutorLastName.Text;

                db.FIOs.Add(fio);
                db.SaveChanges();
                ShowData();
            }


        }

        private void button4_Click(object sender, EventArgs e)// edit
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    return;

                }
                int id_select_auto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show("Are u sure ?", "questoin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FIO fio = db.FIOs.Find(id_select_auto);
                    db.FIOs.Remove(fio);
                    db.SaveChanges();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                return;

            }
            int id_select_autor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;





            AddAuthor frmAddAuthor = new AddAuthor();

            FIO fio = db.FIOs.Find(id_select_autor);



            frmAddAuthor.textBoxAutorName.Text = fio.Name;
            frmAddAuthor.textBoxAutorSurname.Text = fio.SurName;
            frmAddAuthor.textBoxAutorLastName.Text = fio.LastName;








            var res = frmAddAuthor.ShowDialog();
            if (res == DialogResult.OK)
            {
                fio.Name = frmAddAuthor.textBoxAutorName.Text;
                fio.SurName = frmAddAuthor.textBoxAutorSurname.Text;
                fio.LastName = frmAddAuthor.textBoxAutorLastName.Text;

                db.SaveChanges();
                ShowData();

            }

        }
    }


}
    
