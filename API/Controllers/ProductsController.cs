using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        public IProductRepository _repo { get; }

        public ProductsController(IProductRepository repo)
        {
            this._repo = repo; 
        }

        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts([FromQuery]ProductParams productParams) {

            var products = await  _repo.GetProductsAsync(productParams);

            return Ok(products);
        }

        [HttpGet("priceDesc")]

        public async Task<ActionResult<List<Product>>> GetProductsOrderByPriceDesc() {

            var products = await _repo.GetProductsOrderByPriceDesc();

            return Ok(products);
        }

        [HttpGet("priceAsc")]

        public async Task<ActionResult<List<Product>>> GetProductsOrderByPrice() {

            var products = await _repo.GetProductsOrderByPrice();

            return Ok(products);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Product>> GetProduct(int id) {

            return await _repo.GetProductByIdAsync(id);
        }

        [HttpGet("brands")]

        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands() {
            var productBrands = await _repo.GetProductBrandsAsync();
            
            return Ok(productBrands);
        }

        [HttpGet("types")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes() {
            var productBrands = await _repo.GetProductTypesAsync();
            
            return Ok(productBrands);
        }

        
        [HttpGet("typeId")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsByTypeId(int typeId) {
            var productList = await _repo.GetProductsByTypeId(typeId);
            
            return Ok(productList);
        }

        [HttpGet("brandId")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsByBrandId(int brandId) {
            var productList = await _repo.GetProductsByBrandId(brandId);
            
            return Ok(productList);
        }

        [HttpGet("name")]

        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductsByName(string searchText) {
            var retVal = await _repo.GetProductsByName(searchText);
            
            return Ok(retVal);
        }

    }
}
