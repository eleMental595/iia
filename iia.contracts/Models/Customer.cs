using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace iia.contracts.Models
{
    [Table("customers")]
    public class Customer
    {
        [Key]
        [Column("customer_id")]
        public int Id { get; set; }
        [Column("name")]
        public string Customer_Name { get; set; }
        [Column("vat_reg_no")]
        public int Vat_Reg_No { get; set; }
        [Column("contact_number")]
        public string contact_number { get; set; }
        [Column("sales_person")]
        public string sales_person { get; set; }   
    }
}
