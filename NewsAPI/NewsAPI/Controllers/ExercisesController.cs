using Microsoft.AspNetCore.Mvc;

namespace NewsAPI.Controllers
{
    /// <summary>
    /// Exercises Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : ControllerBase
    {
        /// <summary>
        /// Get by id and sum
        /// </summary>
        /// <param name="id"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromQuery] double param1, [FromQuery] double param2)
        {
            double sum = param1 + param2;
            return Ok($"{id} : {sum}");
        }

        /// <summary>
        /// Sum for all elements
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        [HttpPost("sum")]
        public IActionResult CalculateSum([FromBody] List<double> numbers)
        {
            if(numbers== null || numbers.Count == 0)
            {
                return BadRequest("The list is null or empty!");
            }
            var sum = numbers.Sum();
            return Ok(sum);
        }

        public static List<string> strings = new List<string>
        {
            "string 1", "string 2", "string 3"
        };

        /// <summary>
        /// Get all strings
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(strings);
        }

        /// <summary>
        /// Update string by index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        [HttpPut("{index}")]
        public IActionResult UpdateValue(int index, [FromBody] string newValue)
        {
            if(index < 0 || index >= strings.Count)
            {
                return BadRequest("Index out of bounds");
            }
            if(string.IsNullOrEmpty(newValue))
            {
                return BadRequest("New value is empty");
            }
            strings[index] = newValue;
            return Ok(strings);
        }

        /// <summary>
        /// Delete from strings list
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [HttpDelete("list/{index}")]
        public IActionResult DeleteFromList(int index)
        {
            if(strings == null || index < 0 || index >= strings.Count)
            {
                return BadRequest("Invalid");
            }
            strings.RemoveAt(index);
            return Ok(strings);
        }
    }
}
