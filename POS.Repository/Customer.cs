using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_customer")]
    public class Customer
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("company_name")]
        public String CompanyName { get; set; }

        [Column("contact_name")]
        public String ContactName { get; set; }

        [Column("contact_title")]
        public String ContactTitle { get; set; }

        [Column("address")]
        public String Address { get; set; }

        [Column("city")]
        public String City { get; set; }

        [Column("region")]
        public String Region { get; set; }

        [Column("postal_code")]
        public String PostalCode { get; set; }

        [Column("country")]
        public String Country { get; set; }

        [Column("phone")]
        public String Phone { get; set; }

        [Column("fax")]
        public String Fax { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}