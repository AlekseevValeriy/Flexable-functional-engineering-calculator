/*        private class ModifierStack
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
*/