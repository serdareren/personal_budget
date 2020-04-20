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
    public partial class IncomeManeg : Form
    {
        public IncomeManeg()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
        }
        public Intro introfr2 = new Intro();
        UpdateIncome frm2 = new UpdateIncome();

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewIncomes newForm = new AddNewIncomes();
            newForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            introfr2.Show();
            Close();
        }

        string mob;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void loadData()
        {
            listView1.Items.Clear();
            XDocument budgetxml = XDocument.Load("income.xml");
            var users = from usr in budgetxml.Descendants("record")
                        select new
                        {
                            Date = usr.Element("date").Value,
                            Description = usr.Element("description").Value,
                            Category = usr.Element("category").Value,
                            Amount = usr.Element("amount").Value
                        };
            foreach (var us in users)
            {
                ListViewItem lv = new ListViewItem(us.Date);
                lv.SubItems.Add(us.Description);
                lv.SubItems.Add(us.Category);
                lv.SubItems.Add(us.Amount);
                listView1.Items.Add(lv);
            }
        }

        private void IncomeManeg_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(listView1.SelectedIndices.Count != 0){

            if (listView1.SelectedIndices[0] != -1)
            {
                XDocument xmlDoc = XDocument.Load("income.xml");
                mob = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
                XElement element = xmlDoc.Root.Elements("record").Skip(listView1.SelectedIndices[0]).FirstOrDefault();

                if (element != null)
                {
                    element.Remove();
                    xmlDoc.Save("income.xml");
                    MessageBox.Show("Record has been Removed!", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listView1.Items.Clear();
                    loadData();
                }
                else
                {
                    MessageBox.Show("Selected Record do not Exists!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            }

            else
            {
                MessageBox.Show("Selected Record do not Exists!", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {

                if (listView1.SelectedIndices.Count != 0)
                {
                    frm2.Show();

                    XDocument xmlDoc = XDocument.Load("income.xml");
                    XElement element = xmlDoc.Root.Elements("record").Skip(listView1.SelectedIndices[0]).FirstOrDefault();

                    frm2.dateTimePicker1.Text = element.Element("date").Value;
                    frm2.textBox2.Text = element.Element("description").Value;
                    frm2.comboBox1.Text = element.Element("category").Value;
                    frm2.textBox4.Text = element.Element("amount").Value;
                }



                this.Hide();

                if (listView1.SelectedIndices[0] != -1)
                {
                    XDocument xmlDoc = XDocument.Load("income.xml");
                    mob = listView1.Items[listView1.SelectedIndices[0]].SubItems[2].Text;
                    XElement element = xmlDoc.Root.Elements("record").Where(r => (string)r.Element("category") == mob).FirstOrDefault();

                    if (element != null)
                    {
                        element.Remove();
                        xmlDoc.Save("income.xml");
                    }

                }


            }

            else {

                MessageBox.Show("You have not select any data...", "Select Any Data",
   MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
              if (comboBox1.SelectedIndex == 0)
                {
                  if(textBox1.Text != ""){

                  listView1.Items.Clear();
                    XDocument budgetxml = XDocument.Load("income.xml");
                    var users = from usr in budgetxml.Descendants("record")
                                where usr.Element("description").Value.ToUpper() == textBox1.Text.ToUpper()
                                select new
                                {
                                    Date = usr.Element("date").Value,
                                    Description = usr.Element("description").Value,
                                    Category = usr.Element("category").Value,
                                    Amount = usr.Element("amount").Value
                                };
                    foreach (var us in users)
                    {
                        ListViewItem lv = new ListViewItem(us.Date);
                        lv.SubItems.Add(us.Description);
                        lv.SubItems.Add(us.Category);
                        lv.SubItems.Add(us.Amount);
                        listView1.Items.Add(lv);
                    }
                }

                  else
                  {
                      MessageBox.Show("Please enter description..", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
              }
                if (comboBox1.SelectedIndex == 1)
                {
                    if (textBox1.Text !=""){
                    listView1.Items.Clear();
                    XDocument budgetxml = XDocument.Load("income.xml");
                    var users = from usr in budgetxml.Descendants("record")
                                where usr.Element("category").Value.ToUpper() == textBox1.Text.ToUpper()
                                select new
                                {
                                    Date = usr.Element("date").Value,
                                    Description = usr.Element("description").Value,
                                    Category = usr.Element("category").Value,
                                    Amount = usr.Element("amount").Value
                                };
                    foreach (var us in users)
                    {
                        ListViewItem lv = new ListViewItem(us.Date);
                        lv.SubItems.Add(us.Description);
                        lv.SubItems.Add(us.Category);
                        lv.SubItems.Add(us.Amount);
                        listView1.Items.Add(lv);
                    }
                }
                    else
                    {
                        MessageBox.Show("Please enter the category..", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                if (comboBox1.SelectedIndex == 2)
                {
                   

                    listView1.Items.Clear();
                    XDocument budgetxml = XDocument.Load("income.xml");
                    var users = from usr in budgetxml.Descendants("record")
                                where usr.Element("date").Value.ToUpper() == dateTimePicker1.Text.ToUpper()
                                select new
                                {
                                    Date = usr.Element("date").Value,
                                    Description = usr.Element("description").Value,
                                    Category = usr.Element("category").Value,
                                    Amount = usr.Element("amount").Value
                                };
                    foreach (var us in users)
                    {
                        ListViewItem lv = new ListViewItem(us.Date);
                        lv.SubItems.Add(us.Description);
                        lv.SubItems.Add(us.Category);
                        lv.SubItems.Add(us.Amount);
                        listView1.Items.Add(lv);
                    }
                }
            
            else { 

            }

                textBox1.Clear();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        
        }

        private void IncomeManeg_Load_1(object sender, EventArgs e)
        {
            loadData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }

    }
