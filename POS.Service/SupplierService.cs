using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class SupplierService
    {
        private readonly AplikasiContext _context;

        private SupplierModel EntityToModel(Supplier entity)
        {
            SupplierModel result = new SupplierModel();
            result.SupplierId = entity.SupplierId;
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            result.Homepage = entity.Homepage;

            return result;
        }

        private void ModelToEntity(SupplierModel model, Supplier entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            entity.Homepage = model.Homepage;
        }

        public SupplierService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Supplier> GetSupplier()
        {
            return _context.SupplierEntities.ToList();
        }
        
        public List<Supplier> SaveSupplier([Bind("CompanyName, ContactName, ContactTitle, City, Region, PostalCode, Country, Phone, Fax, Homepage")] Supplier request)
        {
            _context.SupplierEntities.Add(request);
            _context.SaveChanges();
            return GetSupplier();
        }

        public SupplierModel GetSupplierById(int? id)
        {
            var supplier = _context.SupplierEntities.Find(id);
            return EntityToModel(supplier);
        }

        public void UpdateSupplier(SupplierModel supplier)
        {;
            var entity = _context.SupplierEntities.Find(supplier.SupplierId);
            ModelToEntity(supplier, entity);
            _context.SupplierEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<Supplier> DeleteById(int? id)
        {
            var entity = _context.SupplierEntities.Find(id);

            if (entity == null)
            {
                return GetSupplier();
            }

            _context.SupplierEntities.Remove(entity);
            _context.SaveChanges();

            return GetSupplier();
        }
    }
}