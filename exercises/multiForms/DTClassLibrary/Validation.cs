using System;

namespace DTClassLibrary
{
    public static class Validation
    {
        public static bool IsNumeric(string input)
        {
            try
            {
                Convert.ToDouble(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsInteger(string input) =>
            (IsNumeric(input) && !input.Contains(".")) ? true : false;
    }
}
