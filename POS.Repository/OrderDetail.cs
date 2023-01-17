using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order_detail")]
    public class OrderDetail
    {
        [Key]
        [Column("order_detail_id")]
        public int OrderDetailId { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }
        [Required]
        public Order Order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }
        [Required]
        public Product Product { get; set; }

        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("quantity")]
        public int Quantity { get; set; }

        [Required]
        [Column("discount")]
        public int Discount { get; set; }

        public OrderDetail(POS.ViewModel.OrderDetailModel model)
        {
            OrderId = model.OrderId;
            ProductId = model.ProductId;
            UnitPrice = model.UnitPrice;
            Quantity = model.Quantity;
            Discount = model.Discount;
        }

        public OrderDetail()
        {

        }
    }
}