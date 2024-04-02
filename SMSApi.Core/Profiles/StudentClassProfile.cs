using AutoMapper;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Dto.StudentClassDto;

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
