using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class ShipperModel
    {
        public int ShipperId { get; set; }

        [Required]
        public String CompanyName { get; set; }

        [Required]
        public String Phone { get; set; }

    }
}