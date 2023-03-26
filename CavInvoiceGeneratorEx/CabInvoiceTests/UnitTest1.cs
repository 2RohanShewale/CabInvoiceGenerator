using CavInvoiceGeneratorEx;
namespace CabInvoiceTests
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [Test]
        public void GivenDistanceAndTimeShouldReutrnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double fare = invoiceGenerator.CalculateFare(2.0,5);
            Assert.AreEqual(25, fare);
        }
        [Test]
        public void GivenMultipleRidesShouldDiffererntInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectSummary = new InvoiceSummary(2,30.0);
            Assert.AreEqual(expectSummary,summary);
        }
        [Test]
        public void GivenSetOfRidesShouldReturnTotalFair()
        {
            Ride[] rides = { new Ride(1.0f, 2.0f), new Ride(2.0f, 4.0f) };
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            InvoiceSummary invoice = invoiceGenerator.CalculateFare(rides);
            Assert.AreEqual(36, invoice.totatlFare);
        }
        [Test]
        public void GivenUserId_ShouldReturnListOfRides()
        {

            RideRepository rideRepository = new RideRepository();

            Ride[] rides = { new Ride(1.0f, 2.0f), new Ride(2.0f, 4.0f) };

            rideRepository.AddRide("Rohan", rides);

            Ride[] arrayOfRides = rideRepository.GetRides("Rohan");

            Assert.AreEqual(rides, arrayOfRides);
        }

    }
}