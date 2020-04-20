using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    public partial class AddNewExpense : Form
    {
        public AddNewExpense()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Description can not be empty!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Category can not be empty", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (textBox4.Text == "")
                    {
                        MessageBox.Show("Amount can not be empty", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {

                        int distance;
                        if (int.TryParse(textBox4.Text, out distance))
                        {

                            XElement usr = XElement.Load(@"budget.xml");
                            XElement nusr = new XElement("record",
                                new XElement("date", dateTimePicker1.Text),
                                new XElement("description", textBox2.Text),
                                new XElement("category", comboBox1.Text),
                                new XElement("amount", textBox4.Text)
                                );
                            usr.Add(nusr);
                            usr.Save("budget.xml");

                            textBox2.Clear();
                            textBox4.Clear();

                            ExpenseManeg newForm = new ExpenseManeg();
                            newForm.Show();
                            this.Hide();
                        }

                        else
                        {
                            MessageBox.Show("Please enter real amount...", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox4.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AddNewExpense_Load(object sender, EventArgs e)
        {
            loadCombo();
            //comboBox1.SelectedIndex = 0;
        }



        private void loadCombo()
        {
            comboBox1.Items.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load("category.xml");
            XmlNodeList nodeList = doc.SelectNodes("category/record");

            foreach (XmlNode node in nodeList)
                if (!comboBox1.Items.Contains(node.SelectSingleNode("name").InnerText))
                    comboBox1.Items.Add(node.SelectSingleNode("name").InnerText);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ExpenseManeg newForm = new ExpenseManeg();
            newForm.Show();
            this.Hide();

        }

    }
}
