using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class EmployeeService
    {
        private readonly AplikasiContext _context;
        private EmployeeModel EntityToModel(Employee entity)
        {
            EmployeeModel result = new EmployeeModel();
            result.EmployeeId = entity.EmployeeId;
            result.LastName = entity.LastName;
            result.FirstName = entity.FirstName;
            result.Title = entity.Title;
            result.TitleOfCourtesy = entity.TitleOfCourtesy;
            result.BirthDate = entity.BirthDate;
            result.HireDate = entity.HireDate;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.HomePhone = entity.HomePhone;
            result.Extension = entity.Extension;
            result.Photo = entity.Photo;
            result.Notes = entity.Notes;
            result.ReportsTo = entity.ReportsTo;
            result.PhotoPath = entity.PhotoPath;

            return result;
        }

        private void ModelToEntity(EmployeeModel model, Employee entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        public EmployeeService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployee()
        {
            return _context.EmployeeEntities.ToList();
        }

        public List<Employee> SaveEmployee([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] Employee request)
        {
            _context.EmployeeEntities.Add(request);
            _context.SaveChanges();
            return GetEmployee();
        }

        public EmployeeModel GetEmployeeById(int? id)
        {
            var employee = _context.EmployeeEntities.Find(id);
            return EntityToModel(employee);

        }

        public void UpdateEmployee(EmployeeModel employee)
        {
            var entity = _context.EmployeeEntities.Find(employee.EmployeeId);
            ModelToEntity(employee, entity);
            _context.EmployeeEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<Employee> DeleteById(int? id)
        {
            var entity = _context.EmployeeEntities.Find(id);

            if (entity == null)
            {
                return GetEmployee();
            }

            _context.EmployeeEntities.Remove(entity);
            _context.SaveChanges();

            return GetEmployee();
        }
    }
}