using System;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        private enum Operation
        {
            None,
            Addition,
            Subtraction,
            Multiplication,
            Division
        }

        private double savedValue;
        private bool isNewValue;
        private Operation currentOperation;
        const int TEXTBOX_LENGTH = 20;

        public Form1()
        {
            InitializeComponent();
        }

        // M+ button
        private void button1_Click(object sender, EventArgs e)
        {
            // not implemented
        }

        //M- button
        private void button2_Click(object sender, EventArgs e)
        {
            //not implemented
        }

        //MRC button
        private void button3_Click(object sender, EventArgs e)
        {
            //not implemented
        }

        //Number buttons
        private void button_NumberClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (isNewValue)
            {
                textBox1.Text = button.Text;
                isNewValue = false;
            }
            else
            {
                if (textBox1.Text.Length < 20)
                    textBox1.Text += button.Text;
            }
        }

        // 数字ボタンのイベントハンドラー
        private void button6_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button5_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button4_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button9_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button8_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button7_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button12_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button11_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button10_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button15_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }
        private void button14_Click(object sender, EventArgs e) { button_NumberClick(sender, e); }

        //. button
        private void button13_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains("."))
                textBox1.Text += ".";
        }

        //Clear button
        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
        }

        //AC(Clear All ) button
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            savedValue = 0;
            isNewValue = true;
            currentOperation = Operation.None;
        }

        // Operation buttons
        private void button_OperationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            if (!isNewValue)
            {
                double currentValue = double.Parse(textBox1.Text);
                switch (currentOperation)
                {
                    case Operation.Addition:
                        savedValue += currentValue;
                        break;
                    case Operation.Subtraction:
                        savedValue -= currentValue;
                        break;
                    case Operation.Multiplication:
                        savedValue *= currentValue;
                        break;
                    case Operation.Division:
                        savedValue /= currentValue;
                        break;
                    case Operation.None:
                        savedValue = currentValue;
                        break;
                }

                textBox1.Text = savedValue.ToString();
            }

            isNewValue = true;
            currentOperation = GetOperationFromString(operation);
        }


        private Operation GetOperationFromString(string operation)
        {
            switch (operation)
            {
                case "+":
                    return Operation.Addition;
                case "-":
                    return Operation.Subtraction;
                case "×":
                    return Operation.Multiplication;
                case "÷":
                    return Operation.Division;
                default:
                    return Operation.None;
            }
        }

        // 演算子ボタンのイベントハンドラー
        private void button18_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }
        private void button20_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }
        private void button17_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }
        private void button21_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }

        //= button
        private void button19_Click(object sender, EventArgs e)
        {
            button_OperationClick(sender, e);
            currentOperation = Operation.None;
        }

        //calutate result textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
