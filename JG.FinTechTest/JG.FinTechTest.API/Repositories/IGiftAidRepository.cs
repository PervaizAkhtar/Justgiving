using JG.FinTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API.Repositories
{
    public interface IGiftAidRepository
    {
        public void  SaveDonor(Donor donor);
    }
}
