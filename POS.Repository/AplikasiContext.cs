using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class AplikasiContext : DbContext
    {
        public AplikasiContext(DbContextOptions<AplikasiContext> options) : base(options)
        {

        }

        public DbSet<Category> CategoryEntities => Set<Category>();
        public DbSet<Customer> CustomerEntities => Set<Customer>();
        public DbSet<Employee> EmployeeEntities => Set<Employee>();
        public DbSet<Order> OrderEntities => Set<Order>();
        public DbSet<OrderDetail> OrderDetailEntities => Set<OrderDetail>();
        public DbSet<Product> ProductEntities => Set<Product>();
        public DbSet<Supplier> SupplierEntities => Set<Supplier>();
        public DbSet<Shipper> ShipperEntities => Set<Shipper>();
    }
}