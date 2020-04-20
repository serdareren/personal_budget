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
    public partial class Category : Form
    {
        public Intro introfr1 = new Intro();
        public Category()
        {
            InitializeComponent();
        }

        UpdateCategory updtc = new UpdateCategory();

        private void button5_Click(object sender, EventArgs e)
        {
            introfr1.Show();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCategory newForm1 = new AddCategory();
            newForm1.addcat = this;
            newForm1.Show();
            //this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {

                if (listView1.SelectedIndices.Count != 0)
                {
                    updtc.Show();

                    XDocument xmlDoc = XDocument.Load("category.xml");
                    XElement element = xmlDoc.Root.Elements("record").Skip(listView1.SelectedIndices[0]).FirstOrDefault();

                    updtc.textBox1.Text = element.Element("name").Value;
                    
                }

                this.Hide();


                if (listView1.SelectedIndices[0] != -1)
                {
                    XDocument xmlDoc = XDocument.Load("category.xml");
                    mob = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                    XElement element = xmlDoc.Root.Elements("record").Where(r => (string)r.Element("name") == mob).FirstOrDefault();

                    if (element != null)
                    {
                        element.Remove();
                        xmlDoc.Save("category.xml");
                        
                    }

                }

            }
            else
            {
                MessageBox.Show("You have not select any data...", "Select Any Data",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        public void loadData()
        {
            listView1.Items.Clear();
            XDocument budgetxml = XDocument.Load("category.xml");
            var users = from usr in budgetxml.Descendants("record")
                        select new
                        {
                            Category = usr.Element("name").Value
                        };
            foreach (var us in users)
            {
                ListViewItem lv = new ListViewItem(us.Category);
                listView1.Items.Add(lv);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void Category_Load(object sender, EventArgs e)
        {
            loadData();
        }



        string mob;
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count != 0)
            {

                if (listView1.SelectedIndices[0] != -1)
                {
                    XDocument xmlDoc = XDocument.Load("category.xml");
                    mob = listView1.Items[listView1.SelectedIndices[0]].SubItems[0].Text;
                    XElement element = xmlDoc.Root.Elements("record").Where(r => (string)r.Element("name") == mob).FirstOrDefault();

                    if (element != null)
                    {
                        element.Remove();
                        xmlDoc.Save("category.xml");
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


        public Intro itrofr { get; set; }
    }
}
