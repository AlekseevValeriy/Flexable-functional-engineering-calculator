namespace EngineeringCalculator
{
    internal partial class Form : System.Windows.Forms.Form
    {
        private List<Composite> expression = new List<Composite>();
        private readonly InputController input = new InputController();
        
        private Boolean IsStandardМathematics = true;
        private Boolean IsStandardTrigonometry = true;

        public Form()
        {
            InitializeComponent();
            input.Update += UpdateRecord;
        }

        private void UpdateRecord() => Result.Text = Output.ExprassionToRecord(ref expression, debug : true);

        private void Form1_Load(object sender, EventArgs e) { }
        private void buttonZero_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("0"));
        private void buttonOne_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("1"));
        private void buttonTwo_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("2"));
        private void buttonThree_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("3"));
        private void buttonFour_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("4"));
        private void buttonFive_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("5"));
        private void buttonSix_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("6"));
        private void buttonSeven_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("7"));
        private void buttonEight_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("8"));
        private void buttonNine_Click(object sender, EventArgs e) => input.Add(ref expression, new Term("9"));
        private void buttonPi_Click(object sender, EventArgs e) => input.Add(ref expression, new Constanta(Math.PI.ToString()));
        private void buttonE_Click(object sender, EventArgs e) => input.Add(ref expression, new Constanta(Math.E.ToString()));
        private void buttonFloat_Click(object sender, EventArgs e) => input.Add(ref expression, new Comma());
        private void buttonAdd_Click(object sender, EventArgs e) => input.Add(ref expression, new Operator("+", EnumOperator.Add));
        private void buttonSubtract_Click(object sender, EventArgs e) => input.Add(ref expression, new Operator("-", EnumOperator.Subtrack));
        private void buttonMultiply_Click(object sender, EventArgs e) => input.Add(ref expression, new Operator("×", EnumOperator.Multiply));
        private void buttonDivision_Click(object sender, EventArgs e) => input.Add(ref expression, new Operator("÷", EnumOperator.Division));
        private void buttonModular_Click(object sender, EventArgs e) => input.Add(ref expression, new Operator("mod", EnumOperator.Modular));
        private void buttonEqually_Click(object sender, EventArgs e) => Result.Text = Calculate.SolutionEquation(ref expression);
        private void buttonBackspace_Click(object sender, EventArgs e) => input.DeleteLast(ref expression);
        private void buttonClear_Click(object sender, EventArgs e) => input.ClearAll(ref expression);
        private void buttonClearElement_Click(object sender, EventArgs e) => input.ClearOne(ref expression);
        private void buttonSign_Click(object sender, EventArgs e) => input.ChangeSign(ref expression);
        private void buttonReverse_Click(object sender, EventArgs e) => input.Add(ref expression, new FunctionName("reverse", EnumFunctionName.XReverse));
        private void buttonAbs_Click(object sender, EventArgs e) => input.Add(ref expression, new FunctionName("abs", EnumFunctionName.XAbsolute));
        private void buttonExp_Click(object sender, EventArgs e) => input.Add(ref expression, new FunctionName("exp", EnumFunctionName.Exponential));
        private void buttonFactorial_Click(object sender, EventArgs e) => input.Add(ref expression, new FunctionName("factorial", EnumFunctionName.NFactorial));
        private void buttonLn_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ? 
            new FunctionName("ln", EnumFunctionName.NaturalLogarithm) :
            new FunctionName("ePower", EnumFunctionName.EPowerOfX) );
        private void buttonDecimalLog_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ?
            new FunctionName("lg", EnumFunctionName.DecimalLogarithm) :
            new FunctionName("log", EnumFunctionName.LogarithmOfXBasedOnY) );
        private void buttonTenPowerOfX_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ?
            new FunctionName("tenPower", EnumFunctionName.TenPowerOfX) :
            new FunctionName("twoPower", EnumFunctionName.TwoPowerOfX) );
        private void buttonXPowerOfY_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ?
            new FunctionName("power", EnumFunctionName.XPowerOfY) :
            new FunctionName("root", EnumFunctionName.YRootOfX) );
        private void buttonXSquared_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ?
            new FunctionName("powerOfTwo", EnumFunctionName.XPowerOfTwo) :
            new FunctionName("powerOfThree", EnumFunctionName.XPowerOfThree) );
        private void buttonSquareRoot_Click(object sender, EventArgs e) => input.Add(ref expression, IsStandardМathematics ?
            new FunctionName("squareRoot", EnumFunctionName.SquareRootOfX) :
            new FunctionName("cubicRoot", EnumFunctionName.CubicRootOfX) );
        private void buttonNext_Click(object sender, EventArgs e) => input.Add(ref expression, new Next());
        private void buttonEnd_Click(object sender, EventArgs e) => input.Add(ref expression, new End());
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
    }
}