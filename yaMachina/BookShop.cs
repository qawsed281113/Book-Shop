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
    public partial class BookShop : Form
    {
        BookShopDBContext db = null;

        public BookShop()
        {
            InitializeComponent();
            db= new BookShopDBContext();
            db.Genres.Load();
            db.FIOs.Load();
            db.Publishers.Load();
            db.Years.Load();
            db.Books.Load();
        }


        private void FrmMain_Load(object sender, EventArgs e)
        {

            ShowData();

        }
        private void ShowData()
        {
            var lis_of_books = db.Books.Include("book => book.FIO").Select( p => new
            {
                BookId=p.ID,
                BookName = p.Name,
                BookFio = p.Fio.Name + " " + p.Fio.SurName +" "+p.Fio.LastName,
                BookPublish=p.Publisher.Name,
                BookPages=p.pages,
                BookGenre = p.Genre.Name,
                BookYear = p.Year.YearPublished,
                BookPrice = p.Price,
                BooKContin = p.IsCountin


            }).ToList();
            
            dataGridView1.DataSource = lis_of_books;
            dataGridView1.Columns[0].Visible = false;

        }

        private void buttonAdd_Click(object sender, EventArgs e) // add
        {
            try
            {


                FrmAddBook frmAddBook = new FrmAddBook();
               

                frmAddBook.comboBox1.DataSource = db.Genres.ToList();
                frmAddBook.comboBox1.DisplayMember = "Name";
                frmAddBook.comboBox1.ValueMember = "ID";

              
               

                frmAddBook.comboBox2.DataSource=db.Publishers.ToList();
                frmAddBook.comboBox2.DisplayMember= "Name";
                frmAddBook.comboBox2.ValueMember = "ID";


                frmAddBook.comboBox3.DataSource = db.FIOs.ToList();
                frmAddBook.comboBox3.DisplayMember = "Name";
                frmAddBook.comboBox3.ValueMember = "ID";


        


                frmAddBook.comboBox4.DataSource= db.Years.ToList();
                frmAddBook.comboBox4.DisplayMember= "YearPublished";
                frmAddBook.comboBox4.ValueMember= "ID";



                var res = frmAddBook.ShowDialog();

                if (res == DialogResult.OK)
                {
                  
                    Book book = new Book();
                    


                    //book
                    
                    book.Name = frmAddBook.textBox1.Text;
                    book.pages = (int)frmAddBook.numericUpDown1.Value;
                    book.Price = (int)frmAddBook.numericUpDown2.Value;
                    book.IsCountin = (bool)frmAddBook.Tap.Checked;
                    book.ID_Genre = (int)frmAddBook.comboBox1.SelectedValue;


                    book.ID_Year = (int)frmAddBook.comboBox4.SelectedValue;


                    book.ID_Publisher = (int)frmAddBook.comboBox2.SelectedValue;
                    book.ID_Fio = (int)frmAddBook.comboBox3.SelectedValue;



                    db.Books.Add(book);
                    db.SaveChanges();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e) //edit
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    return;

                }
                int id_select_book = (int)dataGridView1.SelectedRows[0].Cells[0].Value;



                FrmAddBook frmAddBook = new FrmAddBook();
                Book book = db.Books.Find(id_select_book);
                Author frmAddAuthor = new Author();



                //book
                frmAddBook.textBox1.Text = book.Name;
                frmAddBook.numericUpDown1.Value = book.pages;
                frmAddBook.numericUpDown2.Value = book.Price;
                frmAddBook.Tap.Checked = book.IsCountin;
            

                frmAddBook.comboBox2.Text = book.Publisher.Name;


                frmAddBook.comboBox1.DataSource = db.Genres.ToList();
                frmAddBook.comboBox1.DisplayMember = "Name";
                frmAddBook.comboBox1.ValueMember = "ID";
                frmAddBook.comboBox1.SelectedValue = book.ID_Genre;
                frmAddBook.comboBox4.SelectedValue = book.ID_Year;
                frmAddBook.comboBox2.SelectedValue= book.ID_Publisher;

                var res = frmAddBook.ShowDialog();
                if (res == DialogResult.OK)
                {


                    book.Name = frmAddBook.textBox1.Text;
                    book.pages = (int)frmAddBook.numericUpDown1.Value;
                    book.Price = (int)frmAddBook.numericUpDown2.Value;
                    book.IsCountin = (bool)frmAddBook.Tap.Checked;
                    book.ID_Genre = (int)frmAddBook.comboBox1.SelectedValue;
                    book.ID_Year = (int)frmAddBook.comboBox4.SelectedValue;
                    book.ID_Publisher = (int)frmAddBook.comboBox2.SelectedValue;

                    db.SaveChanges();
                    ShowData();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button4_Click(object sender, EventArgs e) //delete
        {
            try
            {
                if (dataGridView1.SelectedRows.Count <= 0)
                {
                    return;

                }
                int id_select_book = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
                if (MessageBox.Show("Are u sure ?", "questoin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Book book = db.Books.Find(id_select_book);
                    db.Books.Remove(book);
                    db.SaveChanges();
                    ShowData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReport frmReport = new FrmReport();
            frmReport.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Author frmAddAuthor = new Author();

            var fioo = frmAddAuthor.ShowDialog();
            if (fioo == DialogResult.OK)
            {
                db.SaveChanges();
                ShowData();
             
            }
           

        }

    
    }
}
