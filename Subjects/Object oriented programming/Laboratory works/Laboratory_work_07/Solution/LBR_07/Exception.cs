using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excep
{
    class NothingToDelete : ArgumentException
    {
        public NothingToDelete(string message) : base(message)
        {
        }
    }
    class NULLException : Exception
    {
        public int value;
        private object item;

        public NULLException(string message, int val) : base(message)
        {
            value = val;
        }

        public NULLException(string message, object item) : base(message)
        {
            this.item = item;
        }
    }
}