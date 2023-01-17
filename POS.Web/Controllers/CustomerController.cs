using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        public CustomerController(AplikasiContext context)
        {
            _service = new CustomerService(context);
        }

        public IActionResult GetAllCustomer()
        {
            var Data = _service.GetCustomer();
            return View(Data);
        }

        public IActionResult DetailsCustomer(int? id)
        {
            var DataDetail = _service.GetCustomerById(id);
            return View(DataDetail);
        }

        public IActionResult AddCustomer()
        {
            return View();
        }

        public IActionResult _AddCustomer()
        {
            return PartialView("_AddCustomer");
        }

        public IActionResult SaveCustomer([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveCustomer(new Customer(request));
                return Redirect("GetAllCustomer");
            }
            return View("AddCustomer", request);
        }

        public IActionResult EditCustomer(int? id)
        {
            var entity = _service.GetCustomerById(id);
            return View(entity);
        }

        public IActionResult UpdateCustomer([Bind("CustomerId, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCustomer(request);
                return Redirect("GetAllCustomer");
            }
            return View("EditCustomer", request);

        }

        public IActionResult DeleteCustomer(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllCustomer");
        }
    }
}
