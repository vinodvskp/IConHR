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
   
    public class EmployeeLogBookService : IEmployeeLogBookService
    {
        private readonly IEmployeeLogBookRepository _employeeLogBookRepository = null;

        public EmployeeLogBookService(IEmployeeLogBookRepository employeeLogBookRepository)
        {
            _employeeLogBookRepository = employeeLogBookRepository;
        }

        public int Delete(long id)
        {
            var logbook = _employeeLogBookRepository.Find(x => x.LogBookID == id).FirstOrDefault();
            if(logbook!=null)
            {
                _employeeLogBookRepository.Remove(logbook);
                _employeeLogBookRepository.SaveChanges();
            }
        
            return 0;
        }
        public EmployeeLogBookModel GetById(int id)
        {
            return Mapper.DynamicMap<EmployeeLogBookModel>(_employeeLogBookRepository.Find(x => x.LogBookID == id).FirstOrDefault());
        }
        public IEnumerable<EmployeeLogBookModel> GetEmployeeLogBookByType(string type)
        {
            return Mapper.DynamicMap<List<EmployeeLogBookModel>>(_employeeLogBookRepository.Find(x => x.DocumentType == type).ToList());
        }
        public IEnumerable<EmployeeLogBookModel> GetEmployeeLogBooks(int empId, string type)
        {
            return Mapper.DynamicMap<List<EmployeeLogBookModel>>(_employeeLogBookRepository.Find(x => x.DocumentType == type && x.EmpId==empId).ToList());
        }

        public int Save(EmployeeLogBookModel model)
        {
            var employeeTimesheet = Mapper.DynamicMap<tblLogBook>(model);
            _employeeLogBookRepository.Add(employeeTimesheet);
            return _employeeLogBookRepository.SaveChanges();
        }

        public int Update(EmployeeLogBookModel model)
        {
            var employeeTimesheet = _employeeLogBookRepository.Find(x => x.LogBookID == model.LogBookID).FirstOrDefault();
            if (employeeTimesheet != null)
            {
                Mapper.CreateMap<EmployeeLogBookModel, tblLogBook>()
                    .ForMember(dest => dest.LogBookID,
                        opt => opt.Ignore()); // ignore primary key while update/delete
                tblLogBook employeeTimesheetEntity = (tblLogBook)Mapper.Map(model, employeeTimesheet);

                return _employeeLogBookRepository.SaveChanges();
            }

            return 0;
        }
    }
}
