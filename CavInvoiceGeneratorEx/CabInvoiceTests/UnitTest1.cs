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
            Ride[] rides = { new Ride(2.0, 5), new(0.1, 1) };

            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectSummary = new InvoiceSummary(2,30.0);
            Assert.AreEqual(expectSummary,summary);
        }
    }
}