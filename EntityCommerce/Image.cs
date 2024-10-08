﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EntityCommerce
{
    public class Image
    {
        public int ImageId { get; set; }
        public string? OriginalPath { get; set; }
        public string? SavedPath { get; set; }
        public DateTime UploadedAt { get; set; }     
        public int? GoodsId { get; set; }
        [JsonIgnore]
        public Goods? Goods { get; set; }
        public bool IsDeleted { get; set; } = true;

        //test
    }
}
