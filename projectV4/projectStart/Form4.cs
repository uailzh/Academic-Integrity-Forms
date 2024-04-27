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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace projectStart
{
    public partial class Form4 : Form
    {

        public string FilePath { get; set; }

        public Form4()
        {
            InitializeComponent();
        }


        //submit
        private void button2_Click(object sender, EventArgs e)
        {
            int counter = 0;
            

            // Validate input fields
            for (int i = 1; i <= 2; i++)
            {
                TextBox textBox = this.Controls["textBox" + i] as TextBox;
                if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
                {
                    counter++;
                }
            }

           

            // Display error message if validation fails
            if (counter > 0)
            {
                MessageBox.Show("Please fill in all the blanks", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
            else
            {
                // All validation passed, write to file
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    writer.WriteLine("---phase3---");
                   

                    for (int i = 2; i <= 3; i++)
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

                SharedData.IsThirdSubmitted = true;
               
            }
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            if (SharedData.IsThirdSubmitted)
            {
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
            }


            bool phase3Found = false;

            using (StreamReader sRead = new StreamReader(FilePath))
            {
                string line;
                while ((line = sRead.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase3---")
                    {
                        phase3Found = true;
                        break;
                    }
                }

                if (phase3Found)
                {

                   

                    for (int i = 2; i <= 3; i++)
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


        //back
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
            f1.filePath = FilePath;
        }
    }
}
