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
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("product_name")]
        public String ProductName { get; set; }

        [Column("supplier_id")]
        public int SupplierId { get; set; }
        [Required]
        public Supplier Supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }

        [Required]
        [Column("quantity_per_unit")]
        public string QuantityPerUnit { get; set; }

        [Required]
        [Column("unit_price")]
        public int UnitPrice { get; set; }

        [Required]
        [Column("unit_in_stock")]
        public int UnitInStock { get; set; }

        [Required]
        [Column("unit_on_order")]
        public int UnitOnOrder { get; set; }

        [Required]
        [Column("recorder_level")]
        public int RecorderLevel { get; set; }

        [Required]
        [Column("discontinued")]
        public int Discontinued { get; set; }

        public ICollection<OrderDetail> OrderDetail { get; set; }

        public Product(POS.ViewModel.ProductModel model)
        {
            ProductName = model.ProductName;
            SupplierId = model.SupplierId;
            CategoryId = model.CategoryId;
            QuantityPerUnit = model.QuantityPerUnit;
            UnitPrice = model.UnitPrice;
            UnitInStock = model.UnitInStock;
            UnitOnOrder = model.UnitOnOrder;
            RecorderLevel = model.RecorderLevel;
            Discontinued = model.Discontinued;
        }

        public Product()
        {

        }
    }
}