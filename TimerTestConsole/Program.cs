using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer;

namespace TimerTestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите время задержки таймера в секундах:");
                int delay = 0;
                if (!Int32.TryParse(Console.ReadLine(), out delay) || delay < 0)
                    throw new InvalidCastException("Bad delay");
                Timer.Timer t = new Timer.Timer(delay * 1000);
                FirstClient fc = new FirstClient();
                SecondClient sc = new SecondClient();
                t.TimeEnd += fc.PrintMessage;
                t.TimeEnd += sc.PrintMessage;
                t.StartTimer();
                Console.ReadLine();
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            

        }
    }
}
