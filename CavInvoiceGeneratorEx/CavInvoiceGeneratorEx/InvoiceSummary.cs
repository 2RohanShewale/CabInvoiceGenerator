namespace CavInvoiceGeneratorEx
{
    public class InvoiceSummary
    {
        private int numberOfRides;
        private double totatlFare;
        private double averageFare;

        public InvoiceSummary(int numberOfRides, double totatlFare)
        {
            this.numberOfRides = numberOfRides;
            this.totatlFare = totatlFare;
            averageFare = this.numberOfRides / this.numberOfRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if(!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputedObject = (InvoiceSummary)obj;
            return numberOfRides == inputedObject.numberOfRides && totatlFare == inputedObject.totatlFare && averageFare == inputedObject.averageFare;
        }
        public override int GetHashCode()
        {
            return numberOfRides.GetHashCode() ^ totatlFare.GetHashCode() ^ averageFare.GetHashCode();
        }
    }
}