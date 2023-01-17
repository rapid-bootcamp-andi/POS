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

        [Required]
        [Column("last_name")]
        public String LastName { get; set; }

        [Required]
        [Column("first_name")]
        public String FirstName { get; set; }

        [Required]
        [Column("title")]
        public String Title { get; set; }

        [Required]
        [Column("title_of_courtesy")]
        public String TitleOfCourtesy { get; set; }

        [Required]
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column("hire_date")]
        public DateTime HireDate { get; set; }

        [Required]
        [Column("address")]
        public String Address { get; set; }

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
        [Column("home_phone")]
        public String HomePhone { get; set; }

        [Required]
        [Column("extension")]
        public String Extension { get; set; }

        [Required]
        [Column("photo")]
        public String Photo { get; set; }

        [Required]
        [Column("notes")]
        public String Notes { get; set; }

        [Required]
        [Column("reports_to")]
        public int ReportsTo { get; set; }

        [Required]
        [Column("photo_path")]
        public String PhotoPath { get; set; }

        public ICollection<Order> Order { get; set; }

        public Employee(POS.ViewModel.EmployeeModel model)
        {
            LastName = model.LastName;
            FirstName = model.FirstName;
            Title = model.Title;
            TitleOfCourtesy = model.TitleOfCourtesy;
            BirthDate = model.BirthDate;
            HireDate = model.HireDate;
            Address = model.Address;
            City = model.City;
            Region = model.Region;
            PostalCode = model.PostalCode;
            Country = model.Country;
            HomePhone = model.HomePhone;
            Extension = model.Extension;
            Photo = model.Photo;
            Notes = model.Notes;
            ReportsTo = model.ReportsTo;
            PhotoPath = model.PhotoPath;
        }

        public Employee()
        {

        }
    }
}