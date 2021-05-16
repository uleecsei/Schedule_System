using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleService.BLL.Services.Abstractions;
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
        public async Task<IActionResult> GetLessons()
        {
            var userId = HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var lessons = await _lessonService.GetLessons(userId);
            return Ok(lessons);
        }
    }
}
