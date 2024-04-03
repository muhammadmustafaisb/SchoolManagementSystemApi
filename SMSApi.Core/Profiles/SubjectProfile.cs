using AutoMapper;
using SMSApi.Core.Dto.SubjectDto;
using SMSApi.Core.Models;

namespace SMSApi.Core.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectReadDto>();
            CreateMap<SubjectCreateDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();
            CreateMap<Subject, SubjectUpdateDto>();
        }
    }
}
