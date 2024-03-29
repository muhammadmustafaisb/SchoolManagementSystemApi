using AutoMapper;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Dto.StudentDto;

namespace SMSApi.Core.Profiles.StudentProfile
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
    }
}
