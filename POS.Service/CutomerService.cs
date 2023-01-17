using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class CustomerService
    {
        private readonly AplikasiContext _context;
        private CustomerModel EntityToModel(Customer entity)
        {
            CustomerModel result = new CustomerModel();
            result.CustomerId = entity.CustomerId;
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;

            return result;
        }

        private void ModelToEntity(CustomerModel model, Customer entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
        }

        public CustomerService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomer()
        {
            return _context.CustomerEntities.ToList();
        }

        public List<Customer> SaveCustomer([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] Customer request)
        {
            _context.CustomerEntities.Add(request);
            _context.SaveChanges();
            return GetCustomer();
        }

        public CustomerModel GetCustomerById(int? id)
        {
            var customer = _context.CustomerEntities.Find(id);
            return EntityToModel(customer);

        }

        public void UpdateCustomer(CustomerModel customer)
        {
            var entity = _context.CustomerEntities.Find(customer.CustomerId);
            ModelToEntity(customer, entity);
            _context.CustomerEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<Customer> DeleteById(int? id)
        {
            var entity = _context.CustomerEntities.Find(id);

            if (entity == null)
            {
                return GetCustomer();
            }

            _context.CustomerEntities.Remove(entity);
            _context.SaveChanges();

            return GetCustomer();
        }
    }
}