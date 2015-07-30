using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueueLib;

namespace QueueTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue<int> CQ = new CustomQueue<int>();
            CQ.Enqueue(1);
            CQ.Enqueue(2);
            CQ.Enqueue(3);
            CQ.Enqueue(4);
            CQ.Enqueue(5);            
            Console.WriteLine(CQ.Peek());
            int first = CQ.Dequeue();
            Console.WriteLine(CQ.Peek());
            foreach (int i in CQ)
                Console.Write(i + " ");
            Console.WriteLine();
            Console.WriteLine(CQ.Peek());

        }
    }
}
