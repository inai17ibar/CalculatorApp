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

        private string currentValue = "0";
        private string previousValue = "";
        public double savedValue = 0;

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
            string buttonText = button.Text;

            // 0または00が押された場合、現在の値が0でなら、何も起こらない
            if ((buttonText == "0" || buttonText == "00") && (textBox1.Text == "0" || textBox1.Text == "00") )
                return;

            // 新しい値が入力される場合
            if (isNewValue) //あっている？
            {
                textBox1.Text = buttonText != "00" ? buttonText : "0";
                isNewValue = false;
            }
            else
            {
                textBox1.Text = textBox1.Text == "0" ? buttonText : textBox1.Text + buttonText;
            }
            currentValue = textBox1.Text; // currentValueを更新
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

        private void button_OperationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Text;

            // 新しい演算子が入力された時点で前の計算を実行する
            // しかし、これは2番目の数値が入力されている場合に限る
            if (!isNewValue)
            {
                PerformCalculation();
            }
            else
            {
                // まだ新しい値が入力されていない（2+ の後）場合、
                // savedValueを現在のtextBox1.Textの値で更新する
                // この時点での計算は行わない
                savedValue = double.Parse(textBox1.Text);
            }

            // 演算子を更新し、新しい値の入力を待つ
            currentOperation = GetOperationFromString(operation);
            isNewValue = true;
        }

        // 新しく追加されたメソッド: 現在の操作に基づいて計算を実行します
        private void PerformCalculation()
        {
            double currentValue = double.Parse(textBox1.Text);
            //Console.WriteLine("savedValue");
            //Console.WriteLine(savedValue);
            //Console.WriteLine("currentValue");
            //Console.WriteLine(currentValue);
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
                    if (currentValue == 0)
                    {
                        MessageBox.Show("ゼロで割ることはできません。"); // ゼロ除算の処理
                        return;
                    }
                    savedValue /= currentValue;
                    break;
                case Operation.None:
                    savedValue = currentValue;
                    break;
            }

            textBox1.Text = savedValue.ToString();
            //textBox1.Text = "0";
            isNewValue = true;
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
        private void button16_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }
        private void button21_Click(object sender, EventArgs e) { button_OperationClick(sender, e); }

        //= button
        private void button19_Click(object sender, EventArgs e)
        {
            if (currentOperation != Operation.None)
            {
                PerformCalculation();
                currentOperation = Operation.None;
                isNewValue = true; // 次の値入力を新しい値として扱う
            }
        }

        //× button
        private void button17_Click(object sender, EventArgs e)
        {
            if (!isNewValue)
            {
                // 数字を入力している途中に「C」が押された場合、テキストボックスを0にリセット
                textBox1.Text = "0";
                isNewValue = true; // 新しい値の入力を待つ状態にする
            }
            else
            {
                // 演算子を選択した後や計算結果が表示された状態で「C」が押された場合
                // 画面上は0を表示するが、savedValue（計算結果）はリセットしない
                textBox1.Text = "0";
                // isNewValueは既にtrueになっているはずなので、ここでは変更不要
            }
        }

        //AC(Clear All ) button
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            savedValue = 0;
            isNewValue = true;
            currentOperation = Operation.None;
        }

        //calutate result textbox
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
