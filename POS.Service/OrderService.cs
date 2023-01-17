using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;
using System.Net;


namespace POS.Service
{
    public class OrderService
    {
        private readonly AplikasiContext _context;
        private OrderModel EntityToModel(Order entity)
        {
            OrderModel result = new OrderModel();
            result.OrderId = entity.OrderId;
            result.CustomerId = entity.CustomerId;
            result.EmployeeId = entity.EmployeeId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequiredDate;
            result.ShipVia = entity.ShipVia;
            result.Freight = entity.Freight;
            result.ShipName = entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;

            return result;
        }

        private void ModelToEntity(OrderModel model, Order entity)
        {
            entity.CustomerId = model.CustomerId;
            entity.EmployeeId = model.EmployeeId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
        }

        public OrderService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Order> GetOrder()
        {
            return _context.OrderEntities.ToList();
        }

        public List<Order> SaveOrder([Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry")] Order request)
        {
            _context.OrderEntities.Add(request);
            _context.SaveChanges();
            return GetOrder();
        }

        public OrderModel GetOrderById(int? id)
        {
            var order = _context.OrderEntities.Find(id);
            return EntityToModel(order);

        }

        public void UpdateOrder(OrderModel order)
        {
            var entity = _context.OrderEntities.Find(order.OrderId);
            ModelToEntity(order, entity);
            _context.OrderEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<Order> DeleteById(int? id)
        {
            var entity = _context.OrderEntities.Find(id);

            if (entity == null)
            {
                return GetOrder();
            }

            _context.OrderEntities.Remove(entity);
            _context.SaveChanges();

            return GetOrder();
        }
    }
}