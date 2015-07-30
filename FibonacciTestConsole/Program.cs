using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;

namespace FibonacciTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int position = 0;
            foreach (int fib in FibonacciCounter.GetFibonacciValue(22))
            {
                position++;
                Console.WriteLine("{0}:{1}",position,fib);
            }
        }
    }
}
