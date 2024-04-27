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

namespace projectStart
{
    public partial class Form3 : Form
    {
        public string FilePath { get; set; }

        public Form3()
        {
            
            InitializeComponent();
          
        }


        //back button
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            f1.filePath = FilePath;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //submit button
        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            bool isBoxChecked = false;

            // Validate input fields
            for (int i = 1; i <= 3; i++)
            {
                TextBox textBox = this.Controls["textBox" + i] as TextBox;
                if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    counter++;
                }
            }

            // Check if checkbox is checked
            if (checkBox1.Checked)
            {
                isBoxChecked = true;
            }

            // Display error message if any validation fails
            if (counter > 0)
            {
                MessageBox.Show("Please fill in all the blanks", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!isBoxChecked)
            {
                MessageBox.Show("Please mark the checkbox", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // All validation passed, write to file
                using (StreamWriter writer = new StreamWriter(FilePath, true)) 
                {
                    writer.WriteLine("---phase2---");
                    writer.WriteLine("Checkbox 1: " + checkBox1.Checked);

                    for (int i = 1; i <= 3; i++)
                    {
                        TextBox textBox = this.Controls["textBox" + i] as TextBox;
                        if (textBox != null)
                        {
                            writer.WriteLine(textBox.Text);
                        }
                    }
                }

                this.Hide();
                Form1 f1 = new Form1();
                f1.Show();
                f1.filePath = FilePath;
                SharedData.IsSecondSubmitted = true;
            }
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            if (SharedData.IsSecondSubmitted)
            {
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
            }


            bool phase2Found = false;

            using (StreamReader sRead = new StreamReader(FilePath))
            {
                string line;
                while ((line = sRead.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase2---")
                    {
                        phase2Found = true;
                        break;
                    }
                }

                if (phase2Found)
                {

                    string checkBox1State = sRead.ReadLine();
                    if (!string.IsNullOrEmpty(checkBox1State))
                    {
                        checkBox1.Checked = bool.Parse(checkBox1State.Replace("Checkbox 1: ", ""));
                        checkBox1.Enabled = false;
                    }

                    for (int i = 1; i <= 3; i++)
                    {
                        TextBox textBox = this.Controls["textBox" + i] as TextBox;

                        if (textBox != null)
                        {
                            string text = sRead.ReadLine();
                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                textBox.Text = text;
                                textBox.Enabled = false;
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            f1.filePath = FilePath;
        }
    }
}
