using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(AplikasiContext context)
        {
            _service = new CategoryService(context);
        }

        public IActionResult GetAllCategory()
        {
            var Data = _service.GetCategory();
            return View(Data);
        }
    }
}
