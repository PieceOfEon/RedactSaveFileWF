using System;

using System.IO;

using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace RedactSaveFileWF
{
    public partial class Form1 : Form
    {

        public string directory;
        public string name;
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = false;
     
            textBox2.Visible = true;
            label1.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            textBox1.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = false;
            label1.Visible = false;
            //directory = "";
            //directory = textBox2.Text;
            try
            {
                directory = textBox2.Text;
                if (File.Exists(textBox2.Text))
                    using (StreamReader F = new StreamReader(textBox2.Text))
                    {
                        textBox1.Text = F.ReadToEnd();
                    }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
            button1.Visible = true;
            button2.Visible = true;
            textBox1.ReadOnly = true;
            
            button3.Visible = false;
            button4.Visible = false;
            //directory = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = false;
            label1.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            textBox1.ReadOnly = true;

            button3.Visible = false;
            button4.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.ReadOnly = true;
                return;
            }
            else
            {
                Form1 F2 = new Form1();
                F2.Show();
                F2.textBox1.Text = textBox1.Text;
                F2.textBox1.ReadOnly = false;
                F2.button5.Visible = true;
                F2.button6.Visible = true;
                F2.button1.Visible = false;
                F2.button2.Visible = false;
                F2.directory=textBox2.Text;

                directory = F2.directory;
            }

        }

        private async void button5_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
           
            MessageBox.Show(name);
            
            MessageBox.Show(directory);
            try
            {
                if (File.Exists(directory))
                    using (StreamWriter writer = new StreamWriter(directory, false))
                    {
                        await writer.WriteLineAsync(textBox1.Text);
                    }
            }
            catch (Exception E) { MessageBox.Show(E.Message); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = true;
            button2.Visible = true;

            textBox2.Visible = false;
            label1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            textBox1.Visible = true;
            button5.Visible = false;
            button6.Visible = false;
            textBox1.ReadOnly = false;
            Close();
        }
    }
}
