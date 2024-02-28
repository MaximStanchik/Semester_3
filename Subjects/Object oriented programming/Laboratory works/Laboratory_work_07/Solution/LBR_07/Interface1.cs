using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMoveAndSmart
{
    public interface IMoveable
    {
        void Move();
        void Stop();
        void MaxSpeed();
        void MinSpeed();
    }
    public interface ISmart
    {
        void Think();
        void Speak();
    }
}