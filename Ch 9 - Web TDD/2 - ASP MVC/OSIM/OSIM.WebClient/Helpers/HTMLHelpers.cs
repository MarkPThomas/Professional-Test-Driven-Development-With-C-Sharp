using System;

namespace OSIM.WebClient.Helpers
{
    public static class HTMLHelpers
    {
        public static string Truncate(string input, int length)
        {
            if (length == 0)
                return input;

            if (String.IsNullOrEmpty(input))
                return string.Empty;

            if (input.Length <= length)
                return input;
            else
                return input.Substring(0, length) + "...";

        }
    }
}