using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;
        public SupplierController(AplikasiContext context)
        {
            _service = new SupplierService(context);
        }

        public IActionResult GetAllSupplier()
        {
            var Data = _service.GetSupplier();
            return View(Data);
        }

        public IActionResult DetailsSupplier(int? id)
        {
            var DataDetail = _service.GetSupplierById(id);
            return View(DataDetail);
        }

        public IActionResult AddSupplier()
        {
            return View();
        }

        public IActionResult SaveSupplier([Bind("CompanyName, ContactName, ContactTitle, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveSupplier(new Supplier(request));
                return Redirect("GetAllSupplier");
            }
            return View("AddSupplier", request);
        }

        public IActionResult EditSupplier(int? id)
        {
            var entity = _service.GetSupplierById(id);
            return View(entity);
        }

        public IActionResult UpdateSupplier([Bind("Id, CompanyName, ContactName, ContactTitle, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                Supplier supplierEntity = new Supplier(request);
                supplierEntity.Id = request.Id;
                _service.UpdateSupplier(supplierEntity);
                return Redirect("GetAllSupplier");
            }
            return Redirect("AddSupplier");
        }

        public IActionResult DeleteSupplier(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllSupplier");
        }
    }
}
