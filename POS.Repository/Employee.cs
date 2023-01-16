using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_employee")]
    public class Employee
    {
        [Key]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Column("last_name")]
        public String LastName { get; set; }

        [Column("first_name")]
        public String FirstName { get; set; }

        [Column("title")]
        public String Title { get; set; }

        [Column("title_of_courtesy")]
        public String PkrPri { get; set; }

        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Column("hire_date")]
        public DateTime HireDate { get; set; }

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

        [Column("home_phone")]
        public String HomePhone { get; set; }

        [Column("extension")]
        public String Extension { get; set; }

        [Column("photo")]
        public String Photo { get; set; }

        [Column("notes")]
        public String Notes { get; set; }

        [Column("reports_to")]
        public int ReportsTo { get; set; }

        [Column("photo_path")]
        public String PhotoPath { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}