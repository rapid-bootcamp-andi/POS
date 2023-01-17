using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(AplikasiContext context)
        {
            _service = new EmployeeService(context);
        }

        public IActionResult GetAllEmployee()
        {
            var Data = _service.GetEmployee();
            return View(Data);
        }

        public IActionResult DetailsEmployee(int? id)
        {
            var DataDetail = _service.GetEmployeeById(id);
            return View(DataDetail);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult _AddEmployee()
        {
            return PartialView("_AddEmployee");
        }

        public IActionResult SaveEmployee([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveEmployee(new Employee(request));
                return Redirect("GetAllEmployee");
            }
            return View("AddEmployee", request);
        }

        public IActionResult EditEmployee(int? id)
        {
            var entity = _service.GetEmployeeById(id);
            return View(entity);
        }

        public IActionResult UpdateEmployee([Bind("EmployeeId, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateEmployee(request);
                return Redirect("GetAllEmployee");
            }
            return View("EditEmployee", request);

        }

        public IActionResult DeleteEmployee(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllEmployee");
        }
    }
}
