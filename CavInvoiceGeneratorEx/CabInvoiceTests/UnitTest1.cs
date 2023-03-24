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
       
    }
}