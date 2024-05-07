using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Multishop.Catalog.Dtos.CategoryDtos;
using Multishop.Catalog.Entities;
using Multishop.Catalog.Services.CategoryServices;

namespace Multishop.Catalog.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService, IMapper _mapper) : ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var values = await _categoryService.GetAllAsync();
            return Ok(_mapper.Map<List<ResultCategoryDto>>(values));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto createCategoryDto)
        {
            var newValue = _mapper.Map<Category>(createCategoryDto);
            await _categoryService.CreateAsync(newValue);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var value = await _categoryService.GetByIdAsync(id);
            return Ok(value);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryService.UpdateAsync(value);
            return Ok("Kategori Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok("Kategori Silindi");
        }


    }
}
