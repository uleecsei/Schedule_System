using KpiScheduleCore.Services.Interfaces;
using Newtonsoft.Json;
using ScheduleService.CoreModels;
using ScheduleService.CoreModels.KpiScheduleModels;
using ScheduleService.ModelsConstants;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
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
            var responseContent = await File.ReadAllTextAsync(@"D:\User\User\weekNumber.txt");
            var weekNumber = JsonConvert.DeserializeObject<CommonResponse<int>>(responseContent);
            return weekNumber.data;
        }

        public async Task<List<KpiLesson>> GetGroupLessonsList(string groupName)
        {
            var response = await _httpClient.GetAsync($"{KpiScheduleApiConstants.KpiScheduleApiUri}/groups/{groupName}/lessons");

            var responseContent = await File.ReadAllTextAsync(@"D:\User\User\парыТр-71.txt");
            try
            {
                var lessons = JsonConvert.DeserializeObject<CommonResponse<List<KpiLesson>>>(responseContent);
                return lessons.data;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }
}
