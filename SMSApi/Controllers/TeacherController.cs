using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Repositories.Data;

namespace SMSApi.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepo _teacherRepo;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepo teacherRepo, IMapper mapper)
        {
            _teacherRepo = teacherRepo;
            _mapper = mapper;
        }


    }
}
