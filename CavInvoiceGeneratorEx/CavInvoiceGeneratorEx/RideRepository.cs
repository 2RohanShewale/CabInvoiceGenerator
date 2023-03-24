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

        public void AddRide(string userId, Ride[] rides)
        {
            bool rideList = userRides.ContainsKey(userId);
            try
            {
                if (!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    userRides.Add(userId, list);
                }
            }
            catch (CabInvoiceExceptions)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.NULL_RIDES, "Rides Are Null");
            }
        }
        public Ride[] GetRides(string userId)
        {
            try
            {
                return userRides[userId].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.INVALID_USER_ID, "Invalid User ID");
            }
        }
    }
}
