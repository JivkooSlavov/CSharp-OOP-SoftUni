using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Cars
{
    interface ICar
    {
        public void Start();
        public void Stop();
        public void Acceleration(int force);

        public void Deceleration(int force);
    }
}
