namespace EngineeringCalculator
{
    internal class ExpressionStack
    {
        public delegate void ExpressionHandler();
        public event ExpressionHandler Change;

        public List<Object> expressionStack = new List<Object>();

        private readonly ModifierStack modStack = new ModifierStack();

        private Object Last { get => expressionStack.Last(); set => expressionStack[expressionStack.Count - 1] = value; }
        private Int32 Count { get => expressionStack.Count(); }

        public ExpressionStack() { }

        public ExpressionStack(List<Object> expressionStack)
        {
            this.expressionStack = expressionStack;
        }

        private Double GetConstant(Constant constant)
        {
            if (constant is Constant.Pi) return PI;
            else if (constant is Constant.E) return E;
            else return 0;
        }

        public void Add(String value)
        {
            if (Count == 0) { expressionStack.Add(value); Change.Invoke(); return; }
            switch (Last)
            {
                case String number:
                    {
                        if (number == "0")
                        {
                            if (value != "0") Last = value;
                            else { }
                        }
                        else Last = number + value;
                        goto default;
                    }
                case Constant constant:
                    {
                        Last = GetConstant(constant).ToString() + value;
                        goto default;
                    }
                case Operation _:
                    {
                        expressionStack.Add(value);
                        goto default;
                    }
                case Modifier _:
                    {
                        expressionStack.Add(value);
                        goto default;
                    }
                case Special special:
                    {
                        if (special is Special.Next | special is Special.Start) { expressionStack.Add(value); }
                        else if (special is Special.End | special is Special.Stop) { }
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }

        public void Add(Constant value)
        {
            if (Count == 0) { expressionStack.Add(value); Change.Invoke(); return; }
            switch (Last)
            {
                case String _:
                    {
                        Last = value;
                        goto default;
                    }
                case Constant _:
                    {
                        Last = value;
                        goto default;
                    }
                case Operation _:
                    {
                        expressionStack.Add(value);
                        goto default;
                    }
                case Modifier _:
                    {
                        expressionStack.Add(value);
                        goto default;
                    }
                case Special special:
                    {
                        if (special is Special.Next | special is Special.Start) { expressionStack.Add(value); }
                        else if (special is Special.End | special is Special.Stop) { }
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }

        public void Add(Operation operation)
        {
            if (Count == 0) { return; }
            switch (Last)
            {
                case String _:
                    {
                        expressionStack.Add(operation);
                        goto default;
                    }
                case Constant _:
                    {
                        expressionStack.Add(operation);
                        goto default;
                    }
                case Operation _:
                    {
                        Last = operation;
                        goto default;
                    }
                case Modifier _:
                    {
                        goto default;
                    }
                case Special special:
                    {
                        if (special is Special.Next | special is Special.Start) { }
                        else if (special is Special.End | special is Special.Stop) { expressionStack.Add(operation); }
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }

        public void Add(Modifier modifier)
        {
            if (Count == 0) { expressionStack.Add(modifier); Change.Invoke(); return; }
            switch (Last)
            {
                case String _:
                    {
                        goto default;
                    }
                case Constant _:
                    {
                        goto default;
                    }
                case Operation _:
                    {
                        expressionStack.Add(modifier);
                        goto default;
                    }
                case Modifier _:
                    {
                        expressionStack.Add(modifier);
                        goto default;
                    }
                case Special special:
                    {
                        if (special is Special.Next | special is Special.Start) { expressionStack.Add(modifier); }
                        else if (special is Special.End | special is Special.Stop) { }
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }
        public void Add(Special special)
        {
            if (Count == 0)
            {
                if (special is Special.Start) expressionStack.Add(special);
                Change.Invoke();
                return;
            }
            switch (Last)
            {
                case String _:
                    {
                        if (
                            special is Special.Stop | // <- future //
                            (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                            (special is Special.End & modStack.CanSetEnd(ref expressionStack))
                            ) expressionStack.Add(special);
                        goto default;
                    }
                case Constant _:
                    {
                        if (
                            special is Special.Stop | // <- future //
                            (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                            (special is Special.End & modStack.CanSetEnd(ref expressionStack))
                            ) expressionStack.Add(special);
                        goto default;
                    }
                case Operation _:
                    {
                        if (special is Special.Start) expressionStack.Add(special);
                        goto default;
                    }
                case Modifier _:
                    {
                        if (special is Special.Start) expressionStack.Add(special);
                        goto default;
                    }
                case Special special2:
                    {
                        if (special2 is Special.Next & special is Special.Start) expressionStack.Add(special);
                        else if (
                            special2 is Special.End & (
                            (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                            (special is Special.End & modStack.CanSetEnd(ref expressionStack)) |
                            special is Special.Stop) // <- future //
                            ) expressionStack.Add(special);
                        else if (special2 is Special.Start & special is Special.Start) expressionStack.Add(special);
                        else if (
                            special2 is Special.Stop & (
                            (special is Special.Next & modStack.CanSetNext(ref expressionStack)) |
                            (special is Special.End & modStack.CanSetEnd(ref expressionStack)) |
                            special is Special.Stop) // <- future //
                            ) expressionStack.Add(special);
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }

        private class ModifierStack
        {
            public enum Operand
            {
                Binary,
                Sign
            }

            private readonly ArrayList modifierStack = new ArrayList();

            private void BuildStack(ref List<Object> expStack)
            {
                foreach (Object obj in expStack)
                {
                    switch (obj)
                    {
                        case Modifier modifier:
                            {
                                if (
                                    modifier is Modifier.XPowerOfY |
                                    modifier is Modifier.LogarithmOfXBasedOnY |
                                    modifier is Modifier.YRootOfX
                                    ) SetModifier(Operand.Binary);
                                else SetModifier(Operand.Sign);
                                break;
                            }
                        case Special special:
                            {
                                if (special is Special.Next) SetNext();
                                else if (special is Special.End) SetEnd();
                                break;
                            }
                    }
                }
            }
            public void SetModifier(Operand operand)
            {
                if (operand is Operand.Sign) modifierStack.Add(new ModifierOneParameter());
                else if (operand is Operand.Binary) modifierStack.Add(new ModifierTwoParameters());
            }
            private void SetNext()
            {
                GetFirstNeedNext().Set();
            }

            public Boolean CanSetNext(ref List<Object> expStack)
            {
                BuildStack(ref expStack);
                Boolean result = FindFirstNeedNext();
                modifierStack.Clear();
                return result;
            }
            private ModifierWithParameters GetFirstNeedNext()
            {
                foreach (ModifierWithParameters modifier in modifierStack)
                {
                    if (
                        (modifier is ModifierOneParameter & modifier.GetNeed() > 0) |
                        (modifier is ModifierTwoParameters & modifier.GetNeed() == 2)
                        ) return modifier;
                }
                return (ModifierWithParameters)modifierStack[modifierStack.Count - 1];
            }

            private Boolean FindFirstNeedNext()
            {
                foreach (ModifierWithParameters modifier in modifierStack)
                {
                    if (
                        (modifier is ModifierTwoParameters & modifier.GetNeed() == 2)
                        ) return true;
                }
                return false;
            }

            private void SetEnd()
            {
                GetFirstNeedEnd().Set();
            }

            public Boolean CanSetEnd(ref List<Object> expStack)
            {
                BuildStack(ref expStack);
                Boolean result = FindFirstNeedEnd();
                modifierStack.Clear();
                return result;
            }

            private ModifierWithParameters GetFirstNeedEnd()
            {
                foreach (ModifierWithParameters modifier in modifierStack)
                {
                    if (modifier is ModifierTwoParameters)
                    {
                        if (modifier.GetNeed() == 1) return modifier;
                    }
                }
                return (ModifierWithParameters)modifierStack[modifierStack.Count - 1];
            }

            private Boolean FindFirstNeedEnd()
            {
                foreach (ModifierWithParameters modifier in modifierStack)
                {
                    {
                        if (modifier.GetNeed() == 1) return true;
                    }
                }
                return false;
            }

            private abstract class ModifierWithParameters
            {
                public abstract void Set();

                public abstract Int16 GetNeed();
            }

            private class ModifierOneParameter : ModifierWithParameters
            {
                private Boolean end = false;

                public override void Set() => end = true;

                public override Int16 GetNeed() => (Int16)(end == true ? 0 : 1);
            }
            private class ModifierTwoParameters : ModifierWithParameters
            {
                private Boolean next = false;
                private Boolean end = false;

                public override void Set()
                {
                    if (next == false) next = true;
                    else if (end == false) end = true;
                }

                public override Int16 GetNeed()
                {
                    if (next == true & end == true) return 0;
                    else if (next == true & end == false) return 1;
                    else if (next == false & end == false) return 2;
                    return 0;
                }
            }
        }

        public void Delete()
        {
            if (Count == 0) { return; }
            switch (Last)
            {
                case String number:
                    {
                        if (number.Length == 1) { expressionStack.RemoveAt(Count - 1); }
                        else Last = number.Remove(number.Length - 1);
                        goto default;
                    }
                case Constant constant:
                    {
                        Last = GetConstant(constant).ToString();
                        Last = ((String)Last).Remove(((String)Last).Length - 1);
                        goto default;
                    }
                case Operation _:
                    {
                        expressionStack.RemoveAt(expressionStack.Count - 1);
                        goto default;
                    }
                case Modifier _:
                    {
                        expressionStack.RemoveAt(expressionStack.Count - 1);
                        goto default;
                    }
                case Special _:
                    {
                        expressionStack.RemoveAt(expressionStack.Count - 1);
                        goto default;
                    }
                default:
                    {
                        Change.Invoke();
                        break;
                    }
            }
        }

        public static void Calculate(ExpressionStack expStack)
        {
            if (expStack.Count == 0 || expStack.Last is Operation | expStack.Last is Modifier) { return; }

            //modifier calculate--------------------------------------------//
            /*
            if (
                expStack.expressionStack.Count(x => x is Modifier) 
                != 
                expStack.expressionStack.Count(x => x is Special.End)
                ) return;

            UInt16 modifiersCount = 0;
            UInt16 endCount = 0;
            Int16 firstModifiersIndex;
            List<Object> newExpStack = new List<Object>();
            ExpressionStack newExpessionStack;

            do
            {
                firstModifiersIndex = (Int16)expStack.expressionStack.FindIndex(x => x is Modifier);
                if (firstModifiersIndex != -1)
                {
                    modifiersCount++;
                    while (modifiersCount != endCount)
                    {
                        switch (expStack.expressionStack[firstModifiersIndex])
                        {
                            case Special special:
                                {
                                    if (special is Special.End) endCount++;
                                    goto default;
                                }
                            default:
                                {
                                    newExpStack.Add(expStack.expressionStack[firstModifiersIndex]);
                                    expStack.expressionStack.RemoveAt(firstModifiersIndex);
                                    break;
                                }
                        }
                    }
                    newExpessionStack = new ExpressionStack(newExpStack);
                    Calculate(newExpessionStack);
                    expStack.expressionStack.Insert(firstModifiersIndex, newExpessionStack.expressionStack[0]);
                }
                else break;
            } while (expStack.expressionStack.Count(x => x is Modifier) != 0);
            */

            //--------------------------------------------------------------//

            //operation calculate-------------------------------------------//

            var operationsLINQ =
                from obj in expStack.expressionStack
                where obj is Operation
                select (Operation)obj;

            List<Operation> operations = operationsLINQ.ToList<Operation>();

            Int16 operationsCount = (Int16)operations.Count();

            for (Int16 I = 0; I < operationsCount; I++)
            {
                Operation operation = (Operation)(operations.Max(i => (Int16)i));
                operations.RemoveAt(operations.IndexOf(operation));
                String result = "0", value1, value2;
                try
                {
                    (value1, value2) = ValuesCapture(operation);
                    if (operation is Operation.Add) result = OperationPerforming(value1, value2, (d1, d2) => d1 + d2, (i1, i2) => i1 + i2);
                    else if (operation is Operation.Subtrack) result = OperationPerforming(value1, value2, (d1, d2) => d1 - d2, (i1, i2) => i1 - i2);
                    else if (operation is Operation.Multiply) result = OperationPerforming(value1, value2, (d1, d2) => d1 * d2, (i1, i2) => i1 * i2);
                    else if (operation is Operation.Division) result = Division(value1, value2);
                    else if (operation is Operation.Modular) result = Modular(value1, value2);
                }
                catch (DivideByZeroException)
                {
                    expStack.Clear();
                    break;
                }

                expStack.expressionStack[expStack.expressionStack.IndexOf(operation)] = result;
            }
            //--------------------------------------------------------------//

            expStack.Change.Invoke();

            (String, String) ValuesCapture(Operation operation)
            {
                Int16 index0 = (Int16)expStack.expressionStack.IndexOf(operation);
                Int16 index1 = (Int16)(index0 - 1);
                Int16 index2 = (Int16)(index0 + 1);
                String value1 = (String)expStack.expressionStack[index1];
                String value2 = (String)expStack.expressionStack[index2];
                expStack.expressionStack.RemoveAt(index2);
                expStack.expressionStack.RemoveAt(index1);

                return (value1, value2);
            }

            /*
            String ModifierCapture()
            {
                //
            }
            */

            String OperationPerforming(String value1, String value2, Expression<Double> expressionDouble, Expression<Int64> expressionInt)
            {
                if (IsFloat(value1) | IsFloat(value2)) return expressionDouble(Double.Parse(value1), Double.Parse(value2)).ToString();
                return expressionInt(Int64.Parse(value1), Int64.Parse(value2)).ToString();
            }

            String Modular(String value1, String value2)
            {
                if (IsZero(value2)) return value1;
                return OperationPerforming(value1, value2, (d1, d2) => d1 % d2, (i1, i2) => i1 % i2);
            }

            String Division(String value1, String value2)
            {
                if (IsZero(value2)) { expStack.RaiseErrorDialogZeroDivision(); throw new DivideByZeroException(); }

                String result = (Double.Parse(value1) / Double.Parse(value2)).ToString();
                if (IsFloat(result)) return result;
                return result.Split(',')[0];
            }

            Boolean IsFloat(String value)
            {
                if (value.Contains(",") && value.Split(',')[1] != String.Empty) return true;
                return false;
            }

            Boolean IsZero(String value)
            {
                if ((value.Count(x => x == '0') + value.Count(x => x == ',')) == value.Length) return true;
                return false;
            }
        }

        delegate T Expression<T>(T value1, T value2);

        public void ToFloat()
        {
            if (Count == 0 || !(Last is String) || ((String)Last).Contains(",")) { return; }

            Last = ((String)Last) + ",";

            Change.Invoke();

        }

        public void ChangeSign()
        {
            if (Count == 0 || Last is Operation | Last is Modifier | Last is Special) { return; }

            if (Last is Constant) Last = GetConstant((Constant)Last).ToString();

            if (((String)Last).First() == '-') Last = ((String)Last).Remove(0, 1);
            else Last = "-" + ((String)Last);

            Change.Invoke();
        }

        public void Clear() { expressionStack.Clear(); Change.Invoke(); }

        public void ClearElement() { expressionStack.RemoveAt(expressionStack.Count - 1); Change.Invoke(); }

        private void RaiseErrorDialogZeroDivision()
        {
            const string message = "Вы попытались поделить число на 0.\nАй-я-яй! Это плохо! \nИди в угол и подумай над этим.";
            const string caption = "Преступление: Ты поделил на 0";
            var result = MessageBox.Show(message, caption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Error);
            if (result == DialogResult.No) { };
        }
    }
}
