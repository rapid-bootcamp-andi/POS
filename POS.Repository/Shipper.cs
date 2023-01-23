using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_shipper")]
    public class Shipper
    {
        [Key]
        [Column("shipper_id")]
        public int ShipperId { get; set; }

        [Column("company_name")]
        public String CompanyName { get; set; }

        [Column("phone")]
        public String Phone { get; set; }

        public ICollection<Order> Order { get; set; }

        public Shipper(POS.ViewModel.ShipperModel model)
        {

            CompanyName = model.CompanyName;
            Phone = model.Phone;
        }

        public Shipper()
        {

        }

    }
}