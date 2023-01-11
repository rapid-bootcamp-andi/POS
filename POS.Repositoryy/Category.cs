﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_category")]
    public class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_name")]
        public String CategoryName { get; set; }

        [Column("description")]
        public String Description { get; set; }

        [Column("picture")]
        public String Picture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}