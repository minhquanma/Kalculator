using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalc
{
    public partial class MainForm : Form
    {
        // Calculating variables
        private float sourceNumber = 0;
        private float destinationNumber = 0;
        private float resultNumber = 0;

        // Define maxium input value
        private const int MaxInput = 10;

        // Operator constants
        private const int Division = 1;
        private const int Multiplication = 2;
        private const int Minus = 3;
        private const int Plus = 4;
        private const int Percentage = 5;

        // This var holds the selected operator as int
        private int selectedOperator = 0;

        // This flag  determines the calculating state
        private bool isCalculating = false;

        public MainForm()
        {
            InitializeComponent();
        } 

        public void CheckZero()
        {  
            if (labelResult.Text.Equals("0") || isCalculating)
            {
                labelResult.Text = "";
                isCalculating = false;
            }
        }

        public bool IsFull()
        {
            return labelResult.Text.Count() >= MaxInput ? true : false;

        }

        public void SetNumber(string value)
        {
            CheckZero();

            if (!IsFull())
                labelResult.Text += value;
        }

        public void SetOperator(Operator _operator)
        {
            sourceNumber = float.Parse(labelResult.Text);
            selectedOperator = _operator.Type;
            labelOperation.Text = _operator.Label;
            isCalculating = true;
        }

        public void DisplayResult()
        {
            labelResult.Text = resultNumber.ToString();
            sourceNumber = resultNumber;
            isCalculating = true;
        }

        private void buttonNum0_Click(object sender, EventArgs e)
        {
            SetNumber("0");  
        }

        private void buttonNum1_Click(object sender, EventArgs e)
        {
            SetNumber("1");
        }

        private void buttonNum2_Click(object sender, EventArgs e)
        {
            SetNumber("2");
        }

        private void buttonNum3_Click(object sender, EventArgs e)
        {
            SetNumber("3");
        }

        private void buttonNum4_Click(object sender, EventArgs e)
        {
            SetNumber("4");
        }

        private void buttonNum5_Click(object sender, EventArgs e)
        {
            SetNumber("5");
        }

        private void buttonNum6_Click(object sender, EventArgs e)
        {
            SetNumber("6");
        }

        private void buttonNum7_Click(object sender, EventArgs e)
        {
            SetNumber("7");
        }

        private void buttonNum8_Click(object sender, EventArgs e)
        {
            SetNumber("8");
        }

        private void buttonNum9_Click(object sender, EventArgs e)
        {
            SetNumber("9");
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            SetOperator(new Operator { Type = Division, Label = ":" });
        }

        private void buttonMultiplication_Click(object sender, EventArgs e)
        {
            SetOperator(new Operator { Type = Multiplication, Label = "*" });
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            SetOperator(new Operator { Type = Minus, Label = "-" });
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            SetOperator(new Operator { Type = Plus, Label = "+" });
        }


        private void buttonSquare_Click(object sender, EventArgs e)
        {
            sourceNumber = float.Parse(labelResult.Text);
            labelResult.Text = (sourceNumber * sourceNumber).ToString();
        }

        private void Calculate()
        {
            if (!isCalculating)
                destinationNumber = float.Parse(labelResult.Text);

            switch (selectedOperator)
            {
                case Division:
                    resultNumber = sourceNumber / destinationNumber;
                    break;
                case Multiplication:
                    resultNumber = sourceNumber * destinationNumber;
                    break;
                case Minus:
                    resultNumber = sourceNumber - destinationNumber;
                    break;
                case Plus:
                    resultNumber = sourceNumber + destinationNumber;
                    break;
            }
        }

        private void buttonPercent_Click(object sender, EventArgs e)
        {
            // Calculate the result
            Calculate();

            // Divide the result by 100;
            resultNumber /= 100;
            DisplayResult();
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            // Calculate the result
            Calculate();
            DisplayResult();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            labelResult.Text = "0";
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            int lastIndex = labelResult.Text.Length - 1;
            labelResult.Text = labelResult.Text.Remove(lastIndex, 1);

            if (labelResult.Text.Length == 0)
                labelResult.Text = "0";
        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {
            if (!labelResult.Text.Contains("."))
                labelResult.Text += ".";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    public class Operator
    {
        public int Type { get; set; }
        public string Label { get; set; }
    }
}
