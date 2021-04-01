using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    class Time
    {
        public int h
        {
            get;set;
        }
        public int m
        {
            get;set;
        }
        public int s
        {
            get;set;
        }
        public Time(int h, int m, int s)
        {
            if (h < 24 && h >= 0 && m >=0 && m < 60 && s >= 0 && s < 60)
            {
                this.h = h;
                this.m = m;
                this.s = s;
            }
            else
            {
                throw new Exception("Time error");
            }
        }
        public string ToString()
        {
            return $"{h}:{m}:{s}";
        }
    }
}
