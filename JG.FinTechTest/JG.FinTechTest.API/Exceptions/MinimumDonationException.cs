using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Exceptions
{
    public class MinimumDonationException : Exception
    {
        public MinimumDonationException()
        {
        }

        public MinimumDonationException(string message) : base(message)
        {
        }

        public MinimumDonationException(string message, Exception innerExceptino) : base (message,innerExceptino)
        {

        }
    }
}
