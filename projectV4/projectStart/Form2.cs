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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace projectStart
{
    public partial class Form2 : Form
    {

        public string FilePath { get; set; }

      





        public Form2()
        {
            InitializeComponent();
               
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        //submit button
        private void button1_Click(object sender, EventArgs e)
        {
            int counter = 0;

            using (StreamWriter writer = new StreamWriter(FilePath))
            {

                writer.WriteLine("Checkbox 1: " + checkBox1.Checked);
                writer.WriteLine("Checkbox 2: " + checkBox2.Checked);

                for (int i = 1; i <= 12; i++)
                {
                    TextBox textBox = this.Controls["textBox" + i] as TextBox;
                    if (textBox != null)
                    {
                        writer.WriteLine(textBox.Text);

                        if (textBox.Text == "")
                        {
                            counter++;
                        }
                        
                    }
                }



                writer.Close();
            }



            if (counter > 0)
            {
                MessageBox.Show("Please fill in all the blanks", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.Hide();


                Form1 f1 = new Form1();


                f1.Show();

                f1.filePath = FilePath;

                SharedData.IsFirstSubmitted = true;


            }




        }




        
        private void button2_Click(object sender, EventArgs e)
        {
            
        }



        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            
                if (SharedData.IsFirstSubmitted)
            {
                button2.Visible = true;
                button1.Enabled = false;
                button1.Visible = false;
            }

           
                using (StreamReader sRead = new StreamReader(FilePath))
                {

                string checkBox1State = sRead.ReadLine();
                if (!string.IsNullOrEmpty(checkBox1State))
                {
                    checkBox1.Checked = bool.Parse(checkBox1State.Replace("Checkbox 1: ", ""));
                    checkBox1.Enabled = false;
                }

                string checkBox2State = sRead.ReadLine();
                if (!string.IsNullOrEmpty(checkBox2State))
                {
                    checkBox2.Checked = bool.Parse(checkBox2State.Replace("Checkbox 2: ", ""));
                    checkBox2.Enabled = false;
                }

                for (int i = 1; i <= 12; i++)
                    {

                        TextBox textBox = this.Controls["textBox" + i] as TextBox;




                        if (textBox != null)
                        {
                            string line = sRead.ReadLine();

                            if (!string.IsNullOrWhiteSpace(line))
                            {
                                textBox.Text = line;
                                textBox.Enabled = false;


                            }

                        }
                    }
                }
            
        }

        //back button
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            f1.filePath = FilePath;

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
