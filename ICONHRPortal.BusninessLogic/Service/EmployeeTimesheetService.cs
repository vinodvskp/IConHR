using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class EmployeeTimesheetService : IEmployeeTimesheetService
    {
        private readonly IEmployeeTimesheetRepository _employeeTimesheetRepository = null;

        public EmployeeTimesheetService(IEmployeeTimesheetRepository employeeTimesheetRepository)
        {
            _employeeTimesheetRepository = employeeTimesheetRepository;
        }

        public int Delete(long id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<EmployeeTimesheetModel> GetTimeSheetsByRptMng(long id)
        {
            return Mapper.DynamicMap<List<EmployeeTimesheetModel>>(_employeeTimesheetRepository.Find(x => x.Approver == id).ToList());
        }
        public IEnumerable<EmployeeTimesheetModel> GetEmployeeTimesheets(long id)
        {
            return Mapper.DynamicMap<List<EmployeeTimesheetModel>>(_employeeTimesheetRepository.Find(x => x.EmpID == id).ToList());
        }
        public EmployeeTimesheetModel GetEmployeeTimesheet(long id)
        {
            return Mapper.DynamicMap<EmployeeTimesheetModel>(_employeeTimesheetRepository.Find(x => x.TimesheetID == id).FirstOrDefault());
        }

        public IEnumerable<EmployeeTimesheetModel> GetEmployeeTimesheets()
        {
            return Mapper.DynamicMap<List<EmployeeTimesheetModel>>(_employeeTimesheetRepository.GetAll().ToList());
        }

        public int Save(EmployeeTimesheetModel model)
        {
            var employeeTimesheet = Mapper.DynamicMap<EmployeeTimesheet>(model);
            _employeeTimesheetRepository.Add(employeeTimesheet);
            return _employeeTimesheetRepository.SaveChanges();
        }

        public int Update(EmployeeTimesheetModel model)
        {
            var employeeTimesheet = _employeeTimesheetRepository.Find(x => x.TimesheetID == model.TimesheetID).FirstOrDefault();
            if (employeeTimesheet != null)
            {
                Mapper.CreateMap<EmployeeTimesheetModel, EmployeeTimesheet>()
                    .ForMember(dest => dest.TimesheetID,
                        opt => opt.Ignore()); // ignore primary key while update/delete
                EmployeeTimesheet employeeTimesheetEntity = (EmployeeTimesheet) Mapper.Map(model, employeeTimesheet);

                return _employeeTimesheetRepository.SaveChanges();
            }

            return 0;
        }
    }
}
