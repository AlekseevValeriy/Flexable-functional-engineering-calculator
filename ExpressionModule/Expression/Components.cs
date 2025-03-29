namespace FFEC
{
    internal class Composite
    {
        protected string meaning;

        public Composite(string meaning = "")
        {
            this.meaning = meaning;
        }

        public virtual string Record => meaning;
        public void Set(string value) { meaning = value; }
        public void Set(Composite composite) { meaning = composite.Record; }
    }

    internal class Term : Composite
    {
        public Term(string meaning) : base(meaning) { }
        public bool IsDouble => HasDouble && meaning.Split(',')[1] != string.Empty;
        public bool HasDouble => meaning.Contains(',');
        public void ToDouble()
        {
            if (!HasDouble)
            {
                meaning += ',';
            }
        }
        public bool IsZero => (meaning.Count(t => t == '0') + meaning.Count(t => t == ',')) == meaning.Length;
        public void ChangeSign() { meaning = meaning.Contains('-') ? meaning.Remove(0, 1) : meaning = "-" + meaning; }
        public double Value
        {
            get
            {
                if (IsDouble) { double.TryParse(meaning, out double tDouble); return tDouble; }
                else { long.TryParse(meaning, out long tInt64); return tInt64; }
            }
            set => meaning = value.ToString();
        }
    }

    internal class Constanta : Term
    {
        public Constanta(string meaning) : base(meaning) { }
    }

    internal class Comma : Composite
    {
        public Comma(string meaning = ",") : base(meaning) { }
    }

    internal class Variable : Composite
    {
        public Variable(string meaning) : base(meaning) { }
        public string GetValue()
        {
            return JsonStorage.Configurations[Config.CurrentConfig]["Variables"][meaning].Value<string>();
        }
    }

    internal class Operator : Composite
    {
        public OperatorMark GetMark { get; }
        public Operator(string meaning, OperatorMark mark) : base(meaning) { this.GetMark = mark; }
    }

    public enum OperatorMark
    {
        Add,
        Subtract,
        Multiply,
        Division,
        Modular
    }

    internal class Function : Composite
    {
        public FunctionMark GetMark { get; }
        public Function(string meaning, FunctionMark mark) : base(meaning) { this.GetMark = mark; }
    }

    public enum FunctionMark
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

    internal class BinaryFunction : Function, IExpressionStoreable
    {
        public BinaryFunctionMark markStorage;
        private bool firstWrite = true;
        private bool secondWrite = true;
        private readonly List<Composite> firstExpression = [];
        private readonly List<Composite> secondExpression = [];
        public BinaryFunction(string meaning, FunctionMark mark) : base(meaning, mark) { markStorage.Field = this.GetMark; }
        public void Deconstruct(out Term result)
        {
            Term firstResult = Calculate.SolutionEquation(firstExpression) as Term;
            Term secondResult = Calculate.SolutionEquation(secondExpression) as Term;
            result = new Term("0");
            result.Set(ArithmeticOperationsAdapter.GetOperation(markStorage)(firstResult.Value, secondResult.Value).ToString());
        }

        public List<Composite> GetFirstExpression()
        {
            return firstExpression;
        }

        public List<Composite> GetSecondExpression()
        {
            return secondExpression;
        }

        public List<Composite> GetActualExpression(List<Composite> expression)
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualExpression = firstWrite ? firstExpression : secondExpression;
                return actualExpression.Count != 0 && actualExpression.Last() is IExpressionStoreable storeable
                    ? storeable.GetActualExpression(actualExpression)
                    : actualExpression;
            }
            return expression;
        }
        public List<Composite> GetActualNotEmptyExpression(List<Composite> expression)
        {
            List<Composite>? actualExpression = null;
            if (secondExpression.Count != 0)
            {
                actualExpression = secondExpression;
            }
            else if (firstExpression.Count != 0)
            {
                actualExpression = firstExpression;
            }

            if (actualExpression is not null)
            {
                if (actualExpression.Last() is IExpressionStoreable storeable)
                {
                    return storeable
                    .GetActualNotEmptyExpression(actualExpression);
                }
                else
                {
                    if (!secondWrite)
                    {
                        secondWrite = true;
                    }
                    else if (!firstWrite)
                    {
                        firstWrite = true;
                    }

                    return actualExpression;
                }
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression()
        {
            return (firstWrite | secondWrite) ? firstWrite ? firstExpression : secondExpression : null;
        }

        public IExpressionStoreable GetActualComposite()
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualExpression = GetCurrentExpression();
                if (actualExpression.Count != 0 && actualExpression.Last() is IExpressionStoreable storeable && storeable.GetCurrentExpression() is not null)
                {
                    return storeable.GetActualComposite();
                }
            }
            return this;
        }

        public void CloseWrite()
        {
            if (firstWrite)
            {
                firstWrite = false;
            }
            else if (secondWrite)
            {
                secondWrite = false;
            }
        }
    }
    public struct BinaryFunctionMark
    {
        public FunctionMark Field { get; set; }
    }

    internal class SingularFunction : Function, IExpressionStoreable
    {
        public SingularFunctionMark markStorage;
        private bool write = true;
        public List<Composite> expression = [];
        public SingularFunction(string meaning, FunctionMark mark) : base(meaning, mark) { markStorage.Field = this.GetMark; }
        public void Deconstruct(out Term result)
        {
            result = Calculate.SolutionEquation(expression) as Term;
            result.Set(ArithmeticOperationsAdapter.GetOperation(markStorage)(result.Value).ToString());
        }

        public List<Composite> GetExpression()
        {
            return expression;
        }

        public List<Composite> GetActualExpression(List<Composite> expression)
        {
            return write
                ? this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable
                    ? storeable.GetActualExpression(this.expression)
                    : this.expression
                : expression;
        }

        public List<Composite> GetActualNotEmptyExpression(List<Composite> expression)
        {
            if (this.expression.Count != 0)
            {
                if (this.expression.Last() is IExpressionStoreable storeable)
                {
                    return storeable
                        .GetActualNotEmptyExpression(this.expression);
                }
                else
                {
                    if (!write)
                    {
                        write = true;
                    }

                    return this.expression;
                }
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression()
        {
            return write ? this.expression : null;
        }

        public IExpressionStoreable GetActualComposite()
        {
            return write && this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable && storeable.GetCurrentExpression() is not null
                ? storeable.GetActualComposite()
                : this;
        }

        public void CloseWrite()
        {
            if (write)
            {
                write = false;
            }
        }
    }
    public struct SingularFunctionMark
    {
        public FunctionMark Field { get; set; }
    }

    internal class Staples : Composite, IExpressionStoreable
    {
        private bool write = true;
        public List<Composite> expression = [];
        public Staples(string meaning = "") : base(meaning) { }
        public void Deconstruct(out Term result)
        {
            result = Calculate.SolutionEquation(expression) as Term;
        }

        public List<Composite> GetExpression()
        {
            return expression;
        }

        public List<Composite> GetActualExpression(List<Composite> expression)
        {
            return write
                ? this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable
                    ? storeable
                        .GetActualExpression(this.expression)
                    : this.expression
                : expression;
        }

        public List<Composite> GetActualNotEmptyExpression(List<Composite> expression)
        {
            if (this.expression.Count != 0)
            {
                if (this.expression.Last() is IExpressionStoreable storeable)
                {
                    return storeable
                        .GetActualNotEmptyExpression(this.expression);
                }
                else
                {
                    if (!write)
                    {
                        write = true;
                    }

                    return this.expression;
                }
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression()
        {
            return write ? this.expression : null;
        }

        public IExpressionStoreable GetActualComposite()
        {
            return write && this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable && storeable.GetCurrentExpression() is not null
                ? storeable
                    .GetActualComposite()
                : this;
        }

        public void CloseWrite()
        {
            if (write)
            {
                write = false;
            }
        }
    }

    internal class VisualStaple : Composite
    {
        public VisualStaple(string meaning = "") : base(meaning) { }
    }

    internal interface IExpressionStoreable
    {
        List<Composite> GetActualExpression(List<Composite> expression);
        List<Composite> GetActualNotEmptyExpression(List<Composite> expression);
        List<Composite>? GetCurrentExpression();
        IExpressionStoreable GetActualComposite();
        void Deconstruct(out Term result);
        void CloseWrite();
    }
}
