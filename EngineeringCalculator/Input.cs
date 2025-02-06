using EngineeringCalculator;

namespace EngineeringCalculator
{
    internal class InputController
    {
        public delegate void ChangeHandler();
        public event ChangeHandler Update;

        public void Add(ref List<Composite> expression, Term number)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count == 0) actualExpression.Add(number);
            else 
            { 
                switch (actualExpression.Last())
                {
                    case Term lnumber:
                        {
                            if (lnumber.Record == "0") actualExpression[actualExpression.Count - 1] = number;
                            else actualExpression[actualExpression.Count - 1].Set = lnumber.Record + number.Record;
                            break;
                        }
                    case Operator or Function or Staples: { expression.Add(number); break; }
                }
            }
            Update.Invoke();
        }

        public void Add(ref List<Composite> expression, Comma comma)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count != 0 && actualExpression.Last() is Term term && !term.HasDouble)
            {
                term.ToDouble();
                Update.Invoke();
            }
        }

        public void Add(ref List<Composite> expression, Constanta constanta)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count == 0) actualExpression.Add(constanta);
            else
            {
                switch (actualExpression.Last())
                {
                    case Term: { actualExpression[actualExpression.Count - 1] = constanta; break; }
                    case Operator or Function or Staples: { actualExpression.Add(constanta); break; }
                }
            }
            Update.Invoke();
        }

        public void Add(ref List<Composite> expression, Operator operation)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count != 0)
            {
                switch (actualExpression.Last())
                {
                    case Operator: { actualExpression[actualExpression.Count - 1] = operation; break; }
                    case Term or Function or Staples: { actualExpression.Add(operation); break; } 
                }
                Update.Invoke();
            }
        }

        public void Add(ref List<Composite> expression, Function function)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count == 0 || actualExpression.Last() is Operator) { actualExpression.Add(function); Update.Invoke(); }
        }

        public void Add(ref List<Composite> expression, Staples staples)
        {
            List<Composite> actualExpression = GetActualExpression(ref expression);

            if (actualExpression.Count == 0 || actualExpression.Last() is Operator) { actualExpression.Add(staples); Update.Invoke(); }
        }

        private List<Composite> GetActualExpression(ref List<Composite> expression)
        {
            return expression.Count != 0 && expression.Last() is IExpressionStoreable expressionStoreable ?
                expressionStoreable.GetActual(ref expression) :
                expression;
        }

        public void DeleteLast(ref List<Composite> expression)
        { 
            if (expression.Count != 0)
            {
                switch (expression.Last())
                {
                    case Term number:
                        {
                            if (expression[expression.Count - 1].Record.Length == 1) expression.RemoveAt(expression.Count - 1);
                            else expression[expression.Count - 1].Set = number.Record.Remove(number.Record.Length - 1);
                            break;
                        }
                    default:
                        {
                            expression.RemoveAt(expression.Count - 1);
                            break;
                        }
                }
                Update.Invoke();
            }
        }

        public void ClearAll(ref List<Composite> expression)
        {
            if (expression.Count != 0) { expression.Clear(); Update.Invoke(); }
        }
        public void ClearOne(ref List<Composite> expression)
        {
            if (expression.Count != 0) { expression.RemoveAt(expression.Count - 1); Update.Invoke(); }
        }
        public void ChangeSign(ref List<Composite> expression)
        {
            if (expression.Count != 0 && expression.Last() is Term term) { term.ChangeSign(); Update.Invoke(); }
        }
    }
}