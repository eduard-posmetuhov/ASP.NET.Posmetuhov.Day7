using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public class Timer
    {
        public int Span{get;set;}
        public event EventHandler<EventArgs> TimeEnd = delegate { };

        public Timer(int delay)
        {
            Span = delay;
        }

        public void StartTimer()
        {
            Thread.Sleep(Span);
            OnTimeEnd(new EventArgs());
        }

        private void OnTimeEnd(EventArgs e)
        {
            TimeEnd(this, e);
        }
    }
}
