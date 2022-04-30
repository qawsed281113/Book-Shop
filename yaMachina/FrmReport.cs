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

    public enum OperationField
    { 
       NameOfAuthor,
       BookName,
       Genre

    }
    public partial class FrmReport : Form
    {
        BookShopDBContext db = null;
        public FrmReport()
        {
    
            InitializeComponent();
            db = new BookShopDBContext();
            db.Genres.Load();
            db.FIOs.Load();
            db.Publishers.Load();
            db.Years.Load();
            db.Books.Load();
        }
        private void ShowData()
        {
            var lis_of_books = db.Books.Include("book => book.FIO").Select(p => new
            {
                BookId = p.ID,
                BookName = p.Name,
                BookFio = p.Fio.Name + " " + p.Fio.SurName + " " + p.Fio.LastName,
                BookPublish = p.Publisher.Name,
                BookPages = p.pages,
                BookGenre = p.Genre.Name,
                BookYear = p.Year.YearPublished,
                BookPrice = p.Price


            }).ToList();

            dataGridView1.DataSource = lis_of_books;
            dataGridView1.Columns[0].Visible = false;

        }



   
        
        private void FrmReport_Load(object sender, EventArgs e)
        {

            Dictionary<OperationField, string> map = new Dictionary<OperationField, string> { 
            { OperationField.NameOfAuthor,"Author Name"    },
                {OperationField.BookName,"Book Name" },
                {OperationField.Genre,"Genre" }
            };

            comboBox1.DataSource = new BindingSource(map, null);
            comboBox1.ValueMember = "Key";
            comboBox1.DisplayMember = "Value";
            ShowData();

        }

   


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            var operation = (OperationField)comboBox1.SelectedValue;
            var value = textBox3.Text;
            if (value != "")
            {
                using (BookShopDBContext db = new BookShopDBContext())
                {
                    if (operation == OperationField.NameOfAuthor)
                    {
                        var by_name = db.Books.Where(p => p.Fio.Name == value).Select(p => new
                        {
                            BookId = p.ID,
                            BookName = p.Name,
                            BookFio = p.Fio.Name + " " + p.Fio.SurName + " " + p.Fio.LastName,
                            BookPublish = p.Publisher.Name,
                            BookPages = p.pages,
                            BookGenre = p.Genre.Name,
                            BookYear = p.Year.YearPublished,
                            BookPrice = p.Price
                        }).ToList();
                        dataGridView1.DataSource = by_name;
                    }
                    if (operation == OperationField.BookName)
                    {
                        var by_name = db.Books.Where(p => p.Name == value).Select(p => new
                        {
                            BookId = p.ID,
                            BookName = p.Name,
                            BookFio = p.Fio.Name + " " + p.Fio.SurName + " " + p.Fio.LastName,
                            BookPublish = p.Publisher.Name,
                            BookPages = p.pages,
                            BookGenre = p.Genre.Name,
                            BookYear = p.Year.YearPublished,
                            BookPrice=p.Price
                        }).ToList();
                        dataGridView1.DataSource = by_name;
                    }
                    if (operation == OperationField.Genre)
                    {
                        var by_name = db.Books.Where(p => p.Genre.Name == value).Select(p => new
                        {
                            BookId = p.ID,
                            BookName = p.Name,
                            BookFio = p.Fio.Name + " " + p.Fio.SurName + " " + p.Fio.LastName,
                            BookPublish = p.Publisher.Name,
                            BookPages = p.pages,
                            BookGenre = p.Genre.Name,
                            BookYear = p.Year.YearPublished,
                            BookPrice = p.Price
                        }).ToList();
                        dataGridView1.DataSource = by_name;
                    }
                }
            }
            else
            {
                MessageBox.Show("Value can't be empty");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            using (BookShopDBContext db = new BookShopDBContext())
            {
          

                var res = db.Books.Include(b => b.Year).OrderByDescending(b => b.Year.YearPublished).Select(p => new
                {
                    BookId = p.ID,
                    BookName = p.Name,
                    BookFio = p.Fio.Name + " " + p.Fio.SurName + " " + p.Fio.LastName,
                    BookPublish = p.Publisher.Name,
                    BookPages = p.pages,
                    BookGenre = p.Genre.Name,
                    BookYear = p.Year.YearPublished,
                    BookPrice = p.Price,
                    BooKContin = p.IsCountin
                }).ToList();

                  dataGridView1.DataSource = res;

            }
        }
        


     
    }
}



