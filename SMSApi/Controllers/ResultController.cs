using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Dto.ResultDto;

namespace SMSApi.Controllers
{
    [Route("api/Result")]
    [ApiController]
    public class ResultController : Controller
    {
        private readonly IResult _result;
        private readonly IMapper _mapper;

        public ResultController(IResult result, IMapper mapper)
        {
            _result = result;
            _mapper = mapper;
        }



    }
}
