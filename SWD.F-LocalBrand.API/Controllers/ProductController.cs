﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sprache;
using SWD.F_LocalBrand.API.Common;
using SWD.F_LocalBrand.API.Common.Payloads.Responses;
using SWD.F_LocalBrand.Business.Services;

namespace SWD.F_LocalBrand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        //Get all product
        [HttpGet("/list-product")]
        public async Task<IActionResult> GetAllProduct()
        {
            var listProduct = await productService.GetAllProductsAsync();
            if (listProduct == null)
            {
                var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any product!"));
                return NotFound(resultFail);
            }
            return Ok(ApiResult<ListProductResponse>.Succeed(new ListProductResponse
            {
                Products = listProduct
            }));
        }

        [HttpGet("/list-product-page")]
        public async Task<IActionResult> GetAllProduct([FromQuery]int pageSize,[FromQuery]int pageNumber)
        {
            var listProduct = await productService.GetAllProductsAsync(pageNumber, pageSize);
            if (listProduct == null)
            {
                var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any product!"));
                return NotFound(resultFail);
            }
            return Ok(ApiResult<ListProductWithPageAndIncludeRelatedReponse>.Succeed(new ListProductWithPageAndIncludeRelatedReponse
            {
                Products = listProduct
            }));
        }

        //get product by category id
        [HttpGet("category-with-products/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var listProduct = await productService.GetProductsByCategoryIdAsync(categoryId);
            if (listProduct == null)
            {
                var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any product in this category!"));
                return NotFound(resultFail);
            }
            return Ok(ApiResult<ListProductResponse>.Succeed(new ListProductResponse
            {
                Products = listProduct
            }));
        }

        //get product by category id and have paging
        [HttpGet("category-with-products/{categoryId}/{pageIndex}/{pageSize}")]
        public async Task<IActionResult> GetProductByCategoryIdPaging(int categoryId, int pageIndex, int pageSize)
        {
            var listProduct = await productService.GetProductsByCategoryIdPagingAsync(categoryId, pageIndex, pageSize);
            if (listProduct == null)
            {
                var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any product in this category!"));
                return NotFound(resultFail);
            }
            return Ok(ApiResult<ListProductResponse>.Succeed(new ListProductResponse
            {
                Products = listProduct
            }));
        }


        //get product by id and compapility of them
        [HttpGet("/product-product-recommend/{productId}")]
        public async Task<IActionResult> GetProductWithRecommendations(int productId)
        {
            var product = await productService.GetProductWithRecommendationsAsync(productId);
            if (product == null)
            {
                var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any product with this id!"));
                return NotFound(resultFail);
            }
            return Ok(ApiResult<ProductResponse>.Succeed(new ProductResponse
            {
                Product = product
            }));
        }

        
    }
}
