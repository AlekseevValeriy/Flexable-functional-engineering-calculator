namespace FFEC
{
    internal static class Output
    {
        public const string SEPARATOR = " ";

        private static readonly List<Composite> fullExpression = [];

        public static string ExpressionToRecord(List<Composite> expression, bool debug = false)
        {
            return ExpressionToAny(expression, Output.ReadExpression, (composite) => composite.Record, debug);
        }
        private static void ReadExpression(List<Composite> expression)
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
                            Output.ReadExpression(binaryFunction.GetFirstExpression());
                            fullExpression.Add(new Comma());
                            Output.ReadExpression(binaryFunction.GetSecondExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case SingularFunction singularFunction:
                        {
                            fullExpression.Add(singularFunction);
                            fullExpression.Add(new VisualStaple("("));
                            Output.ReadExpression(singularFunction.GetExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case Staples staples:
                        {
                            fullExpression.Add(new VisualStaple("("));
                            Output.ReadExpression(staples.GetExpression());
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

        public static string ExpressionToManual(List<Composite> expression, bool debug = false)
        {
            return ExpressionToAny(expression, Output.ReadExpression, CompositeToTypeDataRecord, debug, ";");
        }
        private static string CompositeToTypeDataRecord(Composite composite)
        {
            return composite switch
            {
                Term or Constanta => $"{composite.GetType()} {{{composite.Record}}}",
                Operator oper => $"{composite.GetType()} {{{oper.GetMark}}}",
                Comma => $"{composite.GetType()}",
                Variable wario => $"{composite.GetType()} {{{wario.Record}, {wario.GetValue()}}}"
            };
        }


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

}
