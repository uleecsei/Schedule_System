using KpiScheduleCore.Services.Interfaces;
using ScheduleService.Models;
using ScheduleService.ModelsConstants;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace KpiScheduleCore.Services
{
    public class KpiScheduleService : IKpiScheduleService
    {
        private readonly HttpClient _httpClient;

        public KpiScheduleService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<int> GetCurrentWeekNumber()
        {
            var response = await _httpClient.GetAsync($"{KpiScheduleApiConstants.KpiScheduleApiUri}/weeks");
            var responseContent = await response.Content.ReadAsStringAsync();
            var weekNumber = JsonSerializer.Deserialize<CommonResponse<int>>(responseContent);
            return weekNumber.data;
        }

        public async Task<List<Lesson>> GetGroupLessonsList(string groupName)
        {
            var response = await _httpClient.GetAsync($"{KpiScheduleApiConstants.KpiScheduleApiUri}/groups/{groupName}/lessons");
            var responseContent = await response.Content.ReadAsStringAsync();
            var lessons = JsonSerializer.Deserialize<CommonResponse<List<Lesson>>>(responseContent);
            return lessons.data;
        }
    }
}
