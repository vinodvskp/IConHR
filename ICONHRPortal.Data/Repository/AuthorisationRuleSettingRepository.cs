using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.Data.Repository
{

    public class AuthorisationRuleSettingRepository : GenericRepository<tblAuthorisationRuleSetting>, IAuthorisationRuleSettingRepository
    {
        public AuthorisationRuleSettingRepository(ICONHRContext context) : base(context)
        {

        }
    }
}
