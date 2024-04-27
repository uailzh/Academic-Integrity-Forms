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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectStart
{
    public partial class Form5 : Form
    {

        public string FilePath { get; set; }

        public Form5()
        {
            InitializeComponent();
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        //submit
        private void button2_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill in all the blanks", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!checkBox1.Checked && !checkBox2.Checked)
            {
                MessageBox.Show("Please mark one of the checkboxes", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (checkBox1.Checked && string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You checked 'No', so please write a comment", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine("---phase4---");
                    string text1 = textBox1.Text;


                    writer.WriteLine(textBox2.Text);
                    writer.WriteLine(textBox3.Text);

                    if (checkBox1.Checked)
                    {
                        writer.WriteLine("No");
                    }
                    else
                    {
                        writer.WriteLine("Yes");
                    }


                    if (!string.IsNullOrWhiteSpace(text1))
                    {
                        writer.WriteLine(text1);
                    }

                }

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
                f1.filePath = FilePath;

                SharedData.isFourthSubmitted = true;
            }
        }



        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            // Uncheck the other checkbox if the clicked checkbox is checked
            if (clickedCheckbox.Checked)
            {
                if (clickedCheckbox == checkBox1)
                {
                    checkBox2.Checked = false;
                }
                else if (clickedCheckbox == checkBox2)
                {
                    checkBox1.Checked = false;
                }



            }


            if (checkBox1.Checked) // "No" checkbox is checked
            {
                textBox1.Enabled = true; // Enable
               
            }
            else
            {
                textBox1.Enabled = false; // Disable 
                textBox1.Clear(); // Clear value
            }
        }

        //back button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            f1.filePath = FilePath;
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            if (SharedData.isFourthSubmitted)
            {
                button1.Visible = true;
                button2.Visible = false;
            }

            bool phase4Found = false;

            using (StreamReader sRead = new StreamReader(FilePath))
            {
                string line;
                while ((line = sRead.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase4---")
                    {
                        phase4Found = true;
                        break;
                    }
                }

                if (phase4Found)
                {
                    
                    textBox2.Text = sRead.ReadLine();
                    textBox3.Text = sRead.ReadLine();
                    string checkBoxValue = sRead.ReadLine();

                    // Set checkbox states and textbox1 value based on file content
                    if (checkBoxValue == "No")
                    {
                        checkBox1.Checked = true;
                        textBox1.Enabled = true;
                        textBox1.Text = sRead.ReadLine(); // Read textbox1 value
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        textBox1.Enabled = false;
                        textBox1.Clear();
                    }

                    textBox1.Enabled = false ; textBox2.Enabled = false ; textBox3.Enabled = false ;
                    checkBox1.Enabled = false ;
                    checkBox2.Enabled = false ;


                }
            }
        }






    }
    }

