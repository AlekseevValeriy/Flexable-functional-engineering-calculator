namespace EngineeringCalculator
{
    internal class Composite
    {
        protected String meaning;

        public Composite(String meaning = "") => this.meaning = meaning;

        public String Record { get => meaning; }
        public String Set { set => meaning = value; }
    }

    internal class Term : Composite
    {
        public Term(String meaning) : base(meaning) { }
        public Boolean IsDouble { get => HasDouble && meaning.Split(',')[1] != String.Empty; }
        public Boolean HasDouble { get => meaning.Contains(','); }
        public void ToDouble() { if (!HasDouble) meaning += ','; }
        public Boolean IsZero { get => (meaning.Count(t => t == '0') + meaning.Count(t => t == ',')) == meaning.Length; }
        public void ChangeSign() { meaning = meaning.Contains('-') ? meaning.Remove(0, 1) : meaning = "-" + meaning; }
        public Double Value { get => IsDouble ? Double.Parse(meaning) : Int64.Parse(meaning); set => meaning = value.ToString(); }
        public Double ValueDouble { get => Double.Parse(meaning); }
        public Double ValueInt64 { get => Int64.Parse(meaning); }
    }

    internal class Constanta : Term
    {
        public Constanta(String meaning) : base(meaning) { }
    }

    internal class Comma : Composite
    {
        public Comma(String meaning = ",") : base(meaning) { }
    }

    internal class Operator : Composite
    {
        EnumOperator mark;
        public Operator(String meaning, EnumOperator mark) : base(meaning) { this.mark = mark; }
    }

    public enum EnumOperator
    {
        Add = 0,
        Subtrack = 0,
        Multiply = 1,
        Division = 1,
        Modular = 1
    }

    internal class Function : Composite
    {
        public Function(String meaning) : base(meaning) { }
    }

    internal class FunctionName : Function
    {
        EnumFunctionName mark;
        public FunctionName(String meaning, EnumFunctionName mark) : base(meaning) { this.mark = mark; }
    }

    public enum EnumFunctionName
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

    internal class Next : Function
    {
        public Next(String meaning = ",") : base(meaning) { }
    }

    internal class End : Function
    {
        public End(String meaning = ".") : base(meaning) { }
    }

    internal class Sign : Composite
    {
        public Sign(String meaning = "") : base(meaning) { }
    }

    internal class Open : Sign
    {
        public Open(String meaning = "(") : base(meaning) { }
    }

    internal class Close : Sign
    {
        public Close(String meaning = ")") : base(meaning) { }
    }
}
