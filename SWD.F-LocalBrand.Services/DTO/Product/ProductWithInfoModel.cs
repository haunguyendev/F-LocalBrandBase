﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.F_LocalBrand.Business.DTO.Product
{
    public class ProductWithInfoModel
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }

        public int? CategoryId { get; set; }

        public int? CampaignId { get; set; }

        public string? SubCategory { get; set; }

        public string? Gender { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public int? StockQuantity { get; set; }

        public string? ImageUrl { get; set; }

        public int? Size { get; set; }

        public string? Color { get; set; }
    }
}
