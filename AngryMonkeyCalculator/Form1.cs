using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AngryMonkeyCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calc(input.Text);
        }


        private void Calc(string input)
        {
            var parser = Regex.Split(input, @"\s*([-+/*])\s*").Where(n => !string.IsNullOrEmpty(n)).ToList();
            try
            {
                int _value1 = int.Parse(parser[0]);
                var _operator = parser[1];
                int _value2 = int.Parse(parser[2]);


                int CalcResult = 0;

                if (_operator == "+")
                    CalcResult = _value1 + _value2;
                else if (_operator == "-")
                    CalcResult = _value1 - _value2;
                else if (_operator == "*")
                    CalcResult = _value1 * _value2;
                else if (_operator == "/")
                    CalcResult = _value1 / _value2;


                result.ForeColor = Color.White;
                result.Text = $"{_value1} {_operator} {_value2} = {CalcResult}";
            }
            catch
            {
                result.ForeColor = Color.Red;
                result.Text = "Invalid Format";
            }
        }
    }
}
