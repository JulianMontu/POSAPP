using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Aplication.DTOS.Request;
using POS.Aplication.Interfaces;
using POS.Domain.Entities;
using POS.Infrastructure.Commons.Bases;

namespace POS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAplication _categoryAplication;

        public CategoryController(ICategoryAplication categoryAplication)
        {
            _categoryAplication = categoryAplication;
        }

        [HttpPost]
        public async Task<IActionResult> ListCategories([FromBody] BaseFiltersRequest filters)
        {
            var response = await _categoryAplication.ListCategories(filters);
            return Ok(response);
        }

        [HttpGet("Select")]
        public async Task<IActionResult> ListSelectCategories()
        {
            var response = await _categoryAplication.ListSelectCategories();
            return Ok(response);
        }

        [HttpGet("{categoryId:int}")]
        public async Task<IActionResult> CategoryById(int categoryId)
        {
            var response = await _categoryAplication.CategoryById(categoryId);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterCategory([FromBody] CategoryRequestDTO requestDTO)
        {
            var response = await _categoryAplication.RegisterCategory(requestDTO);
            return Ok(response);
        }

        [HttpPut("Edit/{categoryId:int}")]
        public async Task<IActionResult> EditCategory(int categoryId, [FromBody] CategoryRequestDTO requestDTO)
        {
            var response = await _categoryAplication.EditCategory(categoryId,requestDTO);
            return Ok(response);
        }

        [HttpPut("Remove/{categoryId:int}")]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            var response = await _categoryAplication.RemoveCategory(categoryId);
            return Ok(response);
        }
    }
}
