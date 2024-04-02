using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Data;
using SMSApi.Core.Repositories.Dto.StudentDto;
using SMSApi.Core.Repositories.Dto.TeacherDto;
using SMSApi.Infrastructure.Data;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherReadDto>>> GetAllTeachers()
        {
            var teacherItems = _teacherRepo.GetAllTeacherAsync();

            return Ok(_mapper.Map<IEnumerable<TeacherReadDto>>(await teacherItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReadDto>> GetTeacherById(int id) 
        { 
            var teacherItem = _teacherRepo.GetTeacherByIdAsync(id);
            if (teacherItem == null) 
            { 
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherReadDto>(await teacherItem));
        }

        [HttpPost]
        public async Task<ActionResult<TeacherReadDto>> CreateTeacher(TeacherCreateDto teacherCreateDto) 
        {
            var teacherModel = _mapper.Map<Teacher>(teacherCreateDto);
            await _teacherRepo.CreateTeacherAsync(teacherModel);
            await _teacherRepo.SaveChangesAsync();

            var teacherReadDto = _mapper.Map<TeacherReadDto>(teacherModel);

            return Ok(teacherReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto)
        {
            var teacherModelFromRepo = await _teacherRepo.GetTeacherByIdAsync(id);
            if (teacherModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(teacherUpdateDto, teacherModelFromRepo);

            _teacherRepo.UpdateTeacher(teacherModelFromRepo);

            await _teacherRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialTeacherUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {
            var teacherModelFromRepo = await _teacherRepo.GetTeacherByIdAsync(id);

            if (teacherModelFromRepo == null)
            {
                return NotFound();
            }

            var teacherToPatch = _mapper.Map<TeacherUpdateDto>(teacherModelFromRepo);
            patchDoc.ApplyTo(teacherToPatch, ModelState);

            if (!TryValidateModel(teacherToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(teacherToPatch, teacherModelFromRepo);

            _teacherRepo.UpdateTeacher(teacherModelFromRepo);

            await _teacherRepo.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherById(int id)
        {
            var teacherModelFromRepo = _teacherRepo.GetTeacherByIdAsync(id);

            if (teacherModelFromRepo == null)
            {
                return NotFound();
            }

            await _teacherRepo.DeleteTeacherAsync(await teacherModelFromRepo);
            await _teacherRepo.SaveChangesAsync();

            return Ok();
        }
    }
}
