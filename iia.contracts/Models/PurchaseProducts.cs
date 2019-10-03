using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iia.contracts.Models {
    [Table("purchase_products")]
    public class PurchaseProducts 
    {
        [Key]
        [Column("purchase_products_id")]
        public int Id { get; set; }
        [Column("purchase_id")]
        public int PurchaseId { get; set; }
        [Column("description")]
        public string Description { get; set; }        
        [Column("cost")]
        public double Cost { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("unit_price")]
        public double UnitPrice { get; set; }
        [Column("hasExpiryDate")]
        public Int16 HasExpiryDate { get; set; }
        [Column("expiry_date")]
        public string ExpiryDate { get; set; }
        [Column("batch")]
        public string Batch { get; set; }
    }
}