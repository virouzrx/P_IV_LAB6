using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Z6_WF
{
    public partial class Form1 : Form
    {
        BindingList<Number> numbers = new BindingList<Number>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            var dialog = (OpenFileDialog)sender;
            var path = dialog.FileName;
            var fileContent = File.ReadAllText(path);
            button2.Enabled = true;
            label1.Visible = true;
            foreach (var item in fileContent.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries))
            {
                flowLayoutPanel1.Controls.Add(GenerateNUmberTextBox(Convert.ToInt32(item)));
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private TextBox GenerateNUmberTextBox(int number)
        {
            return new TextBox()
            {
                Text = number.ToString(),
                ReadOnly = true,
                Width = 25
                
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            var randomNumber = rand.Next(100);
            textBox1.Text = randomNumber.ToString();
            flowLayoutPanel2.Controls.Add(GenerateNUmberTextBox(randomNumber));

        }
    }
}
