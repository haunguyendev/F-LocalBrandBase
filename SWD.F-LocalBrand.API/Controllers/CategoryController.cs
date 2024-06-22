﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD.F_LocalBrand.API.Common;
using SWD.F_LocalBrand.API.Payloads.Responses;
using SWD.F_LocalBrand.Business.Services;

namespace SWD.F_LocalBrand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        //get categories with products of them
        [HttpGet("categories/products")]
        public IActionResult GetCategoriesWithProducts()
        {
            try
            {
                var list = categoryService.GetAllProductsWithCategories();
                if (list == null)
                {
                    var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any category"));
                    return BadRequest(resultFail);
                }
                return Ok(ApiResult<ListCategoryResponse>.Succeed(new ListCategoryResponse
                {
                    Categories = list
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        //get all categories
        [HttpGet("categories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var list = categoryService.GetAllCategories();
                if (list == null)
                {
                    var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Do not have any category"));
                    return BadRequest(resultFail);
                }
                return Ok(ApiResult<ListCategoryResponse>.Succeed(new ListCategoryResponse
                {
                    Categories = list
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }

        //get category with categpry id with products of them 
        [HttpGet("category/{categoryId}")]
        public IActionResult GetCategoryWithProducts(int categoryId)
        {
            try
            {
                var category = categoryService.GetCategoryWithProducts(categoryId);
                if (category == null)
                {
                    var resultFail = ApiResult<Dictionary<string, string[]>>.Fail(new Exception("Category does not exist"));
                    return NotFound(resultFail);
                }
                return Ok(ApiResult<CategoryResponse>.Succeed(new CategoryResponse
                {
                    Category = category
                }));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}
