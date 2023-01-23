using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly CustomerService _customerService;
        private readonly EmployeeService _employeeService;
        private readonly ProductService _productService;
        private readonly ShipperService _shipperService;

        public OrderController(AplikasiContext context)
        {
            _service = new OrderService(context);
            _customerService = new CustomerService(context);
            _employeeService = new EmployeeService(context);
            _productService = new ProductService(context);
            _shipperService = new ShipperService(context);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.GetOrders();
            return View(data);
        }

        [HttpGet]
        public IActionResult Detail(int? id)
        {
            var dataDetail = _service.GetOrderInvoice(id);
            return View(dataDetail);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomer(), "CustomerId", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployee(), "EmployeeId", "FirstName");
            ViewBag.Product = new SelectList(_productService.GetProduct(), "ProductId", "ProductName");
            ViewBag.Shipper = new SelectList(_shipperService.GetShippers(), "ShipperId", "CompanyName");
            return View();
        }

        [HttpGet]
        public IActionResult AddModal()
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomer(), "CustomerId", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployee(), "EmployeeId", "FirstName");
            ViewBag.Product = new SelectList(_productService.GetProduct(), "ProductId", "ProductName");
            ViewBag.Shipper = new SelectList(_shipperService.GetShippers(), "ShipperId", "CompanyName");
            return View("_Add");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CustomerId, EmployeesId, ShipperId, OrderDate, RequiredDate, ShippedDate,  Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry, OrderDetails")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveOrder(request);
                return Redirect("GetAll");
            }
            return View("Add", request);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomer(), "CustomerId", "CompanyName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployee(), "EmployeeId", "FirstName");
            ViewBag.Product = new SelectList(_productService.GetProduct(), "ProductId", "ProductName");
            ViewBag.Shipper = new SelectList(_shipperService.GetShippers(), "ShipperId", "CompanyName");
            var entity = _service.GetOrderById(id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("OrderId, CustomerId, EmployeesId, ShipperId, OrderDate, RequiredDate, ShippedDate,  Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry, OrderDetails")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrder(request);
                return Redirect("GetAll");
            }
            return View("Edit", request);

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            _service.DeleteOrder(id);
            return Redirect("/Order/GetAll");
        }
    }
}