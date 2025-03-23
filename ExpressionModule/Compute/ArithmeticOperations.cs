using static System.Math;

namespace FFEC
{
    internal static class ArithmeticOperationsAdapter
    {
        public static Operation GetOperation(OperatorMark mark) => operators[mark];
        private static Dictionary<OperatorMark, Operation> operators = new Dictionary<OperatorMark, Operation>()
        {
            { OperatorMark.Add, ArithmeticOperations.Add},
            { OperatorMark.Subtract, ArithmeticOperations.Subtract},
            { OperatorMark.Multiply, ArithmeticOperations.Multiply},
            { OperatorMark.Division, ArithmeticOperations.Division},
            { OperatorMark.Modular, ArithmeticOperations.Modular}
        };
        public delegate Double Operation(Double x, Double y);

        public static PerformBinary GetOperation(BinaryFunctionMark mark) => binaryFunctions[mark.Field];
        private static Dictionary<FunctionMark, PerformBinary> binaryFunctions = new Dictionary<FunctionMark, PerformBinary>()
        {
            { FunctionMark.XPowerOfY, ArithmeticOperations.XPowerOfY},
            { FunctionMark.LogarithmOfXBasedOnY, ArithmeticOperations.LogarithmOfXBasedOnY},
            { FunctionMark.YRootOfX, ArithmeticOperations.YRootOfX}
        };
        public delegate Double PerformBinary(Double x, Double y);

        public static PerformSingular GetOperation(SingularFunctionMark mark) => singularFunctions[mark.Field];
        private static Dictionary<FunctionMark, PerformSingular> singularFunctions = new Dictionary<FunctionMark, PerformSingular>()
        {
            { FunctionMark.NaturalLogarithm, ArithmeticOperations.NaturalLogarithm},
            { FunctionMark.DecimalLogarithm, ArithmeticOperations.DecimalLogarithm},
            { FunctionMark.TenPowerOfX, ArithmeticOperations.TenPowerOfX},
            { FunctionMark.SquareRootOfX, ArithmeticOperations.SquareRootOfX},
            { FunctionMark.XPowerOfTwo, ArithmeticOperations.XPowerOfTwo},
            { FunctionMark.EPowerOfX, ArithmeticOperations.EPowerOfX},
            { FunctionMark.TwoPowerOfX, ArithmeticOperations.TwoPowerOfX},
            { FunctionMark.CubicRootOfX, ArithmeticOperations.CubicRootOfX},
            { FunctionMark.XPowerOfThree, ArithmeticOperations.XPowerOfThree},
            { FunctionMark.XReverse, ArithmeticOperations.XReverse},
            { FunctionMark.XAbsolute, ArithmeticOperations.XAbsolute},
            { FunctionMark.Exponential, ArithmeticOperations.Exponential},
            { FunctionMark.NFactorial, ArithmeticOperations.NFactorial},
        };
        public delegate Double PerformSingular(Double x);
    }

    internal static class ArithmeticOperations
    {
        public static Double Add(Double x, Double y) => x + y;
        public static Double Subtract(Double x, Double y) => x - y;
        public static Double Multiply(Double x, Double y) => x * y;
        public static Double Division(Double x, Double y) => x / y;
        public static Double Modular(Double x, Double y) => x % y;
        public static Double XPowerOfY(Double x, Double y) => Pow(x, y);
        public static Double LogarithmOfXBasedOnY(Double x, Double y) => Log(x, y);
        public static Double YRootOfX(Double x, Double y) => Pow(x, (1D / y));
        public static Double NaturalLogarithm(Double x) => Log(x);
        public static Double DecimalLogarithm(Double x) => Log10(x);
        public static Double TenPowerOfX(Double x) => Pow(10D, x);
        public static Double SquareRootOfX(Double x) => Sqrt(x);
        public static Double XPowerOfTwo(Double x) => Pow(x, 2D);
        public static Double EPowerOfX(Double x) => Pow(E, x);
        public static Double TwoPowerOfX(Double x) => Pow(2D, x);
        public static Double CubicRootOfX(Double x) => Pow(x, (1D / 3D));
        public static Double XPowerOfThree(Double x) => Pow(x, 3D);
        public static Double XReverse(Double x) => 1D / x;
        public static Double XAbsolute(Double x) => Abs(x);
        public static Double Exponential(Double x) => Pow(E, x);
        public static Double NFactorial(Double x)
        {
            Double factorial = 1;
            for (UInt64 I = 1; I <= x; I++)
            { factorial *= I; }
            return factorial;
        }
    }
}
