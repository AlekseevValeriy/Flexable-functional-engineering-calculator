namespace FFEC
{
    internal static class Output
    {
        public const string SEPARATOR = " ";
        private const string BUNDLE = "~";

        private static readonly List<Composite> fullExpression = [];

        #region Converter expression to record

        public static string ExpressionToRecord(List<Composite> expression, bool debug = false)
        {
            return ExpressionToAny(expression, ExpressionDisclosureToRecord, (composite) => composite.Record, debug);
        }
        private static void ExpressionDisclosureToRecord(List<Composite> expression)
        {
            if (expression.Count == 0)
            {
                return;
            }

            foreach (Composite composite in expression)
            {
                switch (composite)
                {
                    case BinaryFunction binaryFunction:
                        {
                            fullExpression.Add(binaryFunction);
                            fullExpression.Add(new VisualStaple("("));
                            Output.ExpressionDisclosureToRecord(binaryFunction.GetFirstExpression());
                            fullExpression.Add(new Comma());
                            Output.ExpressionDisclosureToRecord(binaryFunction.GetSecondExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case SingularFunction singularFunction:
                        {
                            fullExpression.Add(singularFunction);
                            fullExpression.Add(new VisualStaple("("));
                            Output.ExpressionDisclosureToRecord(singularFunction.GetExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case Staples staples:
                        {
                            fullExpression.Add(new VisualStaple("("));
                            Output.ExpressionDisclosureToRecord(staples.GetExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    default:
                        {
                            fullExpression.Add(composite);
                            break;
                        }
                }
            }
        }

        #endregion

        #region Converter expression to manual

        public static string ExpressionToManual(List<Composite> expression, bool debug = false)
        {
            return ExpressionToAny(expression, ExpressionDisclosureToManual, CompositeToTypeDataRecord, debug, ";");
        }
        private static string CompositeToTypeDataRecord(Composite composite)
        {
            return composite.GetType().ToString().Remove(0, 5) + composite switch
            {
                Term or Constanta or Variable => $"{BUNDLE}{composite.Record}",
                Operator oper => $"{BUNDLE}{oper.GetMark}",
                Function func => $"{BUNDLE}{func.GetMark}",
                _ => ""
            };
        }

        private static void ExpressionDisclosureToManual(List<Composite> expression)
        {
            if (expression.Count == 0)
            {
                return;
            }

            foreach (Composite composite in expression)
            {
                switch (composite)
                {
                    case BinaryFunction binaryFunction:
                        {
                            fullExpression.Add(binaryFunction);
                            ExpressionDisclosureToManual(binaryFunction.GetFirstExpression());
                            fullExpression.Add(new VisualEnd("|"));
                            ExpressionDisclosureToManual(binaryFunction.GetSecondExpression());
                            fullExpression.Add(new VisualEnd("|"));
                            break;
                        }
                    case SingularFunction singularFunction:
                        {
                            fullExpression.Add(singularFunction);
                            ExpressionDisclosureToManual(singularFunction.GetExpression());
                            fullExpression.Add(new VisualEnd("|"));
                            break;
                        }
                    case Staples staples:
                        {
                            fullExpression.Add(staples);
                            ExpressionDisclosureToManual(staples.GetExpression());
                            fullExpression.Add(new VisualEnd("|"));
                            break;
                        }
                    default:
                        {
                            fullExpression.Add(composite);
                            break;
                        }
                }
            }
        }

        #endregion

        private static string ExpressionToAny(List<Composite> expression, Action<List<Composite>> attachmentsDisclosure, Func<Composite, string> transformationToAny, bool debug = false, string separation = null)
        {
            fullExpression.Clear();

            attachmentsDisclosure(expression);

            List<string> record = [];

            foreach (Composite composite in fullExpression)
            {
                record.Add(transformationToAny(composite));
            }

            string separator = debug ? " | " : separation ?? SEPARATOR;

            return string.Join(separator, record);
        }
    }

    internal static class OutputView
    {
        public static string GetViewByMark(OperatorMark mark) => mark switch
        {
            OperatorMark.Add => "+",
            OperatorMark.Subtract => "-",
            OperatorMark.Multiply => "×",
            OperatorMark.Division => "÷",
            OperatorMark.Modular => "mod"
        };

        public static string GetViewByMark(FunctionMark mark) => mark switch
        {
            FunctionMark.NaturalLogarithm => "ln",
            FunctionMark.EPowerOfX => "ePower",
            FunctionMark.DecimalLogarithm => "lg",
            FunctionMark.LogarithmOfXBasedOnY => "log",
            FunctionMark.TenPowerOfX => "tenPower",
            FunctionMark.TwoPowerOfX => "twoPower",
            FunctionMark.XPowerOfY => "power",
            FunctionMark.YRootOfX => "root",
            FunctionMark.XPowerOfTwo => "powerOfTwo",
            FunctionMark.XPowerOfThree => "powerOfThree",
            FunctionMark.SquareRootOfX => "squareRoot",
            FunctionMark.CubicRootOfX => "cubicRoot",
            FunctionMark.XReverse => "reverse",
            FunctionMark.XAbsolute => "abs",
            FunctionMark.Exponential => "exp",
            FunctionMark.NFactorial => "factorial"
        };
    }

}
