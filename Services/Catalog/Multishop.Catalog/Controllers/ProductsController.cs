using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.ProductDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.ProductServices;

namespace Multishop.Catalog.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService _productService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _productService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultProductDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto createProductDto)
        {
            var newValue = _mapper.Map<Product>(createProductDto);
            await _productService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _productService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            
            await _productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok("Ürün Silindi");
        }

        [HttpGet("GetProductsByCategoryId/{id}")]
        public async Task<IActionResult> GetProductsByCategoryId(string id)
        {
            var values =await _productService.GetProductsByCategoryIdAsync(id);
            return Ok(values);
        }
    }
}
