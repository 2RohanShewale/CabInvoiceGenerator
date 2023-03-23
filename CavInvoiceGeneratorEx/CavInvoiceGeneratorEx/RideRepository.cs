using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavInvoiceGeneratorEx
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides = null;
        public RideRepository()
        {
            userRides = new Dictionary<string, List<Ride>>();
        }
    }
}
