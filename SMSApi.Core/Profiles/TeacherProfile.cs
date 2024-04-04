using AutoMapper;
using SMSApi.Core.Dto.TeacherDto;
using SMSApi.Core.Models;

namespace SMSApi.Core.Profiles
{
    public class TeacherProfile : Profile
    {
        public TeacherProfile()
        {
                CreateMap<Teacher, TeacherReadDto>();
                CreateMap<TeacherCreateDto, Teacher>();
                CreateMap<TeacherUpdateDto, Teacher>();
                CreateMap<Teacher, TeacherUpdateDto>();
        }

    }
}
