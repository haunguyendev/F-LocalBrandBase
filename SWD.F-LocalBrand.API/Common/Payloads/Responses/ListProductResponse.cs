﻿using SWD.F_LocalBrand.Business.DTO;

namespace SWD.F_LocalBrand.API.Common.Payloads.Responses
{
    public class ListProductResponse
    {
        public List<ProductModel> Products { get; set; } = null!;
    }
}
