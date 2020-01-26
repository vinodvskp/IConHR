using ICONHRPortal.Models;
using System;
using System.Data;
using System.Web.Mvc;
using ICONHRPortal.Data;
using ICONHRPortal.Model;


namespace ICONHRPortal.Controllers
{
    public class EmployeesController : BaseMVCController
    {
        // GET: Employees
        #region Variables
        ICONHRRepository repository = new ICONHRRepository();
        EmployeeDetails empDetails = new EmployeeDetails();
        string responseMsg = string.Empty;
        #endregion
        public ActionResult Index()
        {
            return View();
        }
    }
}