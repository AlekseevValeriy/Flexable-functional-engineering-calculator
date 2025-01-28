namespace EngineeringCalculator
{
    internal class Structure
    {
        public enum Operation // binary operand
        {
            Add = 0,
            Subtrack = 1,
            Multiply = 2,
            Division = 3,
            Modular = 4
        }

        public enum Modifier // single operand
        {
            NaturalLogarithm,
            DecimalLogarithm,
            TenPowerOfX,
            XPowerOfY,
            SquareRootOfX,
            XPowerOfTwo,
            EPowerOfX,
            LogarithmOfXBasedOnY,
            TwoPowerOfX,
            YRootOfX,
            CubicRootOfX,
            XPowerOfThree,
            XReverse,
            XAbsolute,
            Exponential,
            NFactorial
        }

        public enum Constant
        {
            Pi,
            E
        }

        public enum Special
        {
            Next,
            End,
            Start,
            Stop
        }
    }
}
