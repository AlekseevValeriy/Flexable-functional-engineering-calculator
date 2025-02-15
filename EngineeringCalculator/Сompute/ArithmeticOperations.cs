using static System.Math;

namespace EngineeringCalculator
{
    internal static class ArithmeticOperations
    {
        //static ArithmeticOperations()
        //{
        //    operatorActions.Add(OperatorMark.Add, (x, y) => x + y);
        //    operatorActions.Add(OperatorMark.Subtrack, (x, y) => x - y);
        //    operatorActions.Add(OperatorMark.Multiply, (x, y) => x * y);
        //    operatorActions.Add(OperatorMark.Division, (x, y) => x / y);
        //    operatorActions.Add(OperatorMark.Modular, (x, y) => x % y);

        //    binaryFunctionActions.Add(FunctionMark.XPowerOfY, (x, y) => Pow(x, y));
        //    binaryFunctionActions.Add(FunctionMark.LogarithmOfXBasedOnY, (x, y) => Log(x, y));
        //    binaryFunctionActions.Add(FunctionMark.YRootOfX, (x, y) => Pow(x, 1 / y));

        //    singularFunctionActions.Add(FunctionMark.NaturalLogarithm, (x) => Log(x));
        //    singularFunctionActions.Add(FunctionMark.DecimalLogarithm, (x) => Log10(x));
        //    singularFunctionActions.Add(FunctionMark.TenPowerOfX, (x) => Pow(10, x));
        //    singularFunctionActions.Add(FunctionMark.SquareRootOfX, (x) => Sqrt(x));
        //    singularFunctionActions.Add(FunctionMark.XPowerOfTwo, (x) => Pow(x, 2));
        //    singularFunctionActions.Add(FunctionMark.EPowerOfX, (x) => Pow(E, x));
        //    singularFunctionActions.Add(FunctionMark.TwoPowerOfX, (x) => Pow(2, x));
        //    singularFunctionActions.Add(FunctionMark.CubicRootOfX, (x) => Pow(x, 1 / 3));
        //    singularFunctionActions.Add(FunctionMark.XPowerOfThree, (x) => Pow(x, 3));
        //    singularFunctionActions.Add(FunctionMark.XReverse, (x) => x * -1);
        //    singularFunctionActions.Add(FunctionMark.XAbsolute, (x) => Abs(x));
        //    singularFunctionActions.Add(FunctionMark.Exponential, (x) => Pow(E, x));
        //    singularFunctionActions.Add(FunctionMark.NFactorial, (x) => { UInt64 F = 1; for (UInt64 I = 1; I <= x; I++) F *= I; return (Double)F; });
        //}

        public static Operation GetPerformAction(OperatorMark mark) => operatorActions[mark];
        private static Dictionary<OperatorMark, Operation> operatorActions = new Dictionary<OperatorMark, Operation>()
        {
            { OperatorMark.Add, (x, y) => x + y},
            { OperatorMark.Subtrack, (x, y) => x - y},
            { OperatorMark.Multiply, (x, y) => x * y},
            { OperatorMark.Division, (x, y) => x / y},
            { OperatorMark.Modular, (x, y) => x % y}
        };
        public delegate Double Operation(Double x, Double y);

        public static PerformBinary GetPerformAction(BinaryFunctionMark mark) => binaryFunctionActions[mark.Field];
        private static Dictionary<FunctionMark, PerformBinary> binaryFunctionActions = new Dictionary<FunctionMark, PerformBinary>()
        {
            { FunctionMark.XPowerOfY, (x, y) => Pow(x, y)},
            { FunctionMark.LogarithmOfXBasedOnY, (x, y) => Log(x, y)},
            { FunctionMark.YRootOfX, (x, y) => Pow(x, 1 / y)}
        };
        public delegate Double PerformBinary(Double x, Double y);

        public static PerformSingular GetPerformAction(SingularFunctionMark mark) => singularFunctionActions[mark.Field];
        private static Dictionary<FunctionMark, PerformSingular> singularFunctionActions = new Dictionary<FunctionMark, PerformSingular>()
        {
            { FunctionMark.NaturalLogarithm, (x) => Log(x)},
            { FunctionMark.DecimalLogarithm, (x) => Log10(x)},
            { FunctionMark.TenPowerOfX, (x) => Pow(10, x)},
            { FunctionMark.SquareRootOfX, (x) => Sqrt(x)},
            { FunctionMark.XPowerOfTwo, (x) => Pow(x, 2)},
            { FunctionMark.EPowerOfX, (x) => Pow(E, x)},
            { FunctionMark.TwoPowerOfX, (x) => Pow(2, x)},
            { FunctionMark.CubicRootOfX, (x) => Pow(x, 1 / 3)},
            { FunctionMark.XPowerOfThree, (x) => Pow(x, 3)},
            { FunctionMark.XReverse, (x) => 1 / x},
            { FunctionMark.XAbsolute, (x) => Abs(x)},
            { FunctionMark.Exponential, (x) => Pow(E, x)},
            { FunctionMark.NFactorial, (x) => { UInt64 F = 1; for (UInt64 I = 1; I <= x; I++) F *= I; return (Double)F; } },
        };
        public delegate Double PerformSingular(Double x);
    }
}
