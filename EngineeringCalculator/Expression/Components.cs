using System.Linq.Expressions;

namespace EngineeringCalculator
{
    internal class Composite
    {
        protected String meaning;

        public Composite(String meaning = "") => this.meaning = meaning;

        public String Record { get => meaning; }
        public void Set(String value) { meaning = value; }
        public void Set(Composite composite) { meaning = composite.Record; }
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
        public Int64 ValueInt64 { get => Int64.Parse(meaning); }
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
        private OperatorMark mark;
        public OperatorMark GetMark { get => mark; }
        public Operator(String meaning, OperatorMark mark) : base(meaning) { this.mark = mark; }
    }

    public enum OperatorMark
    {
        Add,
        Subtrack,
        Multiply,
        Division,
        Modular
    }

    internal class Function : Composite
    {
        FunctionMark mark;
        public FunctionMark GetMark { get => mark; }
        public Function(String meaning, FunctionMark mark) : base(meaning) { this.mark = mark; }
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

    

    internal class BinaryFunction: Function, IExpressionStoreable
    {
        public BinaryFunctionMark markStorage;
        private Boolean firstWrite = true;
        private Boolean secondWrite = true;
        private List<Composite> firstExpression = new List<Composite>();
        private List<Composite> secondExpression = new List<Composite>();
        public BinaryFunction(String meaning, FunctionMark mark) : base(meaning, mark) { markStorage.Field = this.GetMark; }
        public void Deconstruct(out Composite result)
        {
            Composite firstResult = Calculate.SolutionEquation(ref firstExpression);
            Composite secondResult = Calculate.SolutionEquation(ref secondExpression);
            result = new Composite();
            result.Set(ArithmeticOperations.GetPerformAction(markStorage)(((Term)firstResult).ValueDouble, ((Term)secondResult).ValueDouble).ToString());
        }

        public ref List<Composite> GetFirstExpression() => ref firstExpression;
        public ref List<Composite> GetSecondExpression() => ref secondExpression;

        public List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualExpression = firstWrite ? firstExpression : secondExpression;
                if (actualExpression.Count != 0 && actualExpression.Last() is IExpressionStoreable storeable) return storeable.GetActualExpression(ref actualExpression);
                else return actualExpression;
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression() => (firstWrite | secondWrite) ? firstWrite ? firstExpression : secondExpression : null;

        public IExpressionStoreable GetActualComposite()
        {
            if (firstWrite | secondWrite)
            {
                List<Composite> actualExpression = GetCurrentExpression();
                if (actualExpression.Count != 0 && actualExpression.Last() is IExpressionStoreable storeable) return storeable.GetActualComposite();
            }
            return this;
        }

        public void CloseWrite()
        {
            if (firstWrite) firstWrite = false;
            else if (secondWrite) secondWrite = false;
        }
    }
    public struct BinaryFunctionMark
    {
        private FunctionMark mark;
        public FunctionMark Field { get => mark; set => mark = value; }
    }

    internal class SingularFunction : Function, IExpressionStoreable
    {
        public SingularFunctionMark markStorage;
        private Boolean write = true;
        public List<Composite> expression = new List<Composite>();
        public SingularFunction(String meaning, FunctionMark mark) : base(meaning, mark) { markStorage.Field = this.GetMark; }
        public void Deconstruct(out Composite result)
        {
            result = Calculate.SolutionEquation(ref expression);
            Double n = ((Term)result).ValueDouble;
            Double mm = ArithmeticOperations.GetPerformAction(markStorage)(n);
            result.Set(mm.ToString());
        }

        public ref List<Composite> GetExpression() => ref expression;

        public List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            if (write)
            {
                if (this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable) return storeable.GetActualExpression(ref this.expression);
                else return this.expression;
            }
            return expression;
        }

        public List<Composite>? GetCurrentExpression() => write ? this.expression : null;

        public IExpressionStoreable GetActualComposite()
        {
            if (write && this.expression.Count != 0 && this.expression.Last() is IExpressionStoreable storeable) return storeable.GetActualComposite();
            return this;
        }

        public void CloseWrite()
        {
            if (write) write = false;
        }
    }
    public struct SingularFunctionMark
    {
        private FunctionMark mark;
        public FunctionMark Field { get => mark; set => mark = value; }
    }

    internal class Staples : Composite, IExpressionStoreable
    {
        private Boolean write = true;
        public List<Composite> expression = new List<Composite>();
        public Staples(String meaning = "") : base(meaning) { }
        public void Deconstruct(out Composite result)
        {
            result = Calculate.SolutionEquation(ref expression);
        }

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

        public void CloseWrite() { if (write) write = false; }
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
        public void Deconstruct(out Composite result);
        public void CloseWrite();
    }
}
