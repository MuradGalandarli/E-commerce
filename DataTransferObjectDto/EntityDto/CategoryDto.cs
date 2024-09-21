﻿using EntityCommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataTransferObject.EntityDto
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
       
  //      public bool CategoryStatus { get; set; }

        public List<Goods>? Goods { get; set; }
    }
}
