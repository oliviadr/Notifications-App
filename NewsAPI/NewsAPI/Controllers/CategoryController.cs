using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;

namespace NewsAPI.Controllers
{
    /// <summary>
    /// Summary comment for Category Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        static List<Category> categories;

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(categories);
        }

        /// <summary>
        /// Get Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return Ok(existingCategory);
        }

        /// <summary>
        /// Delete Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            categories.Remove(existingCategory);
            return Ok();
        }
        
        /// <summary>
        /// Post Category by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("{id}")]
        public IActionResult PostCategory(Guid id)
        {
            var existingCategory = categories.FirstOrDefault(a => a.Id == id);
            if (existingCategory == null)
            {
                return NotFound();
            }
            return Ok(existingCategory);
        }
    }
}
