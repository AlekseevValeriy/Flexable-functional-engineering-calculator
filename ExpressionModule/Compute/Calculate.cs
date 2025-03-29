namespace FFEC
{
    internal static class Calculate
    {
        public static Composite SolutionEquation(List<Composite> expression)
        {
            // проверка на пустоту (нужно для высчитывания IExpressionStoreable)
            if (expression.Count == 0)
            {
                return new Term("0");
            }

            // высчитывание всех вложынных выражений в IExpressionStoreable
            if (expression.Count(s => s is IExpressionStoreable) != 0)
            {
                for (ushort I = 0; I < expression.Count; I++)
                {
                    if (expression[I] is IExpressionStoreable storeable)
                    {
                        checked
                        {
                            storeable.Deconstruct(out Term term);
                            expression[I] = term;
                        }
                    }
                }
            }

            // приведение переменных к числам
            if (expression.Count(s => s is Variable) != 0)
            {
                for (ushort I = 0; I < expression.Count; I++)
                {
                    if (expression[I] is Variable variable)
                    {
                        expression[I] = new Term(variable.GetValue());
                    }
                }
            }

            // обычный счёт операторов и операндов
            if (expression.Count(s => s is Operator) != 0)
            {
                List<Composite> expressionCopy = [.. expression];
                List<Operator> operators = [.. expressionCopy.Where(o => o is Operator).Cast<Operator>().OrderBy(o => o.GetMark).Reverse()];

                foreach (Operator op in operators)
                {
                    ushort firstMaxIndex = (ushort)expressionCopy.IndexOf(op);
                    Term firstOperand = expressionCopy[firstMaxIndex - 1] as Term;
                    Operator operato = expressionCopy[firstMaxIndex] as Operator;
                    Term secondOperand = expressionCopy[firstMaxIndex + 1] as Term;
                    Term result = new Term(string.Empty);

                    switch (operato.GetMark)
                    {
                        case OperatorMark.Division: if (secondOperand.Value is 0) { throw new DivideByZeroException(); } goto default;
                        case OperatorMark.Modular: if (secondOperand.Value is 0) { result.Set(firstOperand); } break;
                        default:
                            {
                                checked
                                {
                                    result.Set(
                                        ArithmeticOperationsAdapter.GetOperation(operato.GetMark)(
                                            firstOperand.Value,
                                            secondOperand.Value)
                                        .ToString());
                                }
                                break;
                            }
                    }
                    expressionCopy.RemoveRange(firstMaxIndex - 1, 3);
                    expressionCopy.Insert(firstMaxIndex - 1, result);
                }

                expression = [expressionCopy[0]];
            }
            return expression.Last();
        }
    }
}
