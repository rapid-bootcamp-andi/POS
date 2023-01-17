using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Repository;
using POS.ViewModel;
using System.ComponentModel;


namespace POS.Service
{
    public class OrderDetailService
    {
        private readonly AplikasiContext _context;
        private OrderDetailModel EntityToModel(OrderDetail entity)
        {
            OrderDetailModel result = new OrderDetailModel();
            result.OrderDetailId = entity.OrderDetailId;
            result.OrderId = entity.OrderId;
            result.ProductId = entity.ProductId;
            result.UnitPrice = entity.UnitPrice;
            result.Quantity = entity.Quantity;
            result.Discount = entity.Discount;

            return result;
        }

        private void ModelToEntity(OrderDetailModel model, OrderDetail entity)
        {
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
        }

        public OrderDetailService(AplikasiContext context)
        {
            _context = context;
        }

        public List<OrderDetail> GetOrderDetail()
        {
            return _context.OrderDetailEntities.ToList();
        }

        public List<OrderDetail> SaveOrderDetail([Bind("OrderId, ProductId, UnitPrice, Quantity, Discount")] OrderDetail request)
        {
            _context.OrderDetailEntities.Add(request);
            _context.SaveChanges();
            return GetOrderDetail();
        }

        public OrderDetailModel GetOrderDetailById(int? id)
        {
            var orderdetail = _context.OrderDetailEntities.Find(id);
            return EntityToModel(orderdetail);

        }

        public void UpdateOrderDetail(OrderDetailModel orderdetail)
        {
            var entity = _context.OrderDetailEntities.Find(orderdetail.OrderDetailId);
            ModelToEntity(orderdetail, entity);
            _context.OrderDetailEntities.Update(entity);
            _context.SaveChanges();
        }

        public List<OrderDetail> DeleteById(int? id)
        {
            var entity = _context.OrderDetailEntities.Find(id);

            if (entity == null)
            {
                return GetOrderDetail();
            }

            _context.OrderDetailEntities.Remove(entity);
            _context.SaveChanges();

            return GetOrderDetail();
        }
    }
}