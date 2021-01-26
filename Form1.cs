using System;
using System.Windows.Forms;

/* References:
 * 
 * Free icons and images obtained from
 * http://clipart-library.com/
 * https://icon-icons.com/
 * 
 */

namespace MathApp
{
    public partial class Form1 : Form
    {
        bool TextBox1Valid { get; set; }
        bool TextBox2Valid { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            TextBox1Valid = false;
            TextBox2Valid = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float textBox1Number = float.Parse(textBox1.Text);
            float textBox2Number = float.Parse(textBox2.Text);

            if (radioAddition.Checked)
                label1.Text = GetAdditionAnswer(textBox1Number, textBox2Number);
            else if (radioSubtraction.Checked)
                label1.Text = GetSubtractionAnswer(textBox1Number, textBox2Number);
            else if (radioMultiplication.Checked)
                label1.Text = GetMultiplicationAnswer(textBox1Number, textBox2Number);
            else if (radioDivision.Checked)
            {
                if (textBox2Number == 0)
                {
                    label2.Text = "Can't divide by zero.";
                    label1.Text = "";
                }
                else
                {
                    label1.Text = GetDivisionAnswer(textBox1Number, textBox2Number);
                }
            }
            else if (radioRemainder.Checked)
                label1.Text = GetRemainderAnswer(textBox1Number, textBox2Number);
        }

        void textBox1_OnTextChanged(object sender, EventArgs e)
        {
            TextBox1Valid = ValidateTextBox(textBox1);
            button1.Enabled = TextBox1Valid && TextBox2Valid;
        }

        void textBox2_OnTextChanged(object sender, EventArgs e)
        {
            TextBox2Valid = ValidateTextBox(textBox2);
            button1.Enabled = TextBox1Valid && TextBox2Valid;
        }

        #endregion

        #region Math Methods

        string GetAdditionAnswer(float a, float b) => (a + b).ToString();

        string GetSubtractionAnswer(float a, float b) => (b - a).ToString();

        string GetMultiplicationAnswer(float a, float b) => (a * b).ToString();

        string GetDivisionAnswer(float a, float b) => (a / b).ToString();

        string GetRemainderAnswer(float a, float b) => (a % b).ToString();

        #endregion

        #region Validation Methods

        bool ValidateTextBox(TextBox textBox)
        {
            if (textBox.Text == "")
            {
                label2.Text = "";
                return false;
            }
            else if (!CanParseToFloat(textBox.Text))
            {
                label2.Text = "Numeric values only! 😡";
                return false;
            }
            else
            {
                label2.Text = "";
                return true;
            }
        }

        bool CanParseToFloat(string text) => float.TryParse(text, out float _);

        #endregion
    }
}
