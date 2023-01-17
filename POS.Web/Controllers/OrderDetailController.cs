using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly OrderDetailService _service;
        public OrderDetailController(AplikasiContext context)
        {
            _service = new OrderDetailService(context);
        }

        public IActionResult GetAllOrderDetail()
        {
            var Data = _service.GetOrderDetail();
            return View(Data);
        }

        public IActionResult DetailsOrderDetail(int? id)
        {
            var DataDetail = _service.GetOrderDetailById(id);
            return View(DataDetail);
        }

        public IActionResult AddOrderDetail()
        {
            return View();
        }

        public IActionResult _AddOrderDetail()
        {
            return PartialView("_AddOrderDetail");
        }

        public IActionResult SaveOrderDetail([Bind("OrderId, ProductId, UnitPrice, Quantity, Discount")] OrderDetailModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveOrderDetail(new OrderDetail(request));
                return Redirect("GetAllOrderDetail");
            }
            return View("AddOrderDetail", request);
        }

        public IActionResult EditOrderDetail(int? id)
        {
            var entity = _service.GetOrderDetailById(id);
            return View(entity);
        }

        public IActionResult UpdateOrderDetail([Bind("OrderDetailId, OrderId, ProductId, UnitPrice, Quantity, Discount")] OrderDetailModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrderDetail(request);
                return Redirect("GetAllOrderDetail");
            }
            return View("EditOrderDetail", request);

        }

        public IActionResult DeleteOrderDetail(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllOrderDetail");
        }
    }
}
