using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using static System.Windows.Forms.LinkLabel;
using System.Dynamic;
using System.Threading;

namespace EngineeringCalculator
{
    public partial class Form1 : Form
    {
        private ExpressionStack expStack = new ExpressionStack();
        private static Dictionary<Operation, String> OperationDictionary = new Dictionary<Operation, String>();

        private Boolean IsStandardМathematics = true;
        private Boolean IsStandardTrigonometry = true;

        private enum Operation
        {
            Add = 0,
            Subtrack = 1,
            Multiply = 2,
            Division = 3
        }
        private static Operation[] binaryOperation = { Operation.Add, Operation.Subtrack, Operation.Multiply, Operation.Division };

        public Form1()
        {
            InitializeComponent();
            expStack.Change += ExpressionViewChange;
            //expStack.Change += DebugExpressionViewChange;
            FillDictionary();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void FillDictionary()
        {
            OperationDictionary.Add(Operation.Add, "+");
            OperationDictionary.Add(Operation.Subtrack, "-");
            OperationDictionary.Add(Operation.Multiply, "*");
            OperationDictionary.Add(Operation.Division, "/");
        }

        private void ExpressionViewChange()
        {
            Result.Text = String.Join(" ", expStack.TextView());
        }

        private void DebugExpressionViewChange()
        {
            List<String> expression = expStack.TextView().ToList<String>();
            for (int i = 0; i < expression.Count; i++)
            {
                expression[i] = $"'{expression[i]}'";
            }
            Result.Text = String.Join(" ", expression);
        }

        async private void ChangeFunctionМathematics() 
        {
            if (IsStandardМathematics)
            {
                buttonLn.Text = "eᵡ";
                buttonLog.Text = "logᵧx";
                button10PowerOfX.Text = "2ᵡ";
                buttonXPowerOfY.Text = "ʸ√x";
                buttonSquareRoot.Text = "³√x";
                buttonXSquared.Text = "x³";
                buttonSin.Text = buttonSin.Text + "¯¹";
                buttonCos.Text = buttonCos.Text + "¯¹";
                buttonеTan.Text = buttonеTan.Text + "¯¹";
                buttonSec.Text = buttonSec.Text + "¯¹";
                buttonScs.Text = buttonScs.Text + "¯¹";
                buttonCot.Text = buttonCot.Text + "¯¹";
            }
            else 
            {
                buttonLn.Text = "ln";
                buttonLog.Text = "log";
                button10PowerOfX.Text = "10ᵡ";
                buttonXPowerOfY.Text = "xʸ";
                buttonSquareRoot.Text = "²√x";
                buttonXSquared.Text = "x²";
                buttonSin.Text = buttonSin.Text.Replace("¯¹", String.Empty);
                buttonCos.Text = buttonCos.Text.Replace("¯¹", String.Empty);
                buttonеTan.Text = buttonеTan.Text.Replace("¯¹", String.Empty);
                buttonSec.Text = buttonSec.Text.Replace("¯¹", String.Empty);
                buttonScs.Text = buttonScs.Text.Replace("¯¹", String.Empty);
                buttonCot.Text = buttonCot.Text.Replace("¯¹", String.Empty);

            }
            IsStandardМathematics = !IsStandardМathematics;
        }

        async private void ChangeFunctionTrigonometry() 
        {
            if (IsStandardTrigonometry)
            {
                buttonSin.Text = buttonSin.Text.Replace("sin", "sinh");
                buttonCos.Text = buttonCos.Text.Replace("cos", "cosh");
                buttonеTan.Text = buttonеTan.Text.Replace("tan", "tanh");
                buttonSec.Text = buttonSec.Text.Replace("sec", "sech");
                buttonScs.Text = buttonScs.Text.Replace("csc", "csch");
                buttonCot.Text = buttonCot.Text.Replace("cot", "coth");
            }
            else
            {
                buttonSin.Text = buttonSin.Text.Replace("sinh", "sin");
                buttonCos.Text = buttonCos.Text.Replace("cosh", "cos");
                buttonеTan.Text = buttonеTan.Text.Replace("tanh", "tan");
                buttonSec.Text = buttonSec.Text.Replace("sech", "sec");
                buttonScs.Text = buttonScs.Text.Replace("csch", "csc");
                buttonCot.Text = buttonCot.Text.Replace("coth", "cot");
            }
            IsStandardTrigonometry = !IsStandardTrigonometry;
        }

        private class ExpressionStack
        {
            public delegate void ExpressionHandler();
            public event ExpressionHandler Change;
            private List<Object> expressionStack = new List<Object>(); // contains String and Operation
            private Object Last { get => expressionStack.Last(); set => expressionStack[expressionStack.Count - 1] = value; }
            private Int32 Count { get => expressionStack.Count(); }

            public void Add(String value)
            {
                if (Count == 0) { expressionStack.Add(value); Change.Invoke(); return; }
                switch (Last)
                {
                    case String number:
                        {
                            if (number == "0")
                            {
                                if (value != "0") Last = value;
                                else { }
                            }
                            else Last = number + value;
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Set(String value)
            {
                if (Count == 0) { expressionStack.Add(value); Change.Invoke(); return; }
                switch (Last)
                {
                    case String _:
                        {
                            Last = value;
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Add(Operation operation)
            {
                if (Count == 0) { return; }
                switch (Last)
                {
                    case String number:
                        {
                            expressionStack.Add(operation);
                            goto default;
                        }
                    case Operation _:
                        {
                            Last = operation;
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Delete()
            {
                if (Count == 0) { return; }
                switch (Last)
                {
                    case String number:
                        {
                            if (number.Length == 1) { expressionStack.RemoveAt(Count - 1); }
                            else Last = number.Remove(number.Length - 1);
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.RemoveAt(Count - 1);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Calculate()
            {
                if (Count == 0 || Last is Operation) { return; }
                var operationsLINQ =
                    from obj in expressionStack
                    where obj is Operation
                    select (Operation)obj;

                List<Operation> operations = operationsLINQ.ToList<Operation>();

                Int16 operationsCount = (Int16)operations.Count();

                for (Int16 I = 0; I < operationsCount; I++)
                {
                    Operation operation = (Operation)(operations.Max(i => (Int16)i));
                    operations.RemoveAt(operations.IndexOf(operation));
                    String result = "0", value1, value2;
                    try
                    {
                        if (binaryOperation.Contains(operation))
                        {
                            (value1, value2) = ValuesCapture(operation);
                            if (operation is Operation.Add) result = OperationPerforming(value1, value2, (d1, d2) => d1 + d2, (i1, i2) => i1 + i2);
                            else if (operation is Operation.Subtrack) result = OperationPerforming(value1, value2, (d1, d2) => d1 - d2, (i1, i2) => i1 - i2);
                            else if (operation is Operation.Multiply) result = OperationPerforming(value1, value2, (d1, d2) => d1 * d2, (i1, i2) => i1 * i2);
                            else if (operation is Operation.Division) result = Division(value1, value2);
                        }
                    }
                    catch (DivideByZeroException)
                    {
                        Clear();
                        break;
                    }

                    expressionStack[expressionStack.IndexOf(operation)] = result;
                }

                Change.Invoke();

                (String, String) ValuesCapture(Operation operation)
                {
                    Int16 index0 = (Int16)expressionStack.IndexOf(operation);
                    Int16 index1 = (Int16)(index0 - 1);
                    Int16 index2 = (Int16)(index0 + 1);
                    String value1 = (String)expressionStack[index1];
                    String value2 = (String)expressionStack[index2];
                    expressionStack.RemoveAt(index2);
                    expressionStack.RemoveAt(index1);

                    return (value1, value2); 
                }

                String OperationPerforming(String value1, String value2, Expression<Double> expressionDouble, Expression<Int64> expressionInt)
                {
                    if (IsFloat(value1) | IsFloat(value2)) return expressionDouble(Double.Parse(value1), Double.Parse(value2)).ToString();
                    else return expressionInt(Int64.Parse(value1), Int64.Parse(value2)).ToString();
                }

                String Division(String value1, String value2)
                {
                    if ((value2.Count(x => x == '0') + value2.Count(x => x == ',')) == value2.Length) { RaiseErrorDialogZeroDivision(); throw new DivideByZeroException(); }

                    String result = (Double.Parse(value1) / Double.Parse(value2)).ToString();
                    if (IsFloat(result)) return result;
                    else return result.Split(',')[0];
                }

                Boolean IsFloat(String value)
                {
                    if (value.Contains(",") && value.Split(',')[1] != String.Empty) return true;
                    return false;
                }
            }

            delegate T Expression<T>(T value1, T value2);

            public void ToFloat()
            {
                if (Count == 0 || Last is Operation || ((String)Last).Contains(",")) { return; }

                Last = ((String)Last) + ",";

                Change.Invoke();

            }

            public void ChangeSign()
            {
                if (Count == 0 || Last is Operation) { return; }

                if (((String)Last).First() == '-') Last = ((String)Last).Remove(0, 1);
                else Last = "-" + ((String)Last);

                Change.Invoke();
            }

            public IEnumerable<String> TextView()
            {
                foreach (Object obj in expressionStack)
                {
                    switch (obj)
                    {
                        case String value: { yield return value; continue; }
                        case Operation operation: { yield return OperationDictionary[operation]; continue; }
                    }
                }
            }

            public void Clear() { expressionStack.Clear(); Change.Invoke(); }

            private void RaiseErrorDialogZeroDivision()
            {
                const string message = "Вы попытались поделить число на 0.\nАй-я-яй! Это плохо! \nИди в угол и подумай над этим.";
                const string caption = "Преступление: Ты поделил на 0";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);
                if (result == DialogResult.No) { };
            }
        }

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
            expStack.Calculate();
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
        }

        private void buttonSecondFunctionalityTrigonometry_Click(object sender, EventArgs e)
        {
            new Thread(ChangeFunctionTrigonometry).Start();
        }

        private void buttonCos_Click(object sender, EventArgs e)
        {

        }
    }
}