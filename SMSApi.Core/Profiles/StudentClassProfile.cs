using AutoMapper;
using SMSApi.Core.Dto.StudentClassDto;
using SMSApi.Core.Models;

namespace SMSApi.Core.Profiles
{
    public class StudentClassProfile : Profile
    {
        public StudentClassProfile()
        {
            CreateMap<StudentClass, StudentClassReadDto>();
            CreateMap<StudentClassCreateDto, StudentClass>();
            CreateMap<StudentClassUpdateDto, StudentClass>();
            CreateMap<StudentClass, StudentClassUpdateDto>();
        }
    }
}
