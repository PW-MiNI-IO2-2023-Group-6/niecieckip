using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            int result = 0;
            char[] separators = { ',', '\n'};

            if (String.IsNullOrEmpty(str))
                return 0;

            if (str.StartsWith("//"))
            {
                separators.Append(str[2]);
                str = str[3..];
            }

            var split = str.Split(separators);

            foreach (var s in split)
            {
                if (int.TryParse(s, out int number) && number <= 1000)
                {
                    if (number < 0)
                        throw new ArgumentException();

                    result += number;
                }
            }

            return result;
        }
    }
}
