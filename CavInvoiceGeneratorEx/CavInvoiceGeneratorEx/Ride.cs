using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavInvoiceGeneratorEx
{
    public class Ride
    {
        public double distace;
        public double time;

        public Ride(double distace, float time)
        {
            this.distace = distace;
            this.time = time;
        }
    }
}
