using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerTestConsole
{
    class FirstClient
    {
        public void PrintMessage(Object sender, EventArgs eventArgs)
        {
            Console.WriteLine("FirstClient:PrintMessage");
        }
    }
}
