using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stats_Helper {
    public partial class Form1 : Form {

        readonly double[] std_dist = { .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0003, .0002, // -3.4
                                       .0005, .0005, .0005, .0004, .0004, .0004, .0004, .0004, .0004, .0003, // -3.3
                                       .0007, .0007, .0006, .0006, .0006, .0006, .0006, .0005, .0005, .0005, // -3.2
                                       .0010, .0009, .0009, .0009, .0008, .0008, .0008, .0008, .0007, .0007, // -3.1
                                       .0013, .0013, .0013, .0012, .0012, .0011, .0011, .0011, .0010, .0010, // -3.0
                                       .0019, .0018, .0017, .0017, .0016, .0016, .0015, .0015, .0014, .0014, // -2.9
                                       .0026, .0025, .0024, .0023, .0023, .0022, .0021, .0021, .0020, .0019, // -2.8
                                       .0035, .0034, .0033, .0032, .0031, .0030, .0029, .0028, .0027, .0026, // -2.7
                                       .0047, .0045, .0044, .0043, .0041, .0040, .0039, .0038, .0037, .0036, // -2.6
                                       .0062, .0060, .0059, .0057, .0055, .0054, .0052, .0051, .0049, .0048, // -2.5
                                       .0082, .0080, .0078, .0075, .0073, .0071, .0069, .0068, .0066, .0064, // -2.4
                                       .0107, .0104, .0102, .0099, .0096, .0094, .0091, .0089, .0087, .0084, // -2.3
                                       .0139, .0136, .0132, .0129, .0125, .0122, .0119, .0116, .0113, .0110, // -2.2
                                       .0179, .0174, .0170, .0166, .0162, .0158, .0154, .0150, .0146, .0143, // -2.1
                                       .0228, .0222, .0217, .0212, .0207, .0202, .0197, .0192, .0188, .0183, // -2.0
                                       .0287, .0281, .0274, .0268, .0262, .0256, .0250, .0244, .0239, .0233, // -1.9
                                       .0359, .0352, .0344, .0336, .0329, .0322, .0314, .0307, .0301, .0294, // -1.8
                                       .0446, .0436, .0427, .0418, .0409, .0401, .0392, .0384, .0375, .0367, // -1.7
                                       .0548, .0537, .0526, .0516, .0505, .0495, .0485, .0475, .0465, .0455, // -1.6
                                       .0668, .0655, .0643, .0630, .0618, .0606, .0594, .0582, .0571, .0559, // -1.5
                                       .0808, .0793, .0778, .0764, .0749, .0735, .0722, .0708, .0694, .0681, // -1.4
                                       .0968, .0951, .0934, .0918, .0901, .0885, .0869, .0853, .0838, .0823, // -1.3
                                       .1151, .1131, .1112, .1093, .1075, .1056, .1038, .1020, .1003, .0985, // -1.2
                                       .1357, .1335, .1314, .1292, .1271, .1251, .1230, .1210, .1190, .1170, // -1.1
                                       .1587, .1562, .1539, .1515, .1492, .1469, .1446, .1423, .1401, .1379, // -1.0
                                       .1841, .1814, .1788, .1762, .1736, .1711, .1685, .1660, .1635, .1611, // -0.9
                                       .2119, .2090, .2061, .2033, .2005, .1977, .1949, .1922, .1894, .1867, // -0.8
                                       .2420, .2389, .2358, .2327, .2296, .2266, .2236, .2206, .2177, .2148, // -0.7
                                       .2743, .2709, .2676, .2643, .2611, .2578, .2546, .2514, .2483, .2451, // -0.6
                                       .3085, .3050, .3015, .2981, .2946, .2912, .2877, .2843, .2810, .2776, // -0.5
                                       .3446, .3409, .3372, .3336, .3300, .3264, .3228, .3192, .3156, .3121, // -0.4
                                       .3821, .3783, .3745, .3707, .3669, .3632, .3594, .3557, .3520, .3482, // -0.3
                                       .4207, .4168, .4129, .4090, .4052, .4013, .3974, .3936, .3897, .3859, // -0.2
                                       .4602, .4562, .4522, .4483, .4443, .4404, .4364, .4325, .4286, .4247, // -0.1
                                       .5000, .4960, .4920, .4880, .4840, .4801, .4761, .4721, .4681, .4641 // 0.0
        };

        public Form1() {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            if (comboBox1.SelectedItem.ToString() == "Bi-Prob. b(x; n, p)") {
                panel1.BringToFront();
                panel1.Visible = true;
            } else if (comboBox1.SelectedItem.ToString() == "Neg-Bi-Prob. nb(x; n, p)") {
                panel2.BringToFront();
                panel2.Visible = true;
            } else if (comboBox1.SelectedItem.ToString() == "HyperGeo. h(x;n,p)") {
                panel3.BringToFront();
                panel3.Visible = true;
            } else if (comboBox1.SelectedItem.ToString() == "Z-Distribution") {
                panel4.BringToFront();
                panel4.Visible = true;
            }
        }

        private double Factorial(int n) {
            double sum = 1;
            for (int i = 1; i <= n; i++) sum *= i;
            return sum;
        }

        private double Combinatorial(int n, int x) {
            return Factorial(n) / (Factorial(x) * Factorial(n - x));
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
            int x = Int32.Parse(textBox3.Text);
            double p = Double.Parse(textBox2.Text);
            double less_sum = 0;
            double greater_sum = 0;
            double between = 0;

            for (int i = 0; i < less; i++) less_sum += BinomialProbability(n, p, i);
            for (int i = 0; i < greater; i++) greater_sum += BinomialProbability(n, p, i);
            for (int i = lt; i <= gt; i++) between += BinomialProbability(n, p, i);

            label6.Text = BinomialProbability(n, p, x).ToString();
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

        private void button2_Click(object sender, EventArgs e) {
            String str1 = "Mean: ";
            String str2 = "Variance: ";
            String str3 = "STD: ";
            int less = Int32.Parse(textBox11.Text);
            int greater = Int32.Parse(textBox10.Text);
            int lt = Int32.Parse(textBox9.Text);
            int gt = Int32.Parse(textBox8.Text);
            int n = Int32.Parse(textBox14.Text);
            int x = Int32.Parse(textBox12.Text);
            double p = Double.Parse(textBox13.Text);
            double less_sum = 0;
            double greater_sum = 0;
            double between = 0;

            for (int i = 0; i < less; i++) less_sum += NeativeBinomialProbability(n, p, i);
            for (int i = 0; i < greater; i++) greater_sum += NeativeBinomialProbability(n, p, i);
            for (int i = lt; i <= gt; i++) between += NeativeBinomialProbability(n, p, i);

            label25.Text = NeativeBinomialProbability(n, p, x).ToString();
            label23.Text = less_sum.ToString();
            label22.Text = (1 - greater_sum).ToString();
            label19.Text = between.ToString();
            label18.Text = str1 + (x / p).ToString();
            label17.Text = str2 + ((x * (1 - p)) / (p * p)).ToString();
            label16.Text = str3 + Math.Sqrt(((x * (1 - p)) / (p * p))).ToString();
        }

        private double NeativeBinomialProbability(int n, double p, int x) {
            double a = Combinatorial(n - 1, x - 1);
            double b = Math.Pow(p, x);
            double c = Math.Pow(1 - p, n - x);
            return a * b * c;
        }

        private void button3_Click(object sender, EventArgs e) {
            String str1 = "Mean: ";
            String str2 = "Variance: ";
            String str3 = "STD: ";
            int less = Int32.Parse(textBox18.Text);
            int greater = Int32.Parse(textBox17.Text);
            int lt = Int32.Parse(textBox16.Text);
            int gt = Int32.Parse(textBox15.Text);
            int n = Int32.Parse(textBox21.Text);
            int N = Int32.Parse(textBox20.Text);
            int x = Int32.Parse(textBox22.Text);
            int k = Int32.Parse(textBox19.Text);
            double less_sum = 0;
            double greater_sum = 0;
            double between = 0;

            for (int i = 0; i < less; i++) less_sum += HyperGeometricProbability(N, n, k, i);
            for (int i = 0; i < greater; i++) greater_sum += HyperGeometricProbability(N, n, k, i);
            for (int i = lt; i <= gt; i++) between += HyperGeometricProbability(N, n, k, i);

            label44.Text = HyperGeometricProbability(N, n, k, x).ToString();
            label42.Text = less_sum.ToString();
            label41.Text = (1 - greater_sum).ToString();
            label38.Text = between.ToString();
            label37.Text = str1 + (1.0* n * k / N).ToString();
            label36.Text = str2 + (1.0 * n * k * (N - k) * (N - n) / (N * N * (N - 1))).ToString();
            label35.Text = str3 + Math.Sqrt(1.0 * n * k * (N - k) * (N - n) / (N * N * (N - 1))).ToString();
        }

        private double HyperGeometricProbability(int N, int n, int k, int x) {
            double a = Combinatorial(k, x);
            double b = Combinatorial(N - k, n - x);
            double c = Combinatorial(N, n);
            return a * b / c;

        }

        private double find_std_dist(double x) {
            if (x < -3.49) return 0.0;
            if (x > 3.49) return 1.0;
            int temp = 0;
            if (x > 0) temp = 1;
            else x *= -1;
            int tens = Convert.ToInt16(Math.Floor(x * 10));
            int ones = Convert.ToInt16((x * 100)) % 10;
            return Math.Abs(std_dist[(340 - tens * 10) + ones] - temp);
        }

        private void button4_Click(object sender, EventArgs e) {
            double value = find_std_dist(Double.Parse(textBox30.Text));
            double v1 = find_std_dist(Double.Parse(textBox27.Text));
            double v2 = 1 - find_std_dist(Double.Parse(textBox26.Text));
            double v3 = find_std_dist(Double.Parse(textBox24.Text)) - find_std_dist(Double.Parse(textBox25.Text));
            label59.Text = v3.ToString();
            label62.Text = v2.ToString();
            label63.Text = v1.ToString();
            label65.Text = value.ToString();
        }
    }
}
