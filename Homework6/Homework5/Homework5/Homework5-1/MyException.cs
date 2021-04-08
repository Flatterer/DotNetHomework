using System;
using System.Collections.Generic;
using System.Text;

namespace Homework5_1
{
    class MyException:  Exception
    {
        public MyException(string message): base(message) { }
    }
}
