using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace EngineeringCalculator
{
    public partial class Form1 : Form
    {
        private ExpressionStack expStack = new ExpressionStack();
        private static Dictionary<Operators, String> operatorsDictionary = new Dictionary<Operators, String>();

        private enum Operators
        {
            Add,
            Subtrack,
            Multiply,
            Division
        }

        public Form1()
        {
            InitializeComponent();
            expStack.Change += ExpressionViewChange;
            FillDictionary();
        }

        private static void FillDictionary()
        {
            operatorsDictionary.Add(Operators.Add, "+");
            operatorsDictionary.Add(Operators.Subtrack, "-");
            operatorsDictionary.Add(Operators.Multiply, "*");
            operatorsDictionary.Add(Operators.Division, "/");
        }

        private void ExpressionViewChange(ref List<Object> expression)
        {
            Result.Text = String.Join(" ", expStack.TextView());
        }

	    private void Form1_Load(object sender, EventArgs e)
        {

        }

        private class ExpressionStack
        {
            public delegate void ExpressionHandler(ref List<Object> expression);
            public event ExpressionHandler Change;
            private List<Object> expressionStack = new List<Object>(); // contains String and Operators

            public void Add(String value)
            {
                if (expressionStack.Count() == 0) { expressionStack.Add(value); Change.Invoke(ref expressionStack); return; }
                switch (expressionStack.Last())
                {
                    case String number:
                        {
                            expressionStack[expressionStack.Count - 1] = (Object)(number + value);
                            goto default;
                        }
                    case Operators _:
                        {
                            expressionStack.Add(value);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke(ref expressionStack);
                            break;
                        }
                }
            }

            public void Add(Operators operation)
            {
                if (expressionStack.Count() == 0) { expressionStack.Add(operation); Change.Invoke(ref expressionStack); return; }
                switch (expressionStack.Last())
                {
                    case String number:
                        {
                            expressionStack.Add(operation);
                            goto default;
                        }
                    case Operators _:
                        {
                            expressionStack[expressionStack.Count - 1] = (Object)(operation);
                            goto default;
                        }
                    default:
                        {
                            Change.Invoke(ref expressionStack);
                            break;
                        }
                }
            }

            public IEnumerable<String> TextView()
            {
                foreach (Object obj in expressionStack.AsEnumerable().Reverse())
                {
                    switch (obj)
                    {
                        case String value: { yield return value; continue; }
                        case Operators operation: { yield return operatorsDictionary[operation]; continue; }
                    }
                }
            }
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            expStack.Add("1");
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
            expStack.Add(Operators.Add);
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            expStack.Add(Operators.Subtrack);
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            expStack.Add(Operators.Multiply);
        }

        private void buttonDivision_Click(object sender, EventArgs e)
        {
            expStack.Add(Operators.Division);
        }
    }
}
