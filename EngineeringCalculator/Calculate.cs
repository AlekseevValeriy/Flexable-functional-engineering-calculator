using static System.Math;

namespace EngineeringCalculator
{
    // actions of the first stage -> functions and staples
    // actions of the second stage -> operators
    internal static class Calculate
    {
        public static Operation GetPerformAction(OperatorMark mark) => operatorActions[mark];
        private static Dictionary<OperatorMark, Operation> operatorActions = new Dictionary<OperatorMark, Operation>
        {
            { OperatorMark.Add, (x, y) => x + y},
            { OperatorMark.Subtrack, (x, y) => x - y},
            { OperatorMark.Multiply, (x, y) => x * y},
            { OperatorMark.Division, (x, y) => x / y},
            { OperatorMark.Modular, (x, y) => x % y}
        };
        public delegate Double Operation(Double x, Double y);

        public static PerformBinary GetPerformAction(BinaryFunctionMark mark) => binaryFunctionActions[mark.Field];
        private static Dictionary<FunctionMark, PerformBinary> binaryFunctionActions = new Dictionary<FunctionMark, PerformBinary>
        {
            { FunctionMark.XPowerOfY, (x, y) => Pow(x, y)},
            { FunctionMark.LogarithmOfXBasedOnY, (x, y) => Log(x, y)},
            { FunctionMark.YRootOfX, (x, y) => Pow(x, 1 / y)}
        };
        public delegate Double PerformBinary(Double x, Double y);

        public static PerformSingular GetPerformAction(SingularFunctionMark mark) => singularFunctionActions[mark.Field];
        private static Dictionary<FunctionMark, PerformSingular> singularFunctionActions = new Dictionary<FunctionMark, PerformSingular>
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
            { FunctionMark.XReverse, (x) => x * -1},
            { FunctionMark.XAbsolute, (x) => Abs(x)},
            { FunctionMark.Exponential, (x) => Pow(E, x)},
            { FunctionMark.NFactorial, (x) => { UInt64 F = 1; for (UInt64 I = 1; I <= x; I++) F *= I; return (Double)F; } },
        };
        public delegate Double PerformSingular(Double x);

        public static Composite SolutionEquation(ref List<Composite> expression)
        {
            // TODO
            return new Composite();
        }
    }
}
