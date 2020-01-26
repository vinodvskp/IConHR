using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Model;

namespace ICONHRPortal.ApiService
{
    public class HolidaysAbsenceSettingApiController : BaseApiController
    {
        private readonly IHolidaysAbsenceSettingService _holidaysAbsenceSettingService = null;
        public HolidaysAbsenceSettingApiController(IHolidaysAbsenceSettingService holidaysAbsenceSettingService)
        {
            _holidaysAbsenceSettingService = holidaysAbsenceSettingService;
        }
        // GET api/<controller>
        public IEnumerable<tblHolidays_AbsenceSettingsModel> Get()
        {
            return _holidaysAbsenceSettingService.GetHolidaysAbsenceSettings();
        }

        // GET api/<controller>/5
        public tblHolidays_AbsenceSettingsModel Get(int id)
        {
            id = CompanyId;
            return _holidaysAbsenceSettingService.GetHolidaysAbsenceSetting(id);
        }

        // POST api/<controller>
        public void Post([FromBody]tblHolidays_AbsenceSettingsModel model)
        {
            model.CompanyID = base.CompanyId;
            if (model.Holidays_AbsenceSettingID <=0  )
            {
                _holidaysAbsenceSettingService.Save(model);
            }
            else
            {
                _holidaysAbsenceSettingService.Update(model);
            }
           
        }

        // PUT api/<controller>/5
        public void Put([FromBody]tblHolidays_AbsenceSettingsModel model)
        {
            _holidaysAbsenceSettingService.Update(model);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}