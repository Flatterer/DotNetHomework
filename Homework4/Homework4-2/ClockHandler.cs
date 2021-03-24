using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Homework4_2
{
    class ClockHandler
    {
        private Clock clock;
        public ClockHandler(Clock c)
        {
            this.clock = c;
            c.Tick += TickOn;
            c.Alarm += AlarmOn;
        }
        
        public void TickOn()
        {
            bool unAlarmed = true;
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            DateTime alarmTime = new DateTime();
            alarmTime = dt.AddSeconds(2);//set alarm time
            Console.WriteLine("AlarmTime:   " + alarmTime);
            while (unAlarmed)
            {
                if ((alarmTime - dt).TotalMilliseconds < 900)
                {
                    unAlarmed = false;
                    AlarmOn();
                    break;
                }
                Console.WriteLine("Time: " + dt.ToString() + "   Clock Tick");
                Thread.Sleep(1000);
                dt = DateTime.Now;
            }
        }
        public void AlarmOn()
        {
            bool toBeContinue = true;
            while (toBeContinue)
            {
                Console.WriteLine("Alarm!!!");
                Thread.Sleep(1000);
                ConsoleKeyInfo consoleKeyInfo;
                if (System.Console.KeyAvailable)
                {
                    consoleKeyInfo = System.Console.ReadKey(true);
                    if (consoleKeyInfo.KeyChar == (char)027)
                    {
                        toBeContinue = false;
                    }
                }
            }
        }
    }
}
