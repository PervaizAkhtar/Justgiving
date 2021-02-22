using System;
using System.Collections.Generic;
using System.Text;

namespace JG.FinTechTest.Domain
{
    public class Donor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string PostCode { get; set; }

        public double DonationAmount { get; set; }
    }
}
