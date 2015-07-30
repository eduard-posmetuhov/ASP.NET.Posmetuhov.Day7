using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public class FibonacciCounter
    {
        const int first = 0;
        const int second = 1;
        public static IEnumerable<int> GetFibonacciValue(int number)
        {
            if (number <= 0)
                throw new ArgumentException("Bad position value");
            yield return first;
            if (number > 1) yield return second;
            int prev = first, next = second, currentValue = 0;
            for (int i = 3; i <= number;i++ )
                {
                    currentValue = prev + next;
                    prev = next;
                    next = currentValue;
                    yield return currentValue;
                }
        }
    }
}
