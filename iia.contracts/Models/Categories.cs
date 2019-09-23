using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iia.contracts.Models
{
    [Table("categories")]
    public class Categories
    {
        [Key]
        [Column("category_id")]
        public string Id { get; set; }
        [Column("category_name")]
        public string Category_Name { get; set; }
        [Column("vat")]
        public string Vat { get; set; }
    }
}
