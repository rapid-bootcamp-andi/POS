using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_suplier")]
    public class Supplier
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("company_name")]
        public String CompanyName { get; set; }

        [Required]
        [Column("contact_name")]
        public String ContactName { get; set; }

        [Required]
        [Column("contact_title")]
        public String ContactTitle { get; set; }

        [Required]
        [Column("city")]
        public String City { get; set; }

        [Required]
        [Column("region")]
        public String Region { get; set; }

        [Required]
        [Column("postal_code")]
        public String PostalCode { get; set; }

        [Required]
        [Column("country")]
        public String Country { get; set; }

        [Required]
        [Column("phone")]
        public String Phone { get; set; }

        [Required]
        [Column("fax")]
        public String Fax { get; set; }

        [Required]
        [Column("homepage")]
        public String Homepage { get; set; }

        public ICollection<Product> Products { get; set; }

        public Supplier(POS.ViewModel.SupplierModel model)
        {
            CompanyName = model.CompanyName;
            ContactName = model.ContactName;
            ContactTitle = model.ContactTitle;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            Phone = model.Phone;
            Fax = model.Fax;
            Homepage = model.Homepage;
        }

        public Supplier()
        {

        }
    }
}