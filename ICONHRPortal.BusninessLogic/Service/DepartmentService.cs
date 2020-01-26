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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository = null;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<ChoiceOptionModel> GetDepartments()
        {
            return _departmentRepository.GetAll().Select(x => new ChoiceOptionModel
            {
                id = x.DeptID,
                text = x.DeptName
            }).ToList();
        }

        public int SaveDepartment(DepartmentModel model)
        {
            model.Status = true;
            var department = Mapper.DynamicMap<lkpDepartment>(model);
            _departmentRepository.Add(department);
            return _departmentRepository.SaveChanges();
        }
    }
}
