﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    [Serializable]
    class Customer
    {
        public string customerName
        {
            get;set;
        }
        public Customer(string name)
        {
            customerName = name;
        }
    }
}
