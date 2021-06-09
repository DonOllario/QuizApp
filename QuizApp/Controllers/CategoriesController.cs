using Data;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Controllers.RequestsAndResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {

        private readonly QuizAppDbContext _context;
        public CategoriesController(QuizAppDbContext context)
        {
            _context = context;
        }

        [HttpGet("id:Guid", Name = "GetCategory")]
        public async Task<ActionResult<CategoryResponse>> GetCategory(Guid id)
        {
            var categoryFromDb = await _context.Categories.FindAsync(id);
            var response = new CategoryResponse
            {
                Id = categoryFromDb.Id,
                Name = categoryFromDb.Name,
                Description = categoryFromDb.Description
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> AddCategory([FromBody] AddCategoryRequest request)
        {
            var category = new Category
            {
                Name = request.Name,
                Description = request.Description
            };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            var response = new CategoryResponse
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };

            return CreatedAtRoute("GetCategory", new { id = response.Id }, response);
        }

        [HttpPatch("id:Guid")]
        public async Task<ActionResult<CategoryResponse>> UpdateCategory(Guid id, [FromBody] UpdateCategoryRequest request)
        {
            var categoryUpdate = _context.Categories.Find(id);

            if (request.Name != null)
            {
                categoryUpdate.Name = request.Name;
            }
            else if (request.Description != null)
            {
                categoryUpdate.Description = request.Description;
            }

            _context.Categories.Update(categoryUpdate);
            await _context.SaveChangesAsync();



            return Ok("The Category has been updated successfully!");
        }

    }

}
