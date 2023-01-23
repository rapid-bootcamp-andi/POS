using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ShipperService
    {
        private readonly AplikasiContext _context;

        private ShipperModel EntityToModel(Shipper entity)
        {
            ShipperModel result = new ShipperModel();
            result.ShipperId = entity.ShipperId;
            result.CompanyName = entity.CompanyName;
            result.Phone = entity.Phone;

            return result;
        }

        private void ModelToEntity(ShipperModel model, Shipper entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.Phone = model.Phone;
        }

        public ShipperService(AplikasiContext context)
        {
            _context = context;
        }

        public List<Shipper> GetShippers()
        {
            return _context.ShipperEntities.ToList();
        }

        public ShipperModel GetShipperById(int? id)
        {
            var shipper = _context.ShipperEntities.Find(id);
            return EntityToModel(shipper);
        }

        public List<Shipper> SaveShipper([Bind("CompanyName, Phone")] Shipper request)
        {
            _context.ShipperEntities.Add(request);
            _context.SaveChanges();
            return GetShippers();
        }

        public List<Shipper> UpdateShipper([Bind("ShipperId, CompanyName, Phone")] ShipperModel request)
        {
            var entity = _context.ShipperEntities.Find(request.ShipperId);
            ModelToEntity(request, entity);
            _context.ShipperEntities.Update(entity);
            _context.SaveChanges();
            return GetShippers();
        }

        public void DeleteShipper(int? id)
        {
            var entity = _context.ShipperEntities.Find(id);
            _context.ShipperEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}