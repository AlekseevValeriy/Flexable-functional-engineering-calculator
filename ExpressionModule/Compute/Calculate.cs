namespace FFEC
{
    internal static class Calculate
    {
        public static Composite SolutionEquation(List<Composite> expression)
        {
            if (expression.Count == 0) return new Term("0");

            if (expression.Count(s => s is IExpressionStoreable) != 0)
            {
                for (UInt16 I = 0; I < expression.Count; I++)
                {
                    if (expression[I] is IExpressionStoreable storeable)
                    {
                        checked
                        {
                            storeable.Deconstruct(out Term term);
                            expression[I] = (Composite)term;
                        }
                    }
                }
            }

            UInt16 operatorsCount = (UInt16)expression.Count(s => s is Operator);
            if (operatorsCount != 0)
            {
                List<Composite> Cexpression = new List<Composite>(expression);
                List<Operator> operators = new List<Operator>(Cexpression.Where(o => o is Operator).Cast<Operator>().OrderBy(o => o.GetMark).Reverse());

                foreach (Operator op in operators)
                {
                    UInt16 firstMaxIndex = (UInt16)Cexpression.IndexOf((Composite)op);
                    Term firstOperand = (Term)Cexpression[firstMaxIndex - 1];
                    Operator operato = (Operator)Cexpression[firstMaxIndex];
                    Term secondOperand = (Term)Cexpression[firstMaxIndex + 1];
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
                                checked
                                {
                                    result.Set(ArithmeticOperationsAdapter.GetOperation(operato.GetMark)(
                                    firstOperand.Value,
                                    secondOperand.Value).ToString());
                                }
                                break;
                            }
                    }
                    Cexpression.RemoveRange(firstMaxIndex - 1, 3);
                    Cexpression.Insert(firstMaxIndex - 1, result);
                }

                expression = new List<Composite> { Cexpression[0] };
            }
            return expression.Last();
        }

        public static Queue<UInt16> GetExecutionQueue(List<Composite> expression)
        {
            Queue<UInt16> primaryImportance = new Queue<UInt16>();
            Queue<UInt16> secondaryImportance = new Queue<UInt16>();

            UInt16 operatorCounter = 0;

            foreach (Composite composite in expression)
            {
                if (composite is Operator operato)
                {
                    switch (operato.GetMark)
                    {
                        case OperatorMark.Multiply or OperatorMark.Division or OperatorMark.Modular:
                            { primaryImportance.Enqueue(operatorCounter); break; }
                        case OperatorMark.Add or OperatorMark.Subtract:
                            { secondaryImportance.Enqueue(operatorCounter); break; }
                    }
                    operatorCounter++;
                }
            }
            return new Queue<UInt16>(primaryImportance.Concat(secondaryImportance));
        }
    }
}
