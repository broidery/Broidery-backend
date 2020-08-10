using System.Collections.Generic;
using System.Threading.Tasks;
using Broidery.DataAccess.Entities;
using Broidery.DataTransferObjects.Dtos;
using Broidery.Interactors;
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

        [HttpGet("all-active-products")]
        public async Task<ActionResult<IEnumerable<IProduct>>> GetAllProducts()
        {
            var allProducts = await productsInteractor.GetAllActiveProducts();
            return Ok(allProducts);
        }

        [HttpGet("products")]
        public async Task<ActionResult<IProduct>> GetProducts([FromQuery] ProductRequestDto requestDto)
        {
            var products = await productsInteractor.GetProducts(requestDto.Id);
            return Ok(products);
        }

    }
}