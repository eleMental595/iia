

using System;

namespace iia.contracts.Models {
    public class ProductRequest
    {
        public int Id { get; set; }
        public string Product_Name { get; set; }
        public string Name_Arabic { get; set; }
        public string Unit { get; set; }
        public int Selling_price { get; set; }
        public int Cost { get; set; }
        public DateTime Expiry_Date { get; set; }
        public string Batch { get; set; }
        public string Category { get; set; }
    }
}