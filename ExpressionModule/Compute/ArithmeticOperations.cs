using static System.Math;

namespace FFEC
{
    internal static class ArithmeticOperationsAdapter
    {
        public static Operation GetOperation(OperatorMark mark)
        {
            return operators[mark];
        }

        private static readonly Dictionary<OperatorMark, Operation> operators = new Dictionary<OperatorMark, Operation>()
        {
            { OperatorMark.Add, ArithmeticOperations.Add},
            { OperatorMark.Subtract, ArithmeticOperations.Subtract},
            { OperatorMark.Multiply, ArithmeticOperations.Multiply},
            { OperatorMark.Division, ArithmeticOperations.Division},
            { OperatorMark.Modular, ArithmeticOperations.Modular}
        };
        public delegate double Operation(double x, double y);

        public static PerformBinary GetOperation(BinaryFunctionMark mark)
        {
            return binaryFunctions[mark.Field];
        }

        private static readonly Dictionary<FunctionMark, PerformBinary> binaryFunctions = new Dictionary<FunctionMark, PerformBinary>()
        {
            { FunctionMark.XPowerOfY, ArithmeticOperations.XPowerOfY},
            { FunctionMark.LogarithmOfXBasedOnY, ArithmeticOperations.LogarithmOfXBasedOnY},
            { FunctionMark.YRootOfX, ArithmeticOperations.YRootOfX}
        };
        public delegate double PerformBinary(double x, double y);

        public static PerformSingular GetOperation(SingularFunctionMark mark)
        {
            return singularFunctions[mark.Field];
        }

        private static readonly Dictionary<FunctionMark, PerformSingular> singularFunctions = new Dictionary<FunctionMark, PerformSingular>()
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
        public delegate double PerformSingular(double x);
    }

    internal static class ArithmeticOperations
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Division(double x, double y)
        {
            return x / y;
        }

        public static double Modular(double x, double y)
        {
            return x % y;
        }

        public static double XPowerOfY(double x, double y)
        {
            return Pow(x, y);
        }

        public static double LogarithmOfXBasedOnY(double x, double y)
        {
            return Log(x, y);
        }

        public static double YRootOfX(double x, double y)
        {
            return Pow(x, 1D / y);
        }

        public static double NaturalLogarithm(double x)
        {
            return Log(x);
        }

        public static double DecimalLogarithm(double x)
        {
            return Log10(x);
        }

        public static double TenPowerOfX(double x)
        {
            return Pow(10D, x);
        }

        public static double SquareRootOfX(double x)
        {
            return Sqrt(x);
        }

        public static double XPowerOfTwo(double x)
        {
            return Pow(x, 2D);
        }

        public static double EPowerOfX(double x)
        {
            return Pow(E, x);
        }

        public static double TwoPowerOfX(double x)
        {
            return Pow(2D, x);
        }

        public static double CubicRootOfX(double x)
        {
            return Pow(x, 1D / 3D);
        }

        public static double XPowerOfThree(double x)
        {
            return Pow(x, 3D);
        }

        public static double XReverse(double x)
        {
            return 1D / x;
        }

        public static double XAbsolute(double x)
        {
            return Abs(x);
        }

        public static double Exponential(double x)
        {
            return Pow(E, x);
        }

        public static double NFactorial(double x)
        {
            double factorial = 1;
            for (ulong I = 1; I <= x; I++)
            {
                factorial *= I;
            }

            return factorial;
        }
    }
}
