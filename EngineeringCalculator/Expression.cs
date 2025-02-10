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
        OperatorName mark;
        public Operator(String meaning, OperatorName mark) : base(meaning) { this.mark = mark; }
    }

    public enum OperatorName
    {
        Add = 0,
        Subtrack = 0,
        Multiply = 1,
        Division = 1,
        Modular = 1
    }

    internal class Function : Composite
    {
        FunctionName mark;
        public Function(String meaning, FunctionName mark) : base(meaning) { this.mark = mark; }
    }

    internal class BinaryFunction: Function, IExpressionStoreable
    {
        private List<Composite> firstExpression = new List<Composite>();
        private List<Composite> secondExpression = new List<Composite>();

        public ref List<Composite> GetFirstExpression() => ref firstExpression;
        public ref List<Composite> GetSecondExpression() => ref secondExpression;

        public List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualParameter = firstWrite ? firstExpression : secondExpression;
                if (actualParameter.Count != 0 && actualParameter.Last() is IExpressionStoreable expressionStoreable) return expressionStoreable.GetActualExpression(ref actualParameter);
                else return actualParameter;
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression() => (firstWrite | secondWrite) ? firstWrite ? firstExpression : secondExpression : null;

        public IExpressionStoreable GetActualComposite()
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualParameter = GetCurrentExpression();
                if (actualParameter.Count != 0 && actualParameter.Last() is IExpressionStoreable storeable) return storeable
                    .GetActualComposite();
                
            }
            return this;
        }

        private Boolean firstWrite = true;
        private Boolean secondWrite = true;

        public void CloseWrite()
        {
            if (firstWrite) firstWrite = false;
            else if (secondWrite) secondWrite = false;
        }
        
        public BinaryFunction(String meaning, FunctionName mark) : base(meaning, mark) { }
    }

    internal class SingularFunction : Function, IExpressionStoreable
    {
        public List<Composite> expression = new List<Composite>();

        public ref List<Composite> GetExpression() => ref expression;

        public List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            if (write)
            {
                if (this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable expressionStoreable) return expressionStoreable.GetActualExpression(ref this.expression);
                else return this.expression;
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression() => write ? this.expression : null;

        public IExpressionStoreable GetActualComposite()
        {
            if (write && this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable) return storeable
                    .GetActualComposite();
            return this;
        }

        private Boolean write = true;
        
        public void CloseWrite()
        {
            if (write) write = false;
        }

        public SingularFunction(String meaning, FunctionName mark) : base(meaning, mark) { }
    }

    public enum FunctionName
    {
        XPowerOfY, //
        LogarithmOfXBasedOnY, //
        YRootOfX, //
        NaturalLogarithm,
        DecimalLogarithm,
        TenPowerOfX,
        SquareRootOfX,
        XPowerOfTwo,
        EPowerOfX,
        TwoPowerOfX,
        CubicRootOfX,
        XPowerOfThree,
        XReverse,
        XAbsolute,
        Exponential,
        NFactorial
    }

    internal class Staples : Composite, IExpressionStoreable
    {
        public List<Composite> expression = new List<Composite>();

        public ref List<Composite> GetExpression() => ref expression;

        public List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            if (write)
            {
                if (this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable) return storeable
                        .GetActualExpression(ref this.expression);
                else return this.expression;
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression() => write ? this.expression : null;

        public IExpressionStoreable GetActualComposite()
        {
            if (write && this.expression.Count != 0 &&  this.expression.Last() is IExpressionStoreable storeable) return storeable
                    .GetActualComposite();
            return this;
        }

        private Boolean write = true;

        public void CloseWrite()
        {
            if (write) write = false;
        }
        public Staples(String meaning = "") : base(meaning) { }
    }

    internal class VisualStaple: Composite
    {
        public VisualStaple(String meaning = "") : base(meaning) { }
    }

    internal interface IExpressionStoreable
    {
        public List<Composite> GetActualExpression(ref List<Composite> expression);
        public List<Composite>? GetCurrentExpression();
        public IExpressionStoreable GetActualComposite();
        public void CloseWrite();
    }
}
