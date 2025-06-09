namespace QL2CarAgeIdentifier
{
    public static class AgeIdentifier
    {
        public static string GetNext(string identifier)
        {
            if (!int.TryParse(identifier, out int number) || number < 0 || number > 99)
            {
                throw new FormatException("Invalid Age Identifier");
            }

            if (number < 50)
            {
                // March → September
                return (number + 50).ToString("D2");
            }
            else
            {
                // September → March of next year
                int nextYear = (number - 50 + 1) % 100;
                return nextYear.ToString("D2");
            }
        }
    }

}
