using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregationApp.Application.Database
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var sb = new StringBuilder();
            bool wasLowerCase = false;

            foreach (char c in input)
            {
                if (char.IsUpper(c))
                {
                    if (wasLowerCase)
                        sb.Append('_');
                    sb.Append(char.ToLower(c));
                    wasLowerCase = false;
                }
                else
                {
                    sb.Append(c);
                    wasLowerCase = true;
                }
            }

            return sb.ToString();
        }
    }
}
