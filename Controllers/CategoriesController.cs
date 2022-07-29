using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Commands;
using TransactionAPI.Models;
using TransactionAPI.Services;
using TransactionAPI;



namespace TransactionAPI.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoriesService categoriesService, ILogger<CategoriesController> logger)
        {
            _categoriesService = categoriesService;
            _logger = logger;
        }

        [HttpGet]
       public async Task<IActionResult> GetCategories([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of categories", page);
            var result = await _categoriesService.GetCategories(page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }

        [HttpGet("{categoryCode}")]
        public async Task<IActionResult> GetCategory([FromRoute] string code)
        {
            var category= await _categoriesService.GetCategory(code);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var result = await _categoriesService.CreateCategory(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
           

        [HttpDelete("{categoryCode}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] string code)
        {
            var result = await _categoriesService.DeleteCategory(code);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        
    }
}
