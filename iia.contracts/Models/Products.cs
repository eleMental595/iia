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
        public string Product_Name { get; set; }
        [Column("name_arabic")]
        public string Name_Arabic { get; set; }
        [Column("unit")]
        public string Unit { get; set; }
        [Column("selling_price")]
        public double Selling_price { get; set; }
        [Column("cost")]
        public double Cost { get; set; }
        [Column("expiry_date")]
        public DateTime Expiry_Date { get; set; }
        [Column("batch")]
        public string Batch { get; set; }
        [Column("category")]
        public string Category { get; set; }
    }
}