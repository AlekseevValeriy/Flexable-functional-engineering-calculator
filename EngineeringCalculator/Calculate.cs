namespace EngineeringCalculator
{
    // actions of the first stage -> functions and staples
    // actions of the second stage -> operators
    internal static class Calculate
    {
        public static Composite SolutionEquation(ref List<Composite> expression)
        {
            // check expression on func, cut, recursive calculate and set new terms

            // check expression on ( and ), cut, recursive calculate and set new terms

            // check expression on opeperators, find highest operators, cut, calculate and set new terms
            return new Composite();
        }

        //private static void SolutionFirstStage(ref List<Composite> expression)
        //{
        //    UInt16 index = 0;
        //    Stack<Char> skeletonExpression = new Stack<Char>(); // FunctionName -> 's', End -> 'e', Open -> 'o', Close -> 'c'
        //    List<Composite> subExpression = new List<Composite>();
        //    Boolean massacre = false;
        //    do
        //    {
        //        switch (expression[index])
        //        {
        //            case FunctionName: { if (massacre == false) massacre = true; skeletonExpression.Push('s'); break; }
        //            case End: { if (skeletonExpression.Count == 0 || skeletonExpression.Pop() != 's') Error(); skeletonExpression.Pop(); break; }
        //            case Open: { if (massacre == false) massacre = true; skeletonExpression.Push('o'); break; }
        //            case Close: { if (skeletonExpression.Count == 0 || skeletonExpression.Pop() != 'o') Error(); skeletonExpression.Pop(); break; }
        //        }

        //        if (massacre == true)
        //        {   // TODO не работает есть будет 2 аргумента в внешней функции, надо разделять или переделывать
        //            if (skeletonExpression.Count == 0) { expression.Insert(index, SolutionEquation(ref subExpression)); massacre = false; }
        //            else { subExpression.Add(expression[index]); expression.RemoveAt(index); }
        //        }
        //        else { index++; }
        //    } while (index != expression.Count);
        //}

        //private static void Error()
        //{
        //    throw new Exception();
        //}
    }
}
