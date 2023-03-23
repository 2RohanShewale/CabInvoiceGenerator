using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CavInvoiceGeneratorEx
{
    public class CabInvoiceExceptions:Exception
    {
        public enum CabInvoiceExceptionType
        {
            INVALID_RIDE_TYPE,
            INVALID_DISTANCE,
            INVALID_TIME,
            NULL_RIDES,
            INVALID_USER_ID
        }
        CabInvoiceExceptionType type;
        public CabInvoiceExceptions(CabInvoiceExceptionType type, string message): base(message)
        {
            this.type = type;
        }
    }
}
