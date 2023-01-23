using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using POS.ViewModel.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        private readonly AplikasiContext _context;

        private OrderModel EntityToModelOrder(Order entity)
        {
            OrderModel result = new OrderModel();
            result.OrderId = entity.OrderId;
            result.CustomerId = entity.CustomerId;
            result.EmployeeId = entity.EmployeeId;
            result.ShipperId = entity.ShipperId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequiredDate;
            result.ShippedDate = entity.ShippedDate;
            result.Freight = entity.Freight;
            result.ShipName = entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;
            result.OrderDetail = new List<OrderDetailModel>();
            foreach (var item in entity.OrderDetail)
            {
                result.OrderDetail.Add(EntityToModelOrderDetail(item));
            }

            return result;
        }


        private Order ModelToEntityOrder(OrderModel model)
        {
            var entity = new Order();
            entity.CustomerId = model.CustomerId;
            entity.EmployeeId = model.EmployeeId;
            entity.ShipperId = model.ShipperId;
            entity.OrderDate = model.OrderDate;
            entity.RequiredDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
            entity.OrderDetail = new List<OrderDetail>();

            foreach (var item in model.OrderDetail)
            {
                entity.OrderDetail.Add(ModelToEntityOrderDetail(item));
            }
            return entity;

        }

        private OrderDetailModel EntityToModelOrderDetail(OrderDetail entity)
        {
            var model = new OrderDetailModel();
            model.OrderDetailId = entity.OrderDetailId;
            model.ProductId = entity.ProductId;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;
        }

        private OrderDetail ModelToEntityOrderDetail(OrderDetailModel model)
        {
            var entity = new OrderDetail();
            entity.OrderId = model.OrderId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;

            return entity;
        }

        public OrderService(AplikasiContext context)
        {
            _context = context;
        }

        private DetailOfOrderResponse EntityToModelResponseDetail(Order entity)
        {
            var shipper = _context.ShipperEntities.Find(entity.ShipperId);
            var customer = _context.CustomerEntities.Find(entity.CustomerId);

            var response = new DetailOfOrderResponse();
            response.OrderId = entity.OrderId;
            response.CustomerId = customer.CustomerId;
            response.CustomerName = customer.CompanyName;
            response.OrderDate = entity.OrderDate;
            response.RequiredDate = entity.RequiredDate;
            response.ShippedDate = entity.ShippedDate;
            response.ShipperId = shipper.ShipperId;
            response.ShipperName = shipper.CompanyName;
            response.ShipperPhone = shipper.Phone;
            response.Freight = entity.Freight;
            response.ShipName = entity.ShipName;
            response.ShipAddress = entity.ShipAddress;
            response.ShipCity = entity.ShipCity;
            response.ShipRegion = entity.ShipRegion;
            response.ShipPostalCode = entity.ShipPostalCode;
            response.ShipCountry = entity.ShipCountry;
            response.Detail = new List<OrderDetailResponse>();

            foreach (var item in entity.OrderDetail)
            {
                response.Detail.Add(EntityToModelDetailResponse(item));

            }
            var subtotal = 0.0;
            foreach (var item in response.Detail)
            {
                item.Subtotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100);
            }
            response.Subtotal = subtotal;
            response.Tax = 0.05 * subtotal;
            response.Shipping = 0;
            response.Total = response.Subtotal + response.Tax + response.Shipping;

            return response;
        }

        private OrderDetailResponse EntityToModelDetailResponse(OrderDetail entity)
        {
            var model = new OrderDetailResponse();
            var product = _context.ProductEntities.Find(entity.ProductId);

            model.OrderDetailId = entity.OrderDetailId;
            model.ProductId = product.ProductId;
            model.ProductName = product.ProductName;
            model.UnitPrice = entity.UnitPrice;
            model.Quantity = entity.Quantity;
            model.Discount = entity.Discount;

            return model;


        }

        public List<Order> GetOrders()
        {
            return _context.OrderEntities.ToList();
        }

        public OrderModel GetOrderById(int? id)
        {
            var order = _context.OrderEntities.Find(id);
            var detail = _context.OrderDetailEntities.Where(x => x.OrderId == id);
            foreach (var item in detail) { }
            return EntityToModelOrder(order);
        }

        public DetailOfOrderResponse GetOrderInvoice(int? id)
        {
            var orderEntity = _context.OrderEntities.Find(id);
            var detailEntity = _context.OrderDetailEntities.Where(x => x.OrderId == id).ToList();
            orderEntity.OrderDetail = detailEntity;
            var orderResponse = EntityToModelResponseDetail(orderEntity);
            return orderResponse;
        }


        public void SaveOrder(OrderModel requestOrder)
        {
            var newItem = ModelToEntityOrder(requestOrder);
            _context.OrderEntities.Add(newItem);
            foreach (var item in newItem.OrderDetail)
            {
                item.OrderId = requestOrder.OrderId;
                _context.OrderDetailEntities.Add(item);
            }
            _context.SaveChanges();

        }

        public void UpdateOrder(OrderModel request)
        {
            //baca dari database
            var entityOrder = _context.OrderEntities.Find(request.OrderId);
            var orderDetailList = _context.OrderDetailEntities.Where(x => x.OrderId == request.OrderId).ToList();

            //ubah model dengan update data yg dimasukkan ke entity
            var updateEntity = ModelToEntityOrder(request);

            entityOrder.CustomerId = updateEntity.CustomerId;
            entityOrder.EmployeeId = updateEntity.EmployeeId;
            entityOrder.OrderDate = updateEntity.OrderDate;
            entityOrder.RequiredDate = updateEntity.RequiredDate;
            entityOrder.ShippedDate = updateEntity.ShippedDate;
            entityOrder.ShipperId = updateEntity.ShipperId;
            entityOrder.Freight = updateEntity.Freight;
            entityOrder.ShipName = updateEntity.ShipName;
            entityOrder.ShipAddress = updateEntity.ShipAddress;
            entityOrder.ShipCity = updateEntity.ShipCity;
            entityOrder.ShipRegion = updateEntity.ShipRegion;
            entityOrder.ShipPostalCode = updateEntity.ShipPostalCode;
            entityOrder.ShipCountry = updateEntity.ShipCountry;
            entityOrder.OrderDetail = updateEntity.OrderDetail;

            // update order entity-nya
            _context.OrderEntities.Update(entityOrder);

            //looping order detail
            foreach (var newItem in entityOrder.OrderDetail)
            {
                newItem.OrderId = request.OrderId;
                foreach (var item in orderDetailList)
                {
                    if (newItem.ProductId == item.ProductId)
                    {
                        item.ProductId = newItem.ProductId;
                        item.UnitPrice = newItem.UnitPrice;
                        item.Quantity = newItem.Quantity;
                        item.Discount = newItem.Discount;

                        // update order detail entity-nya
                        _context.OrderDetailEntities.Update(item);
                    }
                }
            }
            // save perubahan yg dibuat diatas
            _context.SaveChanges();
        }

        public void DeleteOrder(int? id)
        {
            var entity = _context.OrderEntities.Find(id);
            _context.OrderEntities.Remove(entity);

            var detail = _context.OrderDetailEntities.Where(x => x.OrderId == id);
            foreach (var item in detail)
            {
                _context.OrderDetailEntities.Remove(item);
            }

            _context.SaveChanges();
        }
    }
}