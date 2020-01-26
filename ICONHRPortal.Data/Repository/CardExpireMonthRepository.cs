using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;

namespace ICONHRPortal.Data.Repository
{
   public class CardExpireMonthRepository : GenericRepository<lkpCardExpMonth>, ICardExpireMonthRepository
    {
        public CardExpireMonthRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
