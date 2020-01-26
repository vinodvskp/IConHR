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

namespace ICONHRPortal.BusninessLogic.IService
{

    public interface IEmployeeLogBookService
    {
        IEnumerable<EmployeeLogBookModel> GetEmployeeLogBookByType(string type);
        IEnumerable<EmployeeLogBookModel> GetEmployeeLogBooks(int empId, string type);
       EmployeeLogBookModel GetById(int id);
        int Save(EmployeeLogBookModel model);
        int Update(EmployeeLogBookModel model);
        int Delete(long id);
    }
}
