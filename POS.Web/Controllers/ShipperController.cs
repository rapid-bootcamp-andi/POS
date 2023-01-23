using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly ShipperService _service;

        public ShipperController(AplikasiContext context)
        {
            _service = new ShipperService(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetShippers();
            return View(data);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            var dataDetail = _service.GetShipperById(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CompanyName, Phone")] ShipperModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveShipper(new Shipper(request));
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var model = _service.GetShipperById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("ShipperId, CompanyName, Phone")] ShipperModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateShipper(request);
                return Redirect("GetAll");
            }
            return View("Edit", request);
        }

        public IActionResult Delete(int? id)
        {
            _service.DeleteShipper(id);
            return Redirect("/Shipper/GetAll");
        }
    }
}