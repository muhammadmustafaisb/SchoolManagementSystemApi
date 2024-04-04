using AutoMapper;
using SMSApi.Core.Dto.ResultDto;
using SMSApi.Core.Models;

namespace SMSApi.Core.Profiles
{
    public class ResultProfile : Profile
    {
        public ResultProfile()
        {
            CreateMap<Result, ResultCreateDto>();
            CreateMap<ResultReadDto, Result>();
            CreateMap<ResultUpdateDto, Result>();
            CreateMap<Result, ResultUpdateDto>();
        }
    }
}
