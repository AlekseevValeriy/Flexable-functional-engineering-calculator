using System.Collections.Generic;
using System.Linq.Expressions;
using FFEC;

namespace FFEC
{
    internal class SButton : Button, IRemoveable
    {
        public String[] Data { get; set; }
        public Boolean Locked { get; set; } = false;
        public SButton() : base() { }
    }

    internal class STextBox : TextBox, IRemoveable
    {
        public String[] Data { get; set; }
        public Boolean Locked { get; set; } = false;
        private ConverterToStringByRule Rule { get; }
        public void SetTextByRule (List<Composite> expression) => Text = Rule(expression);
        public STextBox(ConverterToStringByRule rule = null) : base() { Rule = rule is not null ? rule : (List <Composite> expression, Boolean debug) => ""; }
    }

    delegate String ConverterToStringByRule(List<Composite> expression, Boolean debug = false);

    internal interface IRemoveable: IDataStorable { }

    internal interface IDataStorable
    {
        public String[] Data { get; set; }
        public Boolean Locked { get; set; }
    }
}
