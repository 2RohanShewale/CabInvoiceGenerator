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
            InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(1.0f, 2.0f), new Ride(2.0f, 4.0f) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            Console.WriteLine(summary.numberOfRides);
            Console.WriteLine(summary.totatlFare);
            Console.WriteLine(summary.averageFare);


            Console.ReadKey();
        }
    }
}
