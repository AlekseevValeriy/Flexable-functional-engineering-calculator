namespace EngineeringCalculator
{
    internal static class Visual
    {
        public static readonly Dictionary<Operation, String> OperationDictionary = new Dictionary<Operation, String>();
        public static readonly Dictionary<Modifier, String> ModifierDictionary = new Dictionary<Modifier, String>();
        public static readonly Dictionary<Constant, String> ConstantDictionary = new Dictionary<Constant, String>();
        public static readonly Dictionary<Special, String> SpecialDictionary = new Dictionary<Special, String>();

        public static String ExpressionToString(ref List<Object> expressionStack)
        {
            return String.Join(" ", ConvertToString(expressionStack));
        }

        public static String DebugExpressionToString(ref List<Object> expressionStack)
        {
            List<String> expression = ConvertToString(expressionStack).ToList<String>();

            for (int i = 0; i < expression.Count; i++)
            {
                expression[i] = $"'{expression[i]}'";
            }
            return String.Join(" ", expression);
        }

        private static IEnumerable<String> ConvertToString(List<Object> expressionStack)
        {
            foreach (Object obj in expressionStack) yield return obj switch
            {
                String value => value,
                Constant constant => ConstantDictionary[constant],
                Operation operation => OperationDictionary[operation],
                Modifier modifier => ModifierDictionary[modifier],
                Special special => SpecialDictionary[special]
            }; 
        }

        public static void FillDictionary()
        {
            OperationDictionary.Add(Operation.Add, "+");
            OperationDictionary.Add(Operation.Subtrack, "-");
            OperationDictionary.Add(Operation.Multiply, "×");
            OperationDictionary.Add(Operation.Division, "÷");
            OperationDictionary.Add(Operation.Modular, "mod");
            ModifierDictionary.Add(Modifier.NaturalLogarithm, "ln");
            ModifierDictionary.Add(Modifier.DecimalLogarithm, "lg");
            ModifierDictionary.Add(Modifier.TenPowerOfX, "tenPower");
            ModifierDictionary.Add(Modifier.XPowerOfY, "power");
            ModifierDictionary.Add(Modifier.SquareRootOfX, "squareRoot");
            ModifierDictionary.Add(Modifier.XPowerOfTwo, "powerOfTwo");
            ModifierDictionary.Add(Modifier.EPowerOfX, "ePower");
            ModifierDictionary.Add(Modifier.LogarithmOfXBasedOnY, "log");
            ModifierDictionary.Add(Modifier.TwoPowerOfX, "twoPower");
            ModifierDictionary.Add(Modifier.YRootOfX, "root");
            ModifierDictionary.Add(Modifier.CubicRootOfX, "cubicRoot");
            ModifierDictionary.Add(Modifier.XPowerOfThree, "powerOfThree");
            ModifierDictionary.Add(Modifier.XReverse, "reverse");
            ModifierDictionary.Add(Modifier.XAbsolute, "abs");
            ModifierDictionary.Add(Modifier.Exponential, "exp");
            ModifierDictionary.Add(Modifier.NFactorial, "factorial");
            ConstantDictionary.Add(Constant.Pi, PI.ToString());
            ConstantDictionary.Add(Constant.E, E.ToString());
            SpecialDictionary.Add(Special.Next, ",");
            SpecialDictionary.Add(Special.End, ".");
            SpecialDictionary.Add(Special.Start, "(");
            SpecialDictionary.Add(Special.Stop, ")");
        }

    }
}
