using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {   
            string s1 = textBox1.Text;
            string s2 = textBox2.Text;
            textBox3.Text = null;
            double num1, num2;
            double result = 0;
            if (!double.TryParse(s1, out num1))
            {
                MessageBox.Show("错误");
                return;
            }
            if (!double.TryParse(s2, out num2))
            {
                MessageBox.Show("错误");
                return;
            }
            switch (comboBox1.SelectedIndex)
            {

                case 0: result = num1 + num2; break;
                case 1: result = num1 - num2; break;
                case 2: result = num1 * num2; break;
                case 3: if (num2 == 0) { MessageBox.Show("除数不能为0"); break; } result = num1 / num2; break;
            }
            textBox3.Text = Convert.ToString(result);
        }

        
    }
}
