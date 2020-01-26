using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data.Repository
{
   public class CountryRepository : GenericRepository<lkpCountry>, ICountryRepository
    {
        public CountryRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
