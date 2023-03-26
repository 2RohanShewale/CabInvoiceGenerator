using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavInvoiceGeneratorEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cab Invoice Generator");
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            Ride[] rides = { new Ride(1.0f, 2.0f), new Ride(2.0f, 4.0f) };
            RideRepository rideRepo = new RideRepository();
            rideRepo.AddRide("Rohan", rides);

            rides = rideRepo.GetRides("Rohan");

            InvoiceSummary invoiceSum = invoiceGenerator.CalculateFare(rides);

            Console.WriteLine(invoiceSum.numberOfRides);
            Console.WriteLine(invoiceSum.averageFare);
            Console.WriteLine(invoiceSum.totatlFare);

            Console.ReadKey();
        }
    }
}
