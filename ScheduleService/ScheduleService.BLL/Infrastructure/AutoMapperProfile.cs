using AutoMapper;
using ScheduleService.CoreModels;
using ScheduleService.CoreModels.ContractModels;
using ScheduleService.CoreModels.KpiScheduleModels;
using ScheduleService.Models.ContractModels;
using ScheduleService.Models.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScheduleService.BLL.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Lesson, LessonDto>()
                .ForMember(x => x.Teachers, opt => 
                opt.MapFrom(x => x.Teachers.Select( y => y.Teacher)));
            CreateMap<Teacher, TeacherDto>();
            CreateMap<TeacherDto, Teacher>()
                 .ForMember(x => x.Lessons, opt => opt.Ignore());
            CreateMap<LessonDto, Lesson>()
                 .ForMember(x => x.Teachers, opt => opt.Ignore());
            CreateMap<KpiLesson, Lesson>()
                .ForMember(x => x.Teachers, opt => opt.Ignore());
            CreateMap<KpiLesson, LessonDto>();
            CreateMap<KpiTeacher, TeacherDto>();
            CreateMap<User, DetailedUserDto>().ReverseMap();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}
