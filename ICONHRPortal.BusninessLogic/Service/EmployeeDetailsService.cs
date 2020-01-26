using AutoMapper;
using ICONHRPortal.BusninessLogic.IService;
using ICONHRPortal.Data;
using ICONHRPortal.Data.IRepository;
using ICONHRPortal.Data.Models;
using ICONHRPortal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICONHRPortal.BusninessLogic.Service
{
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        private readonly IEmployeeDetailsRepository _employeeDetailsRepository = null;
        private readonly IEmployeeNotificationRepository _employeeNotificationRepository = null;
        public EmployeeDetailsService(IEmployeeDetailsRepository employeeDetailsRepository, IEmployeeNotificationRepository employeeNotificationRepository)
        {
            _employeeDetailsRepository = employeeDetailsRepository;
            _employeeNotificationRepository = employeeNotificationRepository;
        }

        public EmployeeDetailsModel GetEmployeeDetailsById(int id)
        {
            
            return Mapper.DynamicMap<EmployeeDetailsModel>(_employeeDetailsRepository.Get(id));

        }
        public IList<EmployeeDetailsModel> GetAdminDetails()
        {
            return Mapper.DynamicMap<List<EmployeeDetailsModel>>(_employeeDetailsRepository.Find(x => x.EmpRoleID == 1).ToList());
        }
        public IList<EmployeeDetailsModel> GetEmployeeDetailsModels(int? mgrId)
        {
            return Mapper.DynamicMap<List<EmployeeDetailsModel>>(_employeeDetailsRepository.GetEmployeeDetails(mgrId).ToList());
        }
        public EmployeeDetailsModel GetEmployee(int Id)
        {
            return _employeeDetailsRepository.GetEmployee(Id);
        }

        public IEnumerable<ChoiceOptionModel> GetEmplyeeNamesByCompanyId(int id)
        {
            return _employeeDetailsRepository.Find(x => x.CompanyID == id).Select(x => new ChoiceOptionModel
            {
                id = x.EmpID,
                text = x.EmpName
            }).ToList();
        }

        public bool HasEmailIdExists(string email)
        {
            return _employeeDetailsRepository.Find(x => x.EmailID.ToLower() == email.ToLower()).Any();
        }

        public bool HasCompanyUrlxists(string CompanyUrl)
        {
            // company url will empty when adding employee after registration
            if (CompanyUrl == "")
            {
                return false;
            }
            return _employeeDetailsRepository.Find(x => x.CompanyUrl.ToLower() == CompanyUrl.ToLower()).Any();
        }

        public int SaveBulkEmployees(List<EmployeeDetailsModel> employees)
        {
            var employeesEntity = Mapper.DynamicMap<List<tblEmployeeDetail>>(employees);
            return _employeeDetailsRepository.SaveBulkEmployees(employeesEntity);
        }

        public int SaveEmployee(EmployeeDetailsModel model)
        {

            //branchModel.RecordStatus = "A";
            var employeeDetail = Mapper.DynamicMap<tblEmployeeDetail>(model);
            _employeeDetailsRepository.Add(employeeDetail);
            return _employeeDetailsRepository.SaveChanges();
        }

        public int UpdateEmployee(EmployeeDetailsModel model)

        {
            var employeeDetail = _employeeDetailsRepository.GetEmployeeDetail(model.EmpID);
            if (employeeDetail != null)
            {
                employeeDetail.EmpID = model.EmpID;
                employeeDetail.EmpName = model.EmpName;
                employeeDetail.EmailID = model.EmailID;
                employeeDetail.PhoneNumber = model.PhoneNumber;
                employeeDetail.Gender = model.Gender;
                employeeDetail.Address = model.Address;
                employeeDetail.ProfilePhoto = model.ProfilePhoto;
                employeeDetail.DateOfBirth = model.DateOfBirth;
                employeeDetail.PostalCode = model.PostalCode;
                employeeDetail.CountryID = model.CountryID;
                employeeDetail.FileName = model.FileName;
                _employeeDetailsRepository.Update(employeeDetail);
                return _employeeDetailsRepository.SaveChanges();
            }

            return 0;
        }
        //notifications

        public IList<EmployeeNotificationModel> GetNotificaitons()
        {
            return Mapper.DynamicMap<List<EmployeeNotificationModel>>(_employeeNotificationRepository.GetAll().Where(c=>c.NotificationShownStatus==false).ToList());
        }
        public int updateNotificaitonStatus(EmployeeNotificationModel model)
        {
            var employeeDetail = _employeeNotificationRepository.Get(model.NotificationID);
            if (employeeDetail != null)
            {
                employeeDetail.NotificationShownStatus = true; ;
                employeeDetail.LastUpdatedBy = model.LastUpdatedBy;
                employeeDetail.LastUpdatedDate =DateTime.Now;
                _employeeNotificationRepository.Update(employeeDetail);
                return _employeeNotificationRepository.SaveChanges();
            }
            return 0;
        }

    }
}
