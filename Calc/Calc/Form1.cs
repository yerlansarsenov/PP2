using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Calcul c = new Calcul();
        bool radian = true;
        private void number_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            textBox1.Text += btn.Text;
        }
        private void button_lighton(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Cyan;
        }
        private void button_lightoff(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.White;
        }
        private void operation_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                string[] s = textBox1.Text.Split('.');
                double qwe = double.Parse(s[1]);
                c.first = double.Parse(s[0]) + (qwe / Math.Pow(10,(s[1].Length)));
            }
            catch
            {
                c.first = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
            c.operation = btn.Text;
        }
        private void operation_(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                string[] s = textBox1.Text.Split('.');
                double qwe = double.Parse(s[1]);
                c.first = double.Parse(s[0]) + (qwe / Math.Pow(10, (s[1].Length)));
            }
            catch
            {
                c.first = double.Parse(textBox1.Text);
            }
            textBox1.Clear();
            c.operation = btn.Text;
            if (radioButton1.Checked)
            {
                radian = true;
            }
            else radian = false;
            c.calculate(radian);
            textBox1.Text = c.result + "";
            c.first = c.result;
        }
        private void memory_read(object sender, EventArgs e)
        {
            c.second = c.memory;
            textBox1.Text = c.memory+"";
        }
        private void memory_save(object sender, EventArgs e)
        {
            try
            {
                string[] s = textBox1.Text.Split('.');
                double qwe = double.Parse(s[1]);
                c.first = double.Parse(s[0]) + (qwe / Math.Pow(10, (s[1].Length)));
            }
            catch
            {
                c.first = double.Parse(textBox1.Text);
            }
            c.memory = c.first;
            textBox1.Clear();
        }
        private void result_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            try
            {
                string[] s = textBox1.Text.Split('.');
                double qwe = double.Parse(s[1]);
                c.second = double.Parse(s[0]) + (qwe / Math.Pow(10, (s[1].Length)));
            }
            catch
            {
                c.second = double.Parse(textBox1.Text);
            }
            if (radioButton1.Checked)
            {
                radian = true;
            }
            else radian = false;
            c.calculate(radian);
            textBox1.Text = c.result+"";
            c.first = c.result;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
        }
        private void button16_Click(object sender, EventArgs e)
        {
            double ms = c.memory;
            c = new Calcul();
            c.memory = ms;
            textBox1.Clear();
        }
        private void button14_Click(object sender, EventArgs e)
        {
           textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
            {
                textBox1.Text += ".";
            }
        }
        
    }
}
