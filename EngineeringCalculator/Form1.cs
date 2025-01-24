using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace EngineeringCalculator
{
    public partial class Form1 : Form
    {
        private ExpressionStack expStack = new ExpressionStack();
        private static Dictionary<Operation, String> OperationDictionary = new Dictionary<Operation, String>();

        private enum Operation
        {
            Add = 0,
            Subtrack = 0,
            Multiply = 1,
            Division = 1
        }

        public Form1()
        {
            InitializeComponent();
             expStack.Change += ExpressionViewChange;
            //expStack.Change += DebugExpressionViewChange;
            FillDictionary();
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


        private void Form1_Load(object sender, EventArgs e)
        {

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
                                if (value != "0") Last = (Object)value;
                                else { }
                            }
                            else Last = (Object)(number + value);
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
                            Last = (Object)(value);
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
                if (Count == 0) { expressionStack.Add(operation);  Change.Invoke(); return; }
                switch (Last)
                {
                    case String number:
                        {
                            expressionStack.Add(operation);
                            goto default;
                        }
                    case Operation _:
                        {
                            Last = (Object)(operation);
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
                            else { Last = number.Remove(number.Length - 1); }
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

            public Int32 CountOf(Object obj) => expressionStack.Count(x => x == obj);

            public void Calculate()
            {
                Dictionary<Int32, Operation> operations = new Dictionary<Int32, Operation>();
                for (Int32 I = 0; I < Count; I++)
                {
                    if (expressionStack[I] is Operation) operations[I] = (Operation)expressionStack[I];
                }
                var order =
                    from operation in operations
                    orderby (Int32)operation.Value, operation.Key
                    select new { Operation = operation.Value, Index = operation.Key };
                foreach (var operation in order)
                {
                    //
                }

            }

            public IEnumerable<String> TextView()
            {
                foreach (Object obj in expressionStack.AsEnumerable().Reverse())
                {
                    switch (obj)
                    {
                        case String value: { yield return value; continue; }
                        case Operation operation: { yield return OperationDictionary[operation]; continue; }
                    }
                }
            }

            public void Clear() { expressionStack.Clear(); Change.Invoke(); }
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
    }
}
