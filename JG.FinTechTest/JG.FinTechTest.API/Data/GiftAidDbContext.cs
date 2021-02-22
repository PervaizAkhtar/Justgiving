using JG.FinTechTest.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Data
{
    public class GiftAidDbContext: DbContext 
    {
        public GiftAidDbContext(DbContextOptions<GiftAidDbContext> options): base(options)
        {

        }

        public DbSet<Donor> Donors { get; set; }
    }
}
