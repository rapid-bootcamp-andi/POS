using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(AplikasiContext context)
        {
            _service = new ProductService(context);
        }

        public IActionResult GetAllProduct()
        {
            var Data = _service.GetProduct();
            return View(Data);
        }

        public IActionResult DetailsProduct(int? id)
        {
            var DataDetail = _service.GetProductById(id);
            return View(DataDetail);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        public IActionResult _AddProduct()
        {
            return PartialView("_AddProduct");
        }

        public IActionResult SaveProduct([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitInStock, UnitOnOrder, RecorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveProduct(new Product(request));
                return Redirect("GetAllProduct");
            }
            return View("AddProduct", request);
        }

        public IActionResult EditProduct(int? id)
        {
            var entity = _service.GetProductById(id);
            return View(entity);
        }

        public IActionResult UpdateProduct([Bind("ProductId, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitInStock, UnitOnOrder, RecorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateProduct(request);
                return Redirect("GetAllProduct");
            }
            return View("EditProduct", request);

        }

        public IActionResult DeleteProduct(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllProduct");
        }
    }
}
