using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public int Id { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using
        (
        var ctx = new testEntities())
            {
                dataGridView1.DataSource = ctx.Products.ToList();
            }
            //List<Test> tests = new List<Test>();
            //var test = new Test();
            //dataGridView1.DataSource = test.Loadcategory();
            dataGridView1.Columns[0].HeaderText = "Номер категории";
            dataGridView1.Columns[1].HeaderText = "Название";
            dataGridView1.Columns[2].HeaderText = "Родительская категория";
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            var test = new Test();
            var rowIndex = this.dataGridView1.CurrentRow.Index;
            this.Id = (int)this.dataGridView1[0, rowIndex].Value;
            var form3 = new Form3();
            form3.ShowDialog();
        }

        private void delete(int id)
        {
            using(testEntities ctx = new testEntities())
            {
                
                var itemtodelete = (from c in ctx.Products where c.Id == id select c).FirstOrDefault();
                  if (itemtodelete != null)
                  {
                    ctx.Products.Remove(itemtodelete);
                    ctx.SaveChanges();
                 }
            }
        }

        public Product Find(int Id)
        {
            using (var context = new testEntities())
            {
                return context.Products.FirstOrDefault(u => u.Id == Id);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //delete(47);
        }
    }
}
