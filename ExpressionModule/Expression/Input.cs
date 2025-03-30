namespace FFEC.ExpressionModule.Expression
{
    internal static class Input
    {
        public static List<Composite> ManualToExpression(string manual)
        {
            if (manual is null | manual == string.Empty) return null;

            List<Composite> expression = new List<Composite>();
            List<string> composits = manual.Split(';').ToList();
            foreach (string composit in composits)
            {
                switch (composit.Split('~')[0])
                {
                    case "Term": InputController.Append(expression, new Term(composit.Split('~')[1])); break;
                    case "Constanta": InputController.Append(expression, new Constanta(composit.Split('~')[1])); break;
                    case "Variable": InputController.Append(expression, new Variable(composit.Split('~')[1])); break;
                    case "Staples": InputController.Append(expression, new Staples()); break;
                    case "Operator":
                        {
                            OperatorMark mark = (OperatorMark)Enum.Parse(typeof(OperatorMark), composit.Split('~')[1]);
                            InputController.Append(expression, new Operator(OutputView.GetViewByMark(mark), mark));
                            break;
                        }
                    case "SingularFunction":
                        {
                            FunctionMark mark = (FunctionMark)Enum.Parse(typeof(FunctionMark), composit.Split('~')[1]);
                            InputController.Append(expression, new SingularFunction(OutputView.GetViewByMark(mark), mark));
                            break;
                        }
                    case "BinaryFunction":
                        {
                            FunctionMark mark = (FunctionMark)Enum.Parse(typeof(FunctionMark), composit.Split('~')[1]);
                            InputController.Append(expression, new BinaryFunction(OutputView.GetViewByMark(mark), mark));
                            break;
                        }
                    case "VisualEnd": InputController.CloseExpressionWrite(expression); break;
                }
            }
            return expression;
        }
    }
}
