using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace projectStart
{
    public partial class Form1 : Form

        

    {
        public string filePath { get; set; }
        private Form5 f5;
        private Form2 f2;
        private Form3 f3;
        private Form4 f4;
        private Form6 f6;







        public Form1()
        {
            InitializeComponent();

            this.Activated += Form1_Activated;
            f5 = new Form5();
            f2 = new Form2();
            f3 = new Form3();
            f4 = new Form4();
            f6 = new Form6();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }



        //phase 1 button
        private void button1_Click(object sender, EventArgs e)
        {

            



            if (!string.IsNullOrEmpty(filePath))
            {




                this.Hide();
             //   Form2 f2 = new Form2();

                // Pass the file path to Form2
                f2.FilePath = filePath;

                SharedData.IsDone = true;

                f2.Show();

                
                if (SharedData.fileHasFirstPhaseDone)
                {
                    f2.button1.Enabled = false;  //submit button
                    f2.button1.Visible = false;
                    f2.button2.Visible = true;  //back button
                } 
               


            }
            



        }

        private void label16_Click(object sender, EventArgs e)
        {

        }



      

        //open file button
        private void button6_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            // ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Filter = "Text files (*.txt)|*.txt";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;

                SharedData.filePathWay = ofd.FileName;
                SharedData.isStarted = true;

                button7.Enabled = true;
                textBox1.Enabled = true;
               
                button1.Enabled = true;

                SharedData.fileHasFirstPhaseDone = false;
                SharedData.fileHasSecondPhaseDone = false;
                SharedData.fileHasThirdPhaseDone = false;
                SharedData.fileHasFourthPhaseDone = false;
                SharedData.fileHasFifthPhaseDone = false;
                SharedData.isDoneFourth = false;
                SharedData.isDoneFifth = false;
                SharedData.IsDone = false;
                SharedData.IsDoneThree = false; 
                SharedData.IsDoneTwo = false;
    
                if (isFileHasPhaseOneAlready(filePath, 14))
                {
                    SharedData.fileHasFirstPhaseDone = true;
                    button1.Text = "View";
                    button2.Enabled = true;

                    button5.Enabled = false;
                    button4.Enabled = false;
                    button3.Enabled = false;
                    button5.Text = "Start";
                    button4.Text = "Start";
                    button3.Text = "Start";
                    button2.Text = "Start";

                }
                
                else
                {
                    SharedData.fileHasFirstPhaseDone = false;
                    SharedData.fileHasSecondPhaseDone = false;
                    SharedData.fileHasThirdPhaseDone = false;
                    SharedData.fileHasFourthPhaseDone = false;
                    SharedData.fileHasFifthPhaseDone = false;

                    button1.Text = "Start";
                    button2.Text = "Start";
                    button3.Text = "Start";
                    button4.Text = "Start";
                    button5.Text = "Start";
                    button4.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button5.Enabled = false;
                }



                if (isFileHasPhaseTwoAlready(filePath))
                {
                    SharedData.fileHasSecondPhaseDone = true;
                    button1.Text = "View";
                    button2.Text = "View";
                    button2.Enabled = true;
                    button3.Enabled = true;

                    button5.Enabled = false;
                    button4.Enabled = false;
                    button5.Text = "Start";
                    button4.Text = "Start";


                }


                if (isFileHasPhaseThirdAlready(filePath))
                {
                    SharedData.fileHasThirdPhaseDone = true;
                    button1.Text = "View";
                    button2.Text = "View";
                    button3.Text = "View";
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;

                    button5.Enabled = false;
                    button5.Text = "Start";
                   
                }

                if (isFileHasPhaseFourthAlready(filePath))
                {
                    SharedData.fileHasFourthPhaseDone = true;
                    button1.Text = "View";
                    button2.Text = "View";
                    button3.Text = "View";
                    button4.Text = "View";
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;

                    button5.Text = "Start";
                    
                }

                if (isFileHasPhaseFifthAlready(filePath))
                {
                    SharedData.fileHasFifthPhaseDone = true;
                    button1.Text = "View";
                    button2.Text = "View";
                    button3.Text = "View";
                    button4.Text = "View";
                    button5.Text = "View";
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    

                }

            }
        }




        private bool isFileHasPhaseOneAlready(string filePath, int minLines)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                int lineCount = 0;
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                    if (lineCount >= minLines)
                        return true;
                }
            }
            return false;
        }

        private bool isFileHasPhaseTwoAlready(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase2---")
                    {
                        
                        return true;
                    }
                }
            }
            
            return false;
        }


        private bool isFileHasPhaseThirdAlready(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase3---")
                    {

                        return true;
                    }
                }
            }

            return false;
        }


        private bool isFileHasPhaseFourthAlready(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase4---")
                    {

                        return true;
                    }
                }
            }

            return false;
        }

        private bool isFileHasPhaseFifthAlready(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Trim() == "---phase5---")
                    {

                        return true;
                    }
                }
            }

            return false;
        }




        //phase 2 button
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        //    Form3 f3 = new Form3();

            // Pass the file path to Form2
            f3.FilePath = filePath;

           
             SharedData.IsDoneTwo = true;
            

            f3.Show();


            if (SharedData.fileHasSecondPhaseDone) {
                f3.button2.Enabled = false;  //submit button
                f3.button2.Visible = false;
                f3.button1.Visible = true; // back button
            }
            
        }


        private void Form1_Activated(object sender, EventArgs e)
        {
           
        }



        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);


            

            if (SharedData.IsDone)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";
            }
            
            
            if (SharedData.IsDoneTwo)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";

                
                button2.Text = "View";
                button3.Enabled = true;
            }

            if (SharedData.IsDoneThree)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;

            }

            if (SharedData.isDoneFourth)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;
                button4.Text = "View";

                button5.Enabled = true;


            }

            if (SharedData.isDoneFifth)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;
                button4.Text = "View";

                button5.Enabled = true;
                button5.Text = "View";
            }

            if (SharedData.fileHasSecondPhaseDone)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
            }

            if (SharedData.fileHasThirdPhaseDone)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;
            }

            if (SharedData.fileHasFourthPhaseDone)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;
                button4.Text = "View";

                button5.Enabled = true;
            }

            if (SharedData.fileHasFifthPhaseDone)
            {
                button2.Enabled = true;
                button1.Enabled = true;
                button1.Text = "View";


                button2.Text = "View";
                button3.Enabled = true;
                button3.Text = "View";

                button4.Enabled = true;
                button4.Text = "View";

                button5.Enabled = true;
                button5.Text = "View";
            }



            if (SharedData.isStarted)
            {
                button7.Enabled = true;
                textBox1.Enabled = true;
            }



        }

        //phase 3
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
          //  Form4 f4 = new Form4();

            // Pass the file path to Form2
            f4.FilePath = filePath;


            SharedData.IsDoneThree = true;


            f4.Show();


            if (SharedData.fileHasThirdPhaseDone)
            {
                f4.button2.Enabled = false;  //submit button
                f4.button2.Visible = false;
                f4.button1.Visible = true;   //back button
            }
            
        }

        //phase 4
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
         //   Form5 f5 = new Form5();

            // Pass the file path to Form2
            f5.FilePath = filePath;


            SharedData.isDoneFourth = true;


            f5.Show();


            if (SharedData.fileHasFourthPhaseDone)
            {
                f5.button2.Enabled = false;  //submit button
                f5.button2.Visible = false;
                f5.button1.Visible = true;  //back button
            }
           
        }

        //phase 5
        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
         //   Form6 f6 = new Form6();

            // Pass the file path to Form2
            f6.FilePath = filePath;


            SharedData.isDoneFifth = true;


            f6.Show();


            if (SharedData.fileHasFifthPhaseDone)
            {
                f6.button2.Enabled = false;  //submit button
                f6.button2.Visible = false;
                f6.button1.Visible = true;  //back button
            }
            
        }

        
        //search
        private void button7_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("You should input a word to search", "WARNING!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // string pythonExePath = "C:\\Program Files\\Python310\\python.exe";

                string pythonExePath = "C:\\Program Files\\Python310\\python.exe";  //provide your own path to python.exe
                string pythonScriptPath = "C:\\Users\\T00645104\\Downloads\\code.py";    // provide your path to the python script I provided to you

                string fileP = SharedData.filePathWay;
                string wordToSearch = textBox1.Text; // Get word to search from the text box

                var pstartinfo = new ProcessStartInfo();
                pstartinfo.FileName = pythonExePath;
                pstartinfo.Arguments = $"\"{pythonScriptPath}\" \"{fileP}\" \"{wordToSearch}\""; // Pass the word as an argument
                pstartinfo.UseShellExecute = false;
                pstartinfo.CreateNoWindow = true;
                pstartinfo.RedirectStandardOutput = true;
                pstartinfo.RedirectStandardError = true;

                var error = "";
                var output = "";

                using (Process process = Process.Start(pstartinfo))
                {
                    error = process.StandardError.ReadToEnd();
                    output = process.StandardOutput.ReadToEnd();
                }

               // Console.WriteLine($"Errors:\n{error}\n");
               // Console.WriteLine($"Output:\n{output}");

                if (!string.IsNullOrEmpty(output))
                {
                    MessageBox.Show(output, "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No result found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
}
