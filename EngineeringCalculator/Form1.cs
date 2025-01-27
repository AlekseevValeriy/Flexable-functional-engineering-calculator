using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using static System.Math;
using System.Collections;

namespace EngineeringCalculator
{
    public partial class Form1 : Form
    {
        private readonly ExpressionStack expStack = new ExpressionStack();
        private static readonly Dictionary<Operation, String> OperationDictionary = new Dictionary<Operation, String>();
        private static readonly Dictionary<Modifier, String> ModifierDictionary = new Dictionary<Modifier, String>();
        private static readonly Dictionary<Constant, String> ConstantDictionary = new Dictionary<Constant, String>();
        private static readonly Dictionary<Special, String> SpecialDictionary = new Dictionary<Special, String>();

        private Boolean IsStandardМathematics = true;
        private Boolean IsStandardTrigonometry = true;

        private enum Operation // binary operand
        {
            Add = 0,
            Subtrack = 1,
            Multiply = 2,
            Division = 3,
            Modular = 4
        }

        private enum Modifier // single operand
        {
            NaturalLogarithm,
            DecimalLogarithm,
            TenPowerOfX,
            XPowerOfY,
            SquareRootOfX,
            XPowerOfTwo,
            EPowerOfX,
            LogarithmOfXBasedOnY,
            TwoPowerOfX,
            YRootOfX,
            CubicRootOfX,
            XPowerOfThree,
            XReverse,
            XAbsolute,
            Exponential,
            NFactorial
        }

        private enum Constant
        {
            Pi,
            E
        }

        private enum Special
        {
            Next,
            End,
            Start,
            Stop
        }

        public Form1()
        {
            InitializeComponent();
            expStack.Change += ExpressionViewChange;
            //expStack.Change += DebugExpressionViewChange;
            FillDictionary();
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private static void FillDictionary()
        {
            OperationDictionary.Add(Operation.Add, "+");
            OperationDictionary.Add(Operation.Subtrack, "-");
            OperationDictionary.Add(Operation.Multiply, "×");
            OperationDictionary.Add(Operation.Division, "÷");
            OperationDictionary.Add(Operation.Modular, "mod");
            ModifierDictionary.Add(Modifier.NaturalLogarithm , "ln");
            ModifierDictionary.Add(Modifier.DecimalLogarithm , "lg");
            ModifierDictionary.Add(Modifier.TenPowerOfX , "tenPower");
            ModifierDictionary.Add(Modifier.XPowerOfY , "power");
            ModifierDictionary.Add(Modifier.SquareRootOfX , "squareRoot");
            ModifierDictionary.Add(Modifier.XPowerOfTwo , "powerOfTwo");
            ModifierDictionary.Add(Modifier.EPowerOfX , "ePower");
            ModifierDictionary.Add(Modifier.LogarithmOfXBasedOnY , "log");
            ModifierDictionary.Add(Modifier.TwoPowerOfX , "twoPower");
            ModifierDictionary.Add(Modifier.YRootOfX , "root");
            ModifierDictionary.Add(Modifier.CubicRootOfX , "cubicRoot");
            ModifierDictionary.Add(Modifier.XPowerOfThree , "powerOfThree");
            ModifierDictionary.Add(Modifier.XReverse , "reverse");
            ModifierDictionary.Add(Modifier.XAbsolute , "abs");
            ModifierDictionary.Add(Modifier.Exponential, "exp");
            ModifierDictionary.Add(Modifier.NFactorial, "factorial");
            ConstantDictionary.Add(Constant.Pi, PI.ToString());
            ConstantDictionary.Add(Constant.E, E.ToString());
            SpecialDictionary.Add(Special.Next, ",");
            SpecialDictionary.Add(Special.End, ".");
            SpecialDictionary.Add(Special.Start, "(");
            SpecialDictionary.Add(Special.Stop, ")");
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

        async private void ChangeFunctionTrigonometry() 
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

        private class ExpressionStack
        {
            public delegate void ExpressionHandler();
            public event ExpressionHandler Change;
            private List<Object> expressionStack = new List<Object>(); // contains String and Operation
            private readonly ModifierStack modStack = new ModifierStack();
            private Object Last { get => expressionStack.Last(); set => expressionStack[expressionStack.Count - 1] = value; }
            private Int32 Count { get => expressionStack.Count(); }

            private Double GetConstant(Constant constant)
            {
                if (constant is Constant.Pi) return PI;
                else if (constant is Constant.E) return E;
                else return 0;
            }

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
                    case Constant constant:
                        {
                            Last = GetConstant(constant).ToString() + value;
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    case Modifier _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    case Special special:
                        {
                            if (special is Special.Next | special is Special.Start) { expressionStack.Add(value); }
                            else if (special is Special.End | special is Special.Stop) { }
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Add(Constant value)
            {
                if (Count == 0) { expressionStack.Add(value); Change.Invoke(); return; }
                switch (Last)
                {
                    case String _:
                        {
                            Last = value;
                            goto default;
                        }
                    case Constant _:
                        {
                            Last = value;
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    case Modifier _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    case Special special:
                        {
                            if (special is Special.Next | special is Special.Start) { expressionStack.Add(value); }
                            else if (special is Special.End | special is Special.Stop) { }
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
                    case String _:
                        {
                            expressionStack.Add(operation);
                            goto default;
                        }
                    case Constant _:
                        {
                            expressionStack.Add(operation);
                            goto default;
                        }
                    case Operation _:
                        {
                            Last = operation;
                            goto default;
                        }
                    case Modifier _: 
                        {
                            goto default;
                        }
                    case Special special:
                        {
                            if (special is Special.Next | special is Special.Start) { }
                            else if (special is Special.End | special is Special.Stop) { expressionStack.Add(operation); }
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Add(Modifier modifier)
            {
                if (Count == 0) { expressionStack.Add(modifier); Change.Invoke(); return; }
                switch (Last)
                {
                    case String _:
                        {
                            goto default;
                        }
                    case Constant _:
                        {
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.Add(modifier);
                            goto default;
                        }
                    case Modifier _:
                        {
                            expressionStack.Add(modifier);
                            goto default;
                        }
                    case Special special:
                        {
                            if (special is Special.Next | special is Special.Start) { expressionStack.Add(modifier); }
                            else if (special is Special.End | special is Special.Stop) { }
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public void Add(Special special)
            {
                if (Count == 0) 
                {
                    if (special is Special.Start) expressionStack.Add(special);
                    Change.Invoke();
                    return; 
                }
                switch (Last)
                {
                    case String _:
                        {
                            if (
                                special is Special.Stop | // <- future //
                                (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                                (special is Special.End & modStack.CanSetEnd(ref expressionStack))
                                ) expressionStack.Add(special);
                            goto default;
                        }
                    case Constant _:
                        {
                            if (
                                special is Special.Stop | // <- future //
                                (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                                (special is Special.End & modStack.CanSetEnd(ref expressionStack))
                                ) expressionStack.Add(special);
                            goto default;
                        }
                    case Operation _:
                        {
                            if (special is Special.Start) expressionStack.Add(special);
                            goto default;
                        }
                    case Modifier _:
                        {
                            if (special is Special.Start) expressionStack.Add(special);
                            goto default;
                        }
                    case Special special2:
                        {
                            if (special2 is Special.Next & special is Special.Start) expressionStack.Add(special);
                            else if (
                                special2 is Special.End & (
                                (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                                (special is Special.End & modStack.CanSetEnd(ref expressionStack)) |
                                special is Special.Stop) // <- future //
                                ) expressionStack.Add(special);
                            else if (special2 is Special.Start & special is Special.Start) expressionStack.Add(special);
                            else if (
                                special2 is Special.Stop & (
                                (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                                (special is Special.End & modStack.CanSetEnd(ref expressionStack)) |
                                special is Special.Stop) // <- future //
                                ) expressionStack.Add(special);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            private class ModifierStack
            {
                public enum Operand
                {
                    Binary,
                    Sign
                }

                private readonly ArrayList modifierStack = new ArrayList();

                private void BuildStack(ref List<Object> expStack)
                {
                    foreach (Object obj in expStack)
                    {
                        switch (obj)
                        {
                            case Modifier modifier: 
                                {
                                    if (
                                        modifier is Modifier.XPowerOfY |
                                        modifier is Modifier.LogarithmOfXBasedOnY |
                                        modifier is Modifier.YRootOfX
                                        ) SetModifier(Operand.Binary);
                                    else SetModifier(Operand.Sign); 
                                    break;
                                }
                            case Special special:
                                {
                                    if (special is Special.Next) SetNext();
                                    else if (special is Special.End) SetEnd();
                                    break;
                                }
                        }
                    }
                }
                public void SetModifier(Operand operand)
                {
                    if (operand is Operand.Sign) modifierStack.Add(new ModifierOneParameter());
                    else if (operand is Operand.Binary) modifierStack.Add(new ModifierTwoParameters());
                }
                private void SetNext()
                {
                    GetFirstNeedNext().Set();
                }

                public Boolean CanSetNext(ref List<Object> expStack)
                {
                    BuildStack(ref expStack);
                    Boolean result = FindFirstNeedNext();
                    modifierStack.Clear();
                    return result;
                }
                private ModifierWithParameters GetFirstNeedNext()
                {
                    foreach (ModifierWithParameters modifier in modifierStack)
                    {
                        if (
                            (modifier is ModifierOneParameter & modifier.GetNeed() > 0) |
                            (modifier is ModifierTwoParameters & modifier.GetNeed() == 2)
                            ) return modifier;
                    }
                    return (ModifierWithParameters)modifierStack[modifierStack.Count - 1];
                }

                private Boolean FindFirstNeedNext()
                {
                    foreach (ModifierWithParameters modifier in modifierStack)
                    {
                        if (
                            (modifier is ModifierTwoParameters & modifier.GetNeed() == 2)
                            ) return true;
                    }
                    return false;
                }

                private void SetEnd()
                {
                    GetFirstNeedEnd().Set();
                }

                public Boolean CanSetEnd(ref List<Object> expStack)
                {
                    BuildStack(ref expStack);
                    Boolean result = FindFirstNeedEnd();
                    modifierStack.Clear();
                    return result;
                }

                private ModifierWithParameters GetFirstNeedEnd()
                {
                    foreach (ModifierWithParameters modifier in modifierStack)
                    {
                        if (modifier is ModifierTwoParameters)
                        {
                            if (modifier.GetNeed() == 1) return modifier;
                        }
                    }
                    return (ModifierWithParameters)modifierStack[modifierStack.Count - 1];
                }

                private Boolean FindFirstNeedEnd()
                {
                    foreach (ModifierWithParameters modifier in modifierStack)
                    {
                        {
                            if (modifier.GetNeed() == 1) return true;
                        }
                    }
                    return false;
                }

                private abstract class ModifierWithParameters
                {
                    public abstract void Set();

                    public abstract Int16 GetNeed();
                }

                private class ModifierOneParameter : ModifierWithParameters
                {
                    private Boolean end = false;

                    public override void Set() => end = true;

                    public override Int16 GetNeed() => (Int16)(end == true ? 0 : 1);
                }
                private class ModifierTwoParameters : ModifierWithParameters
                {
                    private Boolean next = false;
                    private Boolean end = false;

                    public override void Set()
                    {
                        if (next == false) next = true;
                        else if (end == false) end = true;
                    }

                    public override Int16 GetNeed()
                    {
                        if (next == true & end == true) return 0;
                        else if (next == true & end == false) return 1;
                        else if (next == false & end == false) return 2;
                        return 0;
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
                    case Constant constant:
                        {
                            Last = GetConstant(constant).ToString();
                            Last = ((String)Last).Remove(((String)Last).Length - 1);
                            goto default;
                        }
                    case Operation _:
                        {
                            expressionStack.RemoveAt(expressionStack.Count - 1);
                            goto default;
                        }
                    case Modifier _:
                        {
                            expressionStack.RemoveAt(expressionStack.Count - 1);
                            goto default;
                        }
                    case Special _:
                        {
                            expressionStack.RemoveAt(expressionStack.Count - 1);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke();
                            break;
                        }
                }
            }

            public static void Calculate(ExpressionStack expStack)
            {
                if (expStack.Count == 0 || expStack.Last is Operation | expStack.Last is Modifier) { return; }

                //modifier calculate--------------------------------------------//

                if (!(expStack.expressionStack.Count(x => x is Modifier) == expStack.expressionStack.Count(x => x is Special.End))) return;


                //--------------------------------------------------------------//

                //operation calculate-------------------------------------------//
                var operationsLINQ =
                    from obj in expStack.expressionStack
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
                        (value1, value2) = ValuesCapture(operation);
                        if (operation is Operation.Add) result = OperationPerforming(value1, value2, (d1, d2) => d1 + d2, (i1, i2) => i1 + i2);
                        else if (operation is Operation.Subtrack) result = OperationPerforming(value1, value2, (d1, d2) => d1 - d2, (i1, i2) => i1 - i2);
                        else if (operation is Operation.Multiply) result = OperationPerforming(value1, value2, (d1, d2) => d1 * d2, (i1, i2) => i1 * i2);
                        else if (operation is Operation.Division) result = Division(value1, value2);
                        else if (operation is Operation.Modular) result = Modular(value1, value2);
                    }
                    catch (DivideByZeroException)
                    {
                        expStack.Clear();
                        break;
                    }

                    expStack.expressionStack[expStack.expressionStack.IndexOf(operation)] = result;
                }
                //--------------------------------------------------------------//

                expStack.Change.Invoke();

                (String, String) ValuesCapture(Operation operation)
                {
                    Int16 index0 = (Int16)expStack.expressionStack.IndexOf(operation);
                    Int16 index1 = (Int16)(index0 - 1);
                    Int16 index2 = (Int16)(index0 + 1);
                    String value1 = (String)expStack.expressionStack[index1];
                    String value2 = (String)expStack.expressionStack[index2];
                    expStack.expressionStack.RemoveAt(index2);
                    expStack.expressionStack.RemoveAt(index1);

                    return (value1, value2); 
                }

                String ModifierCapture(Int32 index)
                {

                }

                String OperationPerforming(String value1, String value2, Expression<Double> expressionDouble, Expression<Int64> expressionInt)
                {
                    if (IsFloat(value1) | IsFloat(value2)) return expressionDouble(Double.Parse(value1), Double.Parse(value2)).ToString();
                    return expressionInt(Int64.Parse(value1), Int64.Parse(value2)).ToString();
                }

                String Modular(String value1, String value2)
                {
                    if (IsZero(value2)) return value1;
                    return OperationPerforming(value1, value2, (d1, d2) => d1 % d2, (i1, i2) => i1 % i2);
                }

                String Division(String value1, String value2)
                {
                    if (IsZero(value2)) { expStack.RaiseErrorDialogZeroDivision(); throw new DivideByZeroException(); }

                    String result = (Double.Parse(value1) / Double.Parse(value2)).ToString();
                    if (IsFloat(result)) return result;
                    return result.Split(',')[0];
                }

                Boolean IsFloat(String value)
                {
                    if (value.Contains(",") && value.Split(',')[1] != String.Empty) return true;
                    return false;
                }

                Boolean IsZero(String value)
                {
                    if ((value.Count(x => x == '0') + value.Count(x => x == ',')) == value.Length) return true;
                    return false;
                }
            }

            delegate T Expression<T>(T value1, T value2);

            public void ToFloat()
            {
                if (Count == 0 || !(Last is String) || ((String)Last).Contains(",")) { return; }

                Last = ((String)Last) + ",";

                Change.Invoke();

            }

            public void ChangeSign()
            {
                if (Count == 0 || Last is Operation | Last is Modifier | Last is Special) { return; }

                if (Last is Constant) Last = GetConstant((Constant)Last).ToString();

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
                        case Constant constant: { yield return ConstantDictionary[constant]; continue; }
                        case Operation operation: { yield return OperationDictionary[operation]; continue; }
                        case Modifier modifier: { yield return ModifierDictionary[modifier]; continue; }
                        case Special special: { yield return SpecialDictionary[special]; continue; }
                    }
                }
            }

            public void Clear() { expressionStack.Clear(); Change.Invoke(); }

            public void ClearElement() { expressionStack.RemoveAt(expressionStack.Count - 1); Change.Invoke(); }

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
        }

        private void buttonSecondFunctionalityTrigonometry_Click(object sender, EventArgs e)
        {
            new Thread(ChangeFunctionTrigonometry).Start();
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