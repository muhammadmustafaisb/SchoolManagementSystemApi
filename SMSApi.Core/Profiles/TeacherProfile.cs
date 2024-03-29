
using AutoMapper;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Dto.StudentDto;
using SMSApi.Core.Repositories.Dto.TeacherDto;

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
