using AutoMapper;
using SMSApi.Core.Dto.FeeDto;
using SMSApi.Core.Models;

namespace SMSApi.Core.Profiles
{
    public class FeeProfile : Profile
    {
        public FeeProfile()
        {
            CreateMap<Fee, FeeReadDto>();
            CreateMap<FeeCreateDto, Fee>();
            CreateMap<FeeUpdateDto, Fee>();
            CreateMap<Fee, FeeUpdateDto>();
        }
    }
}
