using System.Threading;

namespace EngineeringCalculator
{
    internal partial class Form : System.Windows.Forms.Form
    {
        public readonly ExpressionStack expStack = new ExpressionStack();
        private Boolean IsStandardМathematics = true;
        private Boolean IsStandardTrigonometry = true;

        public Form()
        {
            InitializeComponent();
            expStack.Change += ViewUpdate;
            FillDictionary();
        }

        private void ViewUpdate()
        {
            Result.Text = ExpressionToString(ref expStack.expressionStack);
            //Result.Text = DebugExpressionToString(ref expStack.expressionStack);
        }

        private void Form1_Load(object sender, EventArgs e) { }
        
        private void buttonZero_Click(object sender, EventArgs e)
        {
            expStack.Add("0");
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            expStack.Add("1");
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            expStack.Add("2");
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            expStack.Add("3");
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            expStack.Add("4");
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            expStack.Add("5");
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            expStack.Add("6");
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            expStack.Add("7");
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            expStack.Add("8");
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            expStack.Add("9");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            expStack.Add(Operation.Add);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            expStack.Add(Operation.Subtrack);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            expStack.Add(Operation.Multiply);
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            expStack.Add(Operation.Division);
        }

        private void buttonBackspace_Click(object sender, EventArgs e)
        {
            expStack.Delete();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            expStack.Clear();
        }

        private void buttonEqually_Click(object sender, EventArgs e)
        {
            ExpressionStack.Calculate(expStack);
        }

        private void buttonFloat_Click(object sender, EventArgs e)
        {
            expStack.ToFloat();
        }

        private void buttonSign_Click(object sender, EventArgs e)
        {
            expStack.ChangeSign();
        }

        private void buttonSecondFunctionalityМathematics_Click(object sender, EventArgs e)
        {
            new Thread(ChangeFunctionМathematics).Start();

            async void ChangeFunctionМathematics()
            {
                if (IsStandardМathematics)
                {
                    buttonLn.Text = "eᵡ";
                    buttonDecimalLog.Text = "logᵧx";
                    buttonTenPowerOfX.Text = "2ᵡ";
                    buttonXPowerOfY.Text = "ʸ√x";
                    buttonSquareRoot.Text = "³√x";
                    buttonXSquared.Text = "x³";
                    buttonSin.Text = buttonSin.Text + "⁻¹";
                    buttonCos.Text = buttonCos.Text + "⁻¹";
                    buttonTan.Text = buttonTan.Text + "⁻¹";
                    buttonSec.Text = buttonSec.Text + "⁻¹";
                    buttonCsc.Text = buttonCsc.Text + "⁻¹";
                    buttonCot.Text = buttonCot.Text + "⁻¹";
                }
                else
                {
                    buttonLn.Text = "ln";
                    buttonDecimalLog.Text = "log";
                    buttonTenPowerOfX.Text = "10ᵡ";
                    buttonXPowerOfY.Text = "xʸ";
                    buttonSquareRoot.Text = "²√x";
                    buttonXSquared.Text = "x²";
                    buttonSin.Text = buttonSin.Text.Replace("⁻¹", String.Empty);
                    buttonCos.Text = buttonCos.Text.Replace("⁻¹", String.Empty);
                    buttonTan.Text = buttonTan.Text.Replace("⁻¹", String.Empty);
                    buttonSec.Text = buttonSec.Text.Replace("⁻¹", String.Empty);
                    buttonCsc.Text = buttonCsc.Text.Replace("⁻¹", String.Empty);
                    buttonCot.Text = buttonCot.Text.Replace("⁻¹", String.Empty);

                }
                IsStandardМathematics = !IsStandardМathematics;
            }
        }

        private void buttonSecondFunctionalityTrigonometry_Click(object sender, EventArgs e)
        {
            new Thread(ChangeFunctionTrigonometry).Start();

            async void ChangeFunctionTrigonometry()
            {
                if (IsStandardTrigonometry)
                {
                    buttonSin.Text = buttonSin.Text.Replace("sin", "sinh");
                    buttonCos.Text = buttonCos.Text.Replace("cos", "cosh");
                    buttonTan.Text = buttonTan.Text.Replace("tan", "tanh");
                    buttonSec.Text = buttonSec.Text.Replace("sec", "sech");
                    buttonCsc.Text = buttonCsc.Text.Replace("csc", "csch");
                    buttonCot.Text = buttonCot.Text.Replace("cot", "coth");
                }
                else
                {
                    buttonSin.Text = buttonSin.Text.Replace("sinh", "sin");
                    buttonCos.Text = buttonCos.Text.Replace("cosh", "cos");
                    buttonTan.Text = buttonTan.Text.Replace("tanh", "tan");
                    buttonSec.Text = buttonSec.Text.Replace("sech", "sec");
                    buttonCsc.Text = buttonCsc.Text.Replace("csch", "csc");
                    buttonCot.Text = buttonCot.Text.Replace("coth", "cot");
                }
                IsStandardTrigonometry = !IsStandardTrigonometry;
            }
        }

        private void buttonModular_Click(object sender, EventArgs e)
        {
            expStack.Add(Operation.Modular);
        }

        private void buttonClearElement_Click(object sender, EventArgs e)
        {
            expStack.ClearElement();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            expStack.Add(Special.Next);
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            expStack.Add(Special.End);
        }

        private void buttonLn_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.NaturalLogarithm);
            else expStack.Add(Modifier.EPowerOfX);
        }

        private void buttonDecimalLog_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.DecimalLogarithm);
            else expStack.Add(Modifier.LogarithmOfXBasedOnY);
        }

        private void buttonTenPowerOfX_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.TenPowerOfX);
            else expStack.Add(Modifier.TwoPowerOfX);
        }

        private void buttonXPowerOfY_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.XPowerOfY);
            else expStack.Add(Modifier.YRootOfX);
        }

        private void buttonXSquared_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.XPowerOfTwo);
            else expStack.Add(Modifier.XPowerOfThree);
        }

        private void buttonReverse_Click(object sender, EventArgs e)
        {
            expStack.Add(Modifier.XReverse);
        }

        private void buttonAbs_Click(object sender, EventArgs e)
        {
            expStack.Add(Modifier.XAbsolute);
        }

        private void buttonExp_Click(object sender, EventArgs e)
        {
            expStack.Add(Modifier.Exponential);
        }

        private void buttonFactorial_Click(object sender, EventArgs e)
        {
            expStack.Add(Modifier.NFactorial);
        }

        private void buttonPi_Click(object sender, EventArgs e)
        {
            expStack.Add(Constant.Pi);
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            expStack.Add(Constant.E);
        }

        private void buttonSquareRoot_Click(object sender, EventArgs e)
        {
            if (IsStandardМathematics) expStack.Add(Modifier.SquareRootOfX);
            else expStack.Add(Modifier.YRootOfX);
        }
    }
}