using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeHomeW6
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            int input = Convert.ToInt32(textBoxInput.Text);
            Form2 form2 = new Form2();
            form2.a = input;
            if (input <= 3)
            {
                MessageBox.Show("harus lebih gede dari 3 bang ", "ERROR");
            }
            else
            {
                form2.ShowDialog();
                textBoxInput.Clear();
            }

        }

        
    }
}
