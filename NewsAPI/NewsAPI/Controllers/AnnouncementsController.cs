using Microsoft.AspNetCore.Mvc;
using NewsAPI.Models;
using NewsAPI.Services;
using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Controllers
{
    /// <summary>
    /// Summary comment for Announcements Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AnnouncementsController : ControllerBase
    {
        IAnnouncementCollectionService _announcementCollectionService;

        public AnnouncementsController(IAnnouncementCollectionService announcementCollectionService)
        {
            _announcementCollectionService = announcementCollectionService ?? throw new ArgumentNullException(nameof(AnnouncementsCollectionService));
        }

        /// <summary>
        /// Summary comment for Get method
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public IActionResult Get()
        //{
        //    return Ok("Dummy Get method");
        //}

        /// <summary>
        /// Summary comment for Put method
        /// </summary>
        /// <returns></returns>
        //[HttpPut]
        //public IActionResult Put()
        //{
        //    return Ok("Dummy Put method");
        //}

        /// <summary>
        /// Summary comment for Post method
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //public IActionResult Post()
        //{
        //    return Ok("Dummy Post method");
        //}

        /// <summary>
        /// Summary comment for Delete method
        /// </summary>
        /// <returns></returns>
        //[HttpDelete]
        //public IActionResult Delete()
        //{
        //    return Ok("Dummy Delete method");
        //}

        ///<summary>
        ///Get an announcement by id
        ///</summary>
        ///<param name="id">Introduce the ID</param>
        ///<returns></returns>
        [HttpGet("getById/{id}")]
        public async Task< IActionResult> GetAnnouncementById(Guid id)
        {
            var announcement =await _announcementCollectionService.Get(id);

            if(announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        /// <summary>
        /// Get all announcements
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task< IActionResult> GetAnnouncements()
        {
            return Ok(await _announcementCollectionService.GetAll());
        }

        /// <summary>
        /// Create an announcement
        /// </summary>
        /// <param name="announcement"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateAnnouncement([FromBody] Announcement announcement)
        {
            if (announcement == null)
            {
                return BadRequest("Announcement cannot be null");
            }
            var isCreated = await _announcementCollectionService.Create(announcement);
            if (!(isCreated))
            {
                return BadRequest("Something went wrong");
            }
            //return Ok(announcement);
            return CreatedAtAction(nameof(GetAnnouncementById), new {id = announcement.Id}, announcement);
        }

        /// <summary>
        /// Update an announcement
        /// </summary>
        /// <param name="id"></param>
        /// <param name="announcement"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] Announcement announcement, [Required] Guid id)
        {
            var isUpdated = await _announcementCollectionService.Update(id, announcement);
            if (!isUpdated)
            {
                return NotFound("The announcement was not found!");
            }
            //if(_announcements.Any(a => a.Id == id))
            //{
            //    return NotFound("The announcement was not found");
            //}
            
            return Ok();
        }

        /// <summary>
        /// Delete an announcement by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            var isDeleted = await _announcementCollectionService.Delete(id);
            if (!isDeleted)
            {
                return NotFound("Announcement was not found");
            }
            return Ok();
        }

        /// <summary>
        /// Get by category Id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("getByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetAnnouncementsByCategoryId(string categoryId)
        {
            var announcements = await  _announcementCollectionService.GetAnnouncementsByCategoryId(categoryId);

            return Ok(announcements);
        }
    }
}
