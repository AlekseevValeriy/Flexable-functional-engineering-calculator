namespace EngineeringCalculator
{
    internal static class Output
    {
        public const String SEPARATOR = " ";

        private static List<Composite> fullExpression = new List<Composite>();

        public static String ExprassionToRecord(ref List<Composite> expression, Boolean debug)
        {
            

            fullExpression.Clear();

            Output.ReadExpression(ref expression);

            List<String> record = new List<String>();

            foreach (Composite composite in fullExpression) record.Add(composite.Record);


            String separator = debug ? " | " : SEPARATOR;

            return String.Join(separator, record);
        }

        public static void ReadExpression(ref List<Composite> expression)
        {
            if (expression.Count == 0) return;
            foreach (Composite composite in expression)
            {
                switch (composite)
                {
                    case BinaryFunction binaryFunction:
                        {
                            fullExpression.Add(binaryFunction);
                            fullExpression.Add(new VisualStaple("("));
                            Output.ReadExpression(ref binaryFunction.GetFirstExpression());
                            fullExpression.Add(new Comma());
                            Output.ReadExpression(ref binaryFunction.GetSecondExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case SingularFunction singularFunction:
                        {
                            fullExpression.Add(singularFunction);
                            fullExpression.Add(new VisualStaple("("));
                            Output.ReadExpression(ref singularFunction.GetExpression());
                            fullExpression.Add(new VisualStaple(")"));
                            break;
                        }
                    case Staples staples:
                        {
                            fullExpression.Add(new VisualStaple("("));
                            Output.ReadExpression(ref staples.GetExpression());
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
        public static String GetActualExpression(ref List<Composite> expression)
        {
            return $"{expression.GetType()}";
        }
    }

}
