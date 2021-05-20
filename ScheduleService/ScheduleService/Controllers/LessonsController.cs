using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.BLL.Services.Abstractions;
using ScheduleService.Models.ContractModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(LessonResponse), 200)]
        public async Task<IActionResult> GetLessons()
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var lessons = await _lessonService.GetLessons(userId);
            return Ok(lessons);
        }

        [HttpPost]
        [Route("{lessonId}/history/{date}/information/")]
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> PostLessonInforamtion(int lessonId, DateTime date, [FromBody] LessonInforamtionDto inforamtion)
        {
            var result = await _lessonService.PostLessonInformation(lessonId, date, inforamtion);
            if (result)
            {
                return StatusCode(201);
            }
            return BadRequest("Fail to create lesson information");
        }

        [HttpPost]
        [Route("{lessonId}/history/{date}/file/")]
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> AddLessonFile(int lessonId, DateTime date, [FromBody] LessonFileDto lessonFile)
        {
            var result = await _lessonService.PostLessonFile(lessonId, date, lessonFile);
            if (result)
            {
                return StatusCode(201);
            }
            return BadRequest("Fail to create lesson file");
        }
    }
}
