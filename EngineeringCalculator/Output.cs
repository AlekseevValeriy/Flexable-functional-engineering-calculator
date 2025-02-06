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
            foreach (Composite composite in expression)
            {
                switch (composite)
                {
                    case BinaryFunction binaryFunction: 
                        {
                            Output.ReadExpression(ref binaryFunction.GetFirstExpression());
                            expression.Add(new Comma());
                            Output.ReadExpression(ref binaryFunction.GetSecondExpression());
                            break;
                        }
                    case SingularFunction singularFunction:
                        {
                            Output.ReadExpression(ref singularFunction.GetExpression());
                            break;
                        }
                    case Staples staples:
                        {
                            Output.ReadExpression(ref staples.GetExpression());
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
    }
}
