namespace EngineeringCalculator
{
    internal static class Output
    {
        public static String ExprassionToRecord(ref List<Composite> expression, Boolean debug)
        {
            List<String> record = new List<String>();

            foreach (Composite composite in expression) record.Add(composite.Record);

            String separator = debug ? " | " : " ";

            return String.Join(separator, record);
        }
    }
}
