namespace EngineeringCalculator
{
    internal class InputController
    {
        public delegate void ChangeHandler();
        public event ChangeHandler Update;

        public void Add(ref List<Composite> expression, Term number)
        {
            if (expression.Count == 0) expression.Add(number);
            else 
            { 
                switch (expression.Last())
                {
                    case Term lnumber:
                        {
                            if (lnumber.Record == "0") expression[expression.Count - 1] = number;
                            else expression[expression.Count - 1].Set = lnumber.Record + number.Record;
                            break;
                        }
                    case Function or Operator or Next or Open: { expression.Add(number); break; }
                }
            }
            Update.Invoke();
        }

        public void Add(ref List<Composite> expression, Comma comma)
        { 
            if (expression.Count != 0 && (expression.Last() is Term & !((Term)expression.Last()).HasDouble))
            {
                ((Term)expression.Last()).ToDouble();
                Update.Invoke();
            }
        }

        public void Add(ref List<Composite> expression, Constanta constanta)
        {
            if (expression.Count == 0) expression.Add(constanta);
            else
            {
                switch (expression.Last())
                {
                    case Term: { expression[expression.Count - 1] = constanta; break; }
                    case Function or Operator or Next or Open: { expression.Add(constanta); break; }
                }
            }
            Update.Invoke();
        }

        public void Add(ref List<Composite> expression, Operator operation)
        {
            if (expression.Count != 0)
            {
                switch (expression.Last())
                {
                    case Operator: { expression[expression.Count - 1] = operation; break; }
                    case Term or End or Close: { expression.Add(operation); break; } 
                }
                Update.Invoke();
            }
        }

        public void Add(ref List<Composite> expression, FunctionName function)
        {
            if (expression.Count == 0 || (
                expression.Last() is Operator |
                expression.Last() is Next |
                expression.Last() is Open
                ) ) { expression.Add(function); Update.Invoke(); }
        }

        public void Add(ref List<Composite> expression, Next next)
        { // true -> conflictInspector
            if (expression.Count != 0 && (
                (expression.Last() is Term & true) |
                (expression.Last() is Close & true) |
                (expression.Last() is End & true)
                ) ) { expression.Add(next); Update.Invoke(); }
        }

        public void Add(ref List<Composite> expression, End end)
        { // true -> conflictInspector
            if (expression.Count != 0 && (
                (expression.Last() is Term & true) |
                (expression.Last() is Close & true) |
                (expression.Last() is End & true)
                )) { expression.Add(end); Update.Invoke(); }
        }

        public void Add(ref List<Composite> expression, Open open)
        { // true -> conflictInspector
            if (expression.Count == 0 || (
                (expression.Last() is Operator & true) |
                (expression.Last() is FunctionName & true) |
                (expression.Last() is Open & true) |
                (expression.Last() is Next & true)
                )) { expression.Add(open); Update.Invoke(); }
        }

        public void Add(ref List<Composite> expression, Close close)
        { // true -> conflictInspector
            if (expression.Count != 0 && (
                (expression.Last() is Term & true) |
                (expression.Last() is Close & true) |
                (expression.Last() is End & true)
                )) { expression.Add(close); Update.Invoke(); }
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


/* variant 1
 
public bool IsValid(string s)
{
    var count = 0;
    foreach (var c in s)
    {
        if (c == '(')
            count++;

        if (c == ')')
        {
            if (count == 0) return false;
            count--;
        }       
    }
    return count == 0;
}
 
-----------------------------

variant 2

public bool IsValid2(string s)
{
    var stack = new Stack<char>();  
    foreach (var c in s)
    {
        switch (c)
        {
            case '{':
            case '(':
            case '[':
                stack.Push(c);
                break;

            case '}':
                if (stack.Count == 0) return false;
                if (stack.Pop() != '{') return false;
                break;
            case ']':
                if (stack.Count == 0) return false;
                if (stack.Pop() != '[') return false;
                break;
            case ')':
                if (stack.Count == 0) return false;
                if (stack.Pop() != '(') return false;
                break;
        }
    }   
    return stack.Count == 0;
}

 */