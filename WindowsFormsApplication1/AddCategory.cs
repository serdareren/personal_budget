using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        public Category addcat = new Category();

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text !=""){
            
                XElement usr = XElement.Load(@"category.xml");
            XElement nusr = new XElement("record",
                new XElement("name", textBox1.Text.ToUpper())
                );
            usr.Add(nusr);
            usr.Save("category.xml");

            textBox1.Clear();


            addcat.Show();
            addcat.button2.PerformClick();
            Close();

            //newForm.button2.PerformClick();
            //newForm.Show();
            }

            else
            {
                MessageBox.Show("Name can not be empty...", "Enter the name..",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //newForm.Show();
            this.Hide();
        }
    }
}
