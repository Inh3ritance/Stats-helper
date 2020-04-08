using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stats_Helper
{
    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            panel1.Visible = false;
            if (comboBox1.SelectedItem.ToString() == "Bi-Prob. b(x; n, p)") {
                panel1.Visible = true;
            } else if(comboBox1.SelectedItem.ToString() == "Neg-Bi-Prob. nb(x; n, p)") {
                panel2.Visible = true;
            }
        }

        private double Factorial(int n) {
            double sum = 1;
            for (int i = 1; i <= n; i++) sum *= i;
            return sum;
        }

        private double Combinatorial(int n, int x) {
            return Factorial(n)/(Factorial(x) * Factorial(n-x));
        }

        private double Permutation(int n, int x) {
            return Factorial(n) / Factorial(n - x);
        }

        private void button1_Click(object sender, EventArgs e) {
            String str1 = "Mean: ";
            String str2 = "Variance: ";
            String str3 = "STD: ";
            int less = Int32.Parse(textBox4.Text);
            int greater = Int32.Parse(textBox5.Text);
            int lt = Int32.Parse(textBox6.Text);
            int gt = Int32.Parse(textBox7.Text);
            int n = Int32.Parse(textBox1.Text);
            double p = Double.Parse(textBox2.Text);
            int x = Int32.Parse(textBox3.Text);
            double less_sum = 0;
            double greater_sum = 0;
            double between = 0;
            
            for (int i = 0; i < less; i++) less_sum += BinomialProbability(n, p, i);
            for (int i = 0; i < greater; i++) greater_sum += BinomialProbability(n, p, i);
            for (int i = lt; i <= gt; i++) between += BinomialProbability(n, p, i);

            label6.Text =  BinomialProbability(n, p, x).ToString();
            label7.Text = less_sum.ToString();
            label9.Text = (1 - greater_sum).ToString();
            label12.Text = between.ToString();
            label13.Text = str1 + (n * p).ToString();
            label14.Text = str2 + ((n * p) * (1 - p)).ToString();
            label15.Text = str3 + Math.Sqrt((n * p) * (1 - p)).ToString();
        }

        private double BinomialProbability(int n, double p, int x) {
            double a = Combinatorial(n, x);
            double b = Math.Pow(p, x);
            double c = Math.Pow(1 - p, n - x);
            return a * b * c;
        }
    }
}
