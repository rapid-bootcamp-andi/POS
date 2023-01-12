using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using System.ComponentModel;


namespace POS.Service
{
    public class SupplierService
    {
        private readonly AplikasiContext _context;
        public SupplierService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Supplier> GetSupplier()
        {
            return _context.SupplierEntities.ToList();
        }

        public Supplier GetSupplierById(int? id)
        {
            return _context.SupplierEntities.Find(id);
        }

        public List<Supplier> SaveSupplier([Bind("CompanyName, ContactName, ContactTitle, City, Region, PostalCode, Country, Phone, Fax, Homepage")] Supplier request)
        {
            _context.SupplierEntities.Add(request);
            _context.SaveChanges();
            return GetSupplier();
        }

        public List<Supplier> UpdateSupplier([Bind("Id, CompanyName, ContactName, ContactTitle, City, Region, PostalCode, Country, Phone, Fax, Homepage")] Supplier request)
        {
            _context.SupplierEntities.Update(request);
            _context.SaveChanges();
            return GetSupplier();
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