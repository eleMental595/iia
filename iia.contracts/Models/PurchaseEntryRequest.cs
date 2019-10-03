using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iia.contracts.Models
{
    public class PurchaseEntryRequest
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string InvoiceNumber { get; set; }
        public double NetAmount { get; set; }
        public double VatAmount { get; set; }
        public double TotalAmount { get; set; }
        public string RecievedBy { get; set; }
        public List<PurchaseProducts> PurchaseProducts { get; set; }
    }
}