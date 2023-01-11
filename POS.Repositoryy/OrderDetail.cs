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
        [Column("id")]
        public int Id { get; set; }

        [Column("order_id")]
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("discount")]
        public int Discount { get; set; }
    }
}
