﻿using System;
using System.Collections.Generic;
using System.Text;

namespace iia.contracts.Models
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Vat { get; set; }
    }
}
