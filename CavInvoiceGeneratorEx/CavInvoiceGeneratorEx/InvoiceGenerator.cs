using System;

namespace CavInvoiceGeneratorEx
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;

        private readonly double MINIMUM_COST_PER_KM;
        private readonly int COST_PER_TIME;
        private readonly int MINIMUM_FARE;

        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    MINIMUM_COST_PER_KM = 15;
                    COST_PER_TIME = 2;
                    MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    MINIMUM_COST_PER_KM = 10;
                    COST_PER_TIME = 1;
                    MINIMUM_FARE = 5;
                }
               
            }
            catch (CabInvoiceExceptions)
            {
                throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        public double CalculateFare(double distance, double time)
        {
            double totalFare = 0;
            try
            {
                totalFare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceExceptions)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
                }
                if (distance <= 0)
                {
                    throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.INVALID_DISTANCE, "Invalid Distance");
                }
                if (time < 0)
                {
                    throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFare, MINIMUM_FARE);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach (var ride in rides)
                {
                    totalFare += CalculateFare(ride.distace, ride.time);
                }
            }
            catch (CabInvoiceExceptions)
            {
                if (rides == null)
                {
                    throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
        public void AddRides(string userId, Ride[] rides)
        {
            try
            {
                rideRepository.AddRide(userId, rides);
            }
            catch (CabInvoiceExceptions)
            {

                if (rides == null)
                {
                    throw new CabInvoiceExceptions(CabInvoiceExceptions.CabInvoiceExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
        }
    }
}