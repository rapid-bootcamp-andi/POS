using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class ProductService
    {
        private readonly AplikasiContext _context;
        private ProductModel EntityToModel(Product entity)
        {
            ProductModel result = new ProductModel();
            result.ProductId = entity.ProductId;
            result.ProductName = entity.ProductName;
            result.SupplierId = entity.SupplierId;
            result.CategoryId = entity.CategoryId;
            result.QuantityPerUnit = entity.QuantityPerUnit;
            result.UnitPrice = entity.UnitPrice;
            result.UnitInStock = entity.UnitInStock;
            result.UnitOnOrder = entity.UnitOnOrder;
            result.RecorderLevel = entity.RecorderLevel;
            result.Discontinued = entity.Discontinued;

            return result;
        }

        private void ModelToEntity(ProductModel model, Product entity)
        {
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.QuantityPerUnit = model.QuantityPerUnit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitInStock = model.UnitInStock;
            entity.UnitOnOrder = model.UnitOnOrder;
            entity.RecorderLevel = model.RecorderLevel;
            entity.Discontinued = model.Discontinued;
        }

        public ProductService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Product> GetProduct()
        {
            return _context.ProductEntities.ToList();
        }

        public List<Product> SaveProduct([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitInStock, UnitOnOrder, RecorderLevel, Discontinued")] Product request)
        {
            _context.ProductEntities.Add(request);
            _context.SaveChanges();
            return GetProduct();
        }

        public ProductModel GetProductById(int? id)
        {
            var Product = _context.ProductEntities.Find(id);
            return EntityToModel(Product);

        }

        public void UpdateProduct(ProductModel Product)
        {
            var entity = _context.ProductEntities.Find(Product.ProductId);
            ModelToEntity(Product, entity);
            _context.ProductEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<Product> DeleteById(int? id)
        {
            var entity = _context.ProductEntities.Find(id);

            if (entity == null)
            {
                return GetProduct();
            }

            _context.ProductEntities.Remove(entity);
            _context.SaveChanges();

            return GetProduct();
        }
    }
}