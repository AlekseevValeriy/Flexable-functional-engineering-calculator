using System.Linq.Expressions;

namespace EngineeringCalculator
{
    // actions of the first stage -> functions and staples
    // actions of the second stage -> operators
    internal static class Calculate
    {
        public static Composite SolutionEquation(ref List<Composite> expression)
        {
            if (expression.Count == 0) return new Term("0");

            if (expression.Count(s => s is IExpressionStoreable) != 0)
            { 
                for (UInt16 I = 0; I < expression.Count; I++)
                {
                    if (expression[I] is IExpressionStoreable storeable)
                    {
                        Composite composite = expression[I];
                        storeable.Deconstruct(out composite);
                        expression[I] = composite;
                    }
                }
            }

            UInt16 operatorsCount = (UInt16)expression.Count(s => s is Operator);
            if (operatorsCount != 0)
            {
                //Stack<Composite> Sexpression = new Stack<Composite>(((IEnumerable<Composite>)expression).Reverse());
                //for (UInt16 I = 0; I < operatorsCount; I++)
                //{
                //    Term firstOperand = (Term)Sexpression.Pop();
                //    Operator operato = (Operator)Sexpression.Pop();
                //    Term secondOperand = (Term)Sexpression.Pop();
                //    Term result = new Term(String.Empty);

                //    switch (operato.GetMark)
                //    {
                //        case OperatorMark.Division:
                //            {
                //                if (secondOperand.Value is 0) throw new DivideByZeroException();
                //                goto default;
                //            }
                //        case OperatorMark.Modular:
                //            {
                //                if (secondOperand.Value is 0) result.Set(firstOperand);
                //                break;
                //            }
                //        default:
                //            {
                //                result.Set(ArithmeticOperations.GetPerformAction(operato.GetMark)(
                //                    firstOperand.Value,
                //                    secondOperand.Value).ToString());
                //                break;
                //            }
                //    }

                //    Sexpression.Push(result);
                //}
                //expression = new List<Composite> { Sexpression.Pop() };
                List<Composite> Cexpression = new List<Composite>(expression);
                foreach(UInt16 I in GetExecutionQueue(ref Cexpression))
                {
                    Term firstOperand = (Term)Cexpression[I - 1];
                    Operator operato = (Operator)Cexpression[I];
                    Term secondOperand = (Term)Cexpression[I + 1];
                    Term result = new Term(String.Empty);

                    switch (operato.GetMark)
                    {
                        case OperatorMark.Division:
                            {
                                if (secondOperand.Value is 0) throw new DivideByZeroException();
                                goto default;
                            }
                        case OperatorMark.Modular:
                            {
                                if (secondOperand.Value is 0) result.Set(firstOperand);
                                break;
                            }
                        default:
                            {
                                result.Set(ArithmeticOperations.GetPerformAction(operato.GetMark)(
                                    firstOperand.Value,
                                    secondOperand.Value).ToString());
                                break;
                            }
                    }
                    Cexpression.RemoveRange(I - 1, 3);
                    Cexpression.Insert(I - 1, result);
                    expression = new List<Composite> { Cexpression[0] };
                }
            }
            return expression.Last();
        }
        
        public static Queue<UInt16> GetExecutionQueue(ref List<Composite> expression)
        {
            Queue<UInt16> primaryImportance = new Queue<UInt16>();
            Queue<UInt16> secondaryImportance = new Queue<UInt16>();

            for (UInt16 I = 0; I < expression.Count; I++)
            {
                if (expression[I] is Operator operato)
                {
                    switch (operato.GetMark)
                    {
                        case OperatorMark.Multiply or OperatorMark.Division or OperatorMark.Modular:
                            { primaryImportance.Enqueue(I); break; }
                        case OperatorMark.Add or OperatorMark.Subtrack:
                            { secondaryImportance.Enqueue(I); break; }
                    }
                }
            }

            return new Queue<UInt16>(primaryImportance.Concat(secondaryImportance));
        }
    }
}
