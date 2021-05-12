using ScheduleService.Models.ContractModels;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Services.Abstractions
{
    public interface IAuthService
    {
        Task<string> GenerateToken(DetailedUserDto user, string keyWord);
        Task<DetailedUserDto> LogIn(UserForLoginDto user);
        Task<DetailedUserDto> Register(UserForRegisterDto user);
    }
}
