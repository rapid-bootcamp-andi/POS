using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_product")]
    public class Product
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_name")]
        public String ProductName { get; set; }

        [Column("suplier_id")]
        public int SuplierId { get; set; }

        public Supplier Supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Column("quantity_per_unit")]
        public string QuantityPerUnit { get; set; }

        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Column("unit_in_stock")]
        public int UnitInStock { get; set; }

        [Column("unit_on_order")]
        public int UnitOnOrder { get; set; }

        [Column("recorder_level")]
        public int RecorderLevel { get; set; }

        [Column("discontinued")]
        public int Discontinued { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}