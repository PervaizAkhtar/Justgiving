using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Exceptions
{
    public class MaximumDonationException : Exception
    {
        public MaximumDonationException()
        {

        }
        public MaximumDonationException(string message) : base(message)
        {
        }

        public MaximumDonationException(string message, Exception innerExceptino) : base(message, innerExceptino)
        {

        }
    }
}
