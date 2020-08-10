using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess;
using Broidery.DataAccess.Entities;
using Broidery.DataTransferObjects.Dtos;
using Broidery.Interactors;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Broidery.Api.Controllers.Controllers
{
    public class ProductsController : PlainController
    {
        private readonly ProductsInteractor productsInteractor;

        public ProductsController(ProductsInteractor productsInteractor)
        {
            this.productsInteractor = productsInteractor;
        }

        [EnableCors("EnableConnection")]
        [HttpGet("all-products")]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetAllProducts()
        {
            var allProducts = await productsInteractor.GetAllProducts();
            return Ok(allProducts);
        }

        [EnableCors("EnableConnection")]
        [HttpGet("all-active-products")]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetActiveAllProducts()
        {
            var allProducts = await productsInteractor.GetAllActiveProducts();
            return Ok(allProducts);
        }

        [EnableCors("EnableConnection")]
        [HttpGet("product-by-id")]
        public async Task<ActionResult<IProduct>> GetProducts([FromQuery] ProductIdRequestDto idRequestDto)
        {
            var products = await productsInteractor.GetProducts(idRequestDto.Id);
            return Ok(products);
        }

        [EnableCors("EnableConnection")]
        [HttpPut("product-edit")]
        public async Task<ActionResult> EditProduct([FromQuery] ProductIdRequestDto idRequestDto, [FromBody] ProductRequestDto productDto)
        {
            productDto.Id = idRequestDto.Id;
            await productsInteractor.EditProduct(productDto);
            return Ok();
        }

        [EnableCors("EnableConnection")]
        [HttpPut("product-edit-state")]
        public async Task<ActionResult> EditProductState([FromBody] ProductIdRequestDto idRequestDto)
        {
            await productsInteractor.EditProductState(idRequestDto.Id);
            return Ok();
        }

    }
}