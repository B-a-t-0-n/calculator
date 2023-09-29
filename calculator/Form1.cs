using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public delegate void Operation(ref double? num1, double[] nums, ref int indexNums);

    public partial class Form1 : Form
    {
        private Operation Operation;
        private string text = "";
        private string num;
        private double? num1 = null;
        private double[] nums;
        private int index = 2;
        private int indexNums = 0;
        private string operationText = " ";
        private string expression = "";

        public Form1()
        {
            InitializeComponent();
            nums = new double[index];
            button13.Enabled = false;
        }

        void Sum(ref double? num1, double[] nums, ref int indexNums)
        {
            num1 += nums[indexNums];
            indexNums++;
        }

        void Subtraction(ref double? num1, double[] nums, ref int indexNums)
        {
            num1 -= nums[indexNums];
            indexNums++;
        }

        void Multiplication(ref double? num1, double[] nums, ref int indexNums)
        {
            num1 *= nums[indexNums];
            indexNums++;
        }

        void Division(ref double? num1, double[] nums, ref int indexNums)
        {
            num1 /= nums[indexNums];
            indexNums++;
        }

        private void Numbutton_Click(object sender, EventArgs e)
        {
            switch ((sender as Button).Text)
            {
                case "=":
                    indexNums = 0;
                    Operation(ref num1, nums,ref indexNums);
                    richTextBox1.Text += " = " + num1;
                    button13.Enabled = false;
                    break; 
                case "C":
                    num = "";
                    text = "";
                    operationText = "";
                    richTextBox1.Text = "";
                    expression = "";
                    num1 = null;
                    index = 2;
                    indexNums = 0;
                    nums = new double[index];
                    Operation = null;
                    button13.Enabled = false;
                    break;
                case "<--":
                    richTextBox1.Text = "данная кнопка не работает нажми на С и пиши заново";
                    break;
                default:
                    num += (sender as Button).Text;
                    richTextBox1.Text = expression + text + num;
                    if (num1 != null) 
                    {
                        nums[indexNums] = Convert.ToDouble(num);
                        button13.Enabled = true;
                    }
                    break;
            }
        }

        private void ButtonOperation(object sender, EventArgs e)
        {
            operationText = (sender as Button).Text;
            expression += num + " " + operationText + " ";
            richTextBox1.Text = expression;
            if (num1 == null)
                num1 = Convert.ToDouble(num);
            else {
                index += 2;
                Array.Resize<double>(ref nums, index);
                indexNums++;
            }
            num = "";
            switch (operationText)
            {
                case "+":
                    Operation += Sum;  
                    break;
                case "-":
                    Operation += Subtraction;
                    break;
                case "x":
                    Operation += Multiplication;
                    break;
                case "/":
                    Operation += Division;
                    break;
            }
        }
    }
}
