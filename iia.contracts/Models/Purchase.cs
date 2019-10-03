using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iia.contracts.Models {
    [Table("purchase")]
    public class Purchase
    {
        [Key]
        [Column("purchase_id")]
        public int Id { get; set; }
        [Column("vendor_id")]
        public int VendorId { get; set; }
        [Column("vendor_name")]
        public string VendorName { get; set; }
        [Column("invoice_number")]
        public string InvoiceNumber { get; set; }
        [Column("net_amount")]
        public double NetAmount { get; set; }
        [Column("vat_amount")]
        public double VatAmount { get; set; }
        [Column("total_amount")]
        public double TotalAmount { get; set; }
        [Column("recieved_by")]
        public string RecievedBy { get; set; }
    }
}