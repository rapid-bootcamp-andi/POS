using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }

        [Required]
        public String LastName { get; set; }

        [Required]
        public String FirstName { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String TitleOfCourtesy { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public String Address { get; set; }

        [Required]
        public String City { get; set; }

        [Required]
        public String Region { get; set; }

        [Required]
        public String PostalCode { get; set; }

        [Required]
        public String Country { get; set; }
        
        [Required]
        public String HomePhone { get; set; }

        [Required]
        public String Extension { get; set; }

        [Required]
        public String Photo { get; set; }

        [Required]
        public String Notes { get; set; }

        [Required]
        public int ReportsTo { get; set; }

        [Required]
        public String PhotoPath { get; set; }
    }
}
