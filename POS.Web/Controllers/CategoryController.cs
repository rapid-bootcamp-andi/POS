using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

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

        public IActionResult DetailsCategory(int? id)
        {
            var DataDetail = _service.GetCategoryById(id);
            return View(DataDetail);
        }

        public IActionResult AddCategory()
        {
            return View();
        }

        public IActionResult AddModal()
        {
            return PartialView("_AddCategory");
        }

        public IActionResult SaveCategory([Bind("CategoryName, Description, Picture")] CategoryModel request)
        {
            if(ModelState.IsValid)
            {
                _service.SaveCategory(new Category(request));
                return Redirect("GetAllCategory");
            }
            return View("AddCategory", request);
        }

        public IActionResult EditCategory(int? id)
        {
            var entity = _service.GetCategoryById(id);
            return View(entity);
        }

        public IActionResult UpdateCategory([Bind("CategoryId, CategoryName, Description, Picture")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategory(request);
                return Redirect("GetAllCategory");
            }
            return View ("EditCategory", request);

        }

        public IActionResult DeleteCategory(int? id)
        {
            _service.DeleteById(id);
            return RedirectToAction("GetAllCategory");
        }
    }
}
