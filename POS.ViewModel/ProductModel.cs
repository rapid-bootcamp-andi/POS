using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        [Required]
        public String ProductName { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public String QuantityPerUnit { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public int UnitInStock { get; set; }

        [Required]
        public int UnitOnOrder { get; set; }

        [Required]
        public int RecorderLevel { get; set; }

        [Required]
        public int Discontinued { get; set; }
    }
}
