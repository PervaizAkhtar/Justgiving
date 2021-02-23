using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JG.FinTechTest.Domain
{
    public class Donor
    {
        public Donor()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        public double DonationAmount { get; set; }
    }
}
