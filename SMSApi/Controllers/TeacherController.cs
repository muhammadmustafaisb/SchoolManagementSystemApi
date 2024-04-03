using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Dto.TeacherDto;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;

namespace SMSApi.Controllers
{
    [Route("api/Teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeacherReadDto>>> GetAllTeachers()
        {
            var teacherItems = _teacherRepository.GetAllTeacherAsync();

            return Ok(_mapper.Map<IEnumerable<TeacherReadDto>>(await teacherItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TeacherReadDto>> GetTeacherById(int id) 
        { 
            var teacherItem = _teacherRepository.GetTeacherByIdAsync(id);
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
            await _teacherRepository.CreateTeacherAsync(teacherModel);
            await _teacherRepository.SaveChangesAsync();

            var teacherReadDto = _mapper.Map<TeacherReadDto>(teacherModel);

            return Ok(teacherReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeacher(int id, TeacherUpdateDto teacherUpdateDto)
        {
            var teacherModelFromRepo = await _teacherRepository.GetTeacherByIdAsync(id);
            if (teacherModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(teacherUpdateDto, teacherModelFromRepo);

            _teacherRepository.UpdateTeacher(teacherModelFromRepo);

            await _teacherRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialTeacherUpdate(int id, JsonPatchDocument<TeacherUpdateDto> patchDoc)
        {
            var teacherModelFromRepo = await _teacherRepository.GetTeacherByIdAsync(id);

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

            _teacherRepository.UpdateTeacher(teacherModelFromRepo);

            await _teacherRepository.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeacherById(int id)
        {
            var teacherModelFromRepo = _teacherRepository.GetTeacherByIdAsync(id);

            if (teacherModelFromRepo == null)
            {
                return NotFound();
            }

            await _teacherRepository.DeleteTeacherAsync(await teacherModelFromRepo);
            await _teacherRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
