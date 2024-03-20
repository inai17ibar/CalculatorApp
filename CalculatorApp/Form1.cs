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

            // 0�܂���00�������ꂽ�ꍇ�A���݂̒l��0�łȂ�A�����N����Ȃ�
            if ((buttonText == "0" || buttonText == "00") && (textBox1.Text == "0" || textBox1.Text == "00") )
                return;

            // �V�����l�����͂����ꍇ
            if (isNewValue) //�����Ă���H
            {
                textBox1.Text = buttonText != "00" ? buttonText : "0";
                isNewValue = false;
            }
            else
            {
                textBox1.Text = textBox1.Text == "0" ? buttonText : textBox1.Text + buttonText;
            }
            currentValue = textBox1.Text; // currentValue���X�V
        }

        // �����{�^���̃C�x���g�n���h���[
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

            // �V�������Z�q�����͂��ꂽ���_�őO�̌v�Z�����s����
            // �������A�����2�Ԗڂ̐��l�����͂���Ă���ꍇ�Ɍ���
            if (!isNewValue)
            {
                PerformCalculation();
            }
            else
            {
                // �܂��V�����l�����͂���Ă��Ȃ��i2+ �̌�j�ꍇ�A
                // savedValue�����݂�textBox1.Text�̒l�ōX�V����
                // ���̎��_�ł̌v�Z�͍s��Ȃ�
                savedValue = double.Parse(textBox1.Text);
            }

            // ���Z�q���X�V���A�V�����l�̓��͂�҂�
            currentOperation = GetOperationFromString(operation);
            isNewValue = true;
        }

        // �V�����ǉ����ꂽ���\�b�h: ���݂̑���Ɋ�Â��Čv�Z�����s���܂�
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
                        MessageBox.Show("�[���Ŋ��邱�Ƃ͂ł��܂���B"); // �[�����Z�̏���
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
                case "�~":
                    return Operation.Multiplication;
                case "��":
                    return Operation.Division;
                default:
                    return Operation.None;
            }
        }

        // ���Z�q�{�^���̃C�x���g�n���h���[
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
                isNewValue = true; // ���̒l���͂�V�����l�Ƃ��Ĉ���
            }
        }

        //�~ button
        private void button17_Click(object sender, EventArgs e)
        {
            if (!isNewValue)
            {
                // ��������͂��Ă���r���ɁuC�v�������ꂽ�ꍇ�A�e�L�X�g�{�b�N�X��0�Ƀ��Z�b�g
                textBox1.Text = "0";
                isNewValue = true; // �V�����l�̓��͂�҂�Ԃɂ���
            }
            else
            {
                // ���Z�q��I���������v�Z���ʂ��\�����ꂽ��ԂŁuC�v�������ꂽ�ꍇ
                // ��ʏ��0��\�����邪�AsavedValue�i�v�Z���ʁj�̓��Z�b�g���Ȃ�
                textBox1.Text = "0";
                // isNewValue�͊���true�ɂȂ��Ă���͂��Ȃ̂ŁA�����ł͕ύX�s�v
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
