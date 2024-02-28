using Class3;
using Class2;
using IMoveAndSmart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static Class3.Transport;
using System.Runtime.InteropServices.ComTypes;

namespace Print
{
    class Printer
    {
        public void IAmPrinting(Transport someobj)
        {
            Type objectType = someobj.GetType();
            string objectString = someobj.ToString();
            Console.WriteLine("Object Type: " + objectType);
            Console.WriteLine("Object String: " + objectString);
        }
    }
}