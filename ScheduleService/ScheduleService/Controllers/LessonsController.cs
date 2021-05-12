using Microsoft.AspNetCore.Mvc;
using ScheduleService.BLL.Services.Abstractions;
using System.Threading.Tasks;

namespace ScheduleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("{groupName}")]
        public async Task<IActionResult> GetLessons(string groupName)
        {
            var lessons = await _lessonService.GetLessons(groupName);
            return Ok(lessons);
        }
    }
}
