using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        public OrderController(AplikasiContext context)
        {
            _service = new OrderService(context);
        }

        public IActionResult GetAllOrder()
        {
            var Data = _service.GetOrder();
            return View(Data);
        }

        public IActionResult DetailsOrder(int? id)
        {
            var DataDetail = _service.GetOrderById(id);
            return View(DataDetail);
        }

        public IActionResult AddOrder()
        {
            return View();
        }

        public IActionResult _AddOrder()
        {
            return PartialView("_AddOrder");
        }

        public IActionResult SaveOrder([Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveOrder(new Order(request));
                return Redirect("GetAllOrder");
            }
            return View("AddOrder", request);
        }

        public IActionResult EditOrder(int? id)
        {
            var entity = _service.GetOrderById(id);
            return View(entity);
        }

        public IActionResult UpdateOrder([Bind("OrderId, CustomerId, EmployeeId, OrderDate, RequiredDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrder(request);
                return Redirect("GetAllOrder");
            }
            return View("EditOrder", request);

        }

        public IActionResult DeleteOrder(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllOrder");
        }
    }
}
