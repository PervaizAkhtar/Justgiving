using JG.FinTechTest.API.Data;
using JG.FinTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Repositories
{
    public class GiftAidRepository : IGiftAidRepository
    {
        private readonly GiftAidDbContext _dbContext;
        public GiftAidRepository(GiftAidDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task SaveDonor(Donor donor)
        {
            _dbContext.Donors.Add(donor);

            await _dbContext.SaveChangesAsync();
        }
    }
}
