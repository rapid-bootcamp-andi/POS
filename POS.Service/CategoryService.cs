using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class CategoryService
    {
        private readonly AplikasiContext _context;
        private CategoryModel EntityToModel(Category entity)
        {
            CategoryModel result = new CategoryModel();
            result.Id = entity.Id;
            result.CategoryName = entity.CategoryName;
            result.Description = entity.Description;
            result.Picture = entity.Picture;

            return result;
        }

        private void ModelToEntity(CategoryModel model, Category entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
            entity.Picture = model.Picture;
        }
        public CategoryService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Category> GetCategory()
        {
            return _context.CategoryEntities.ToList();
        }

        public List<Category> SaveCategory([Bind("CategoryName, Description, Picture")] Category request)
        {
            _context.CategoryEntities.Add(request);
            _context.SaveChanges();
            return GetCategory();
        }

        public CategoryModel GetCategoryById(int? id)
        {
            var category = _context.CategoryEntities.Find(id);
            return EntityToModel(category);

        }

        public void UpdateCategory(CategoryModel category)
        {
            var entity = _context.CategoryEntities.Find(category.Id);
            ModelToEntity(category, entity);
            _context.CategoryEntities.Update(entity);
            _context.SaveChanges();

        }

        public List<Category> DeleteById(int? id)
        {
            var entity = _context.CategoryEntities.Find(id);

            if (entity == null)
            {
                return GetCategory();
            }

            _context.CategoryEntities.Remove(entity);
            _context.SaveChanges();

            return GetCategory();
        }
    }
}