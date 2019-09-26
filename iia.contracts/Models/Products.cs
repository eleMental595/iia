using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iia.contracts.Models {
    [Table("products")]
    public class Products 
    {
        [Key]
        [Column("product_id")]
        public int Id { get; set; }
        [Column("name")]
        public string ProductName { get; set; }
        [Column("name_arabic")]
        public string NameArabic { get; set; }
        [Column("unit")]
        public string Unit { get; set; }
        [Column("selling_price")]
        public double SellingPrice { get; set; }
        [Column("cost")]
        public double Cost { get; set; }
        [Column("expiry_date")]
        public Int16 ExpiryDate { get; set; }
        [Column("batch")]
        public string Batch { get; set; }
        [Column("category")]
        public string Category { get; set; }
    }
}