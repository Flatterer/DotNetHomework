using System;
using System.Collections.Generic;
using System.Text;

namespace Homework4_2
{
    /*public delegate void AlarmHandler(object sender);*/
    class Clock
    {
        public event Action Tick;
        public event Action Alarm;

        public void Start()
        {
            Tick();
            Alarm();
        }
    }
}
