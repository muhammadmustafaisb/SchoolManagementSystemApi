using AutoMapper;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Dto.SubjectDto;

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
