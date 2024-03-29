using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Data;
using SMSApi.Core.Repositories.Dto.StudentDto;

namespace SMSApi.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo studentRepo, IMapper mapper)
        {
            _studentRepo = studentRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentReadDto>>> GetAllStudents() 
        {
            var studentItems = _studentRepo.GetAllStudentAsync();

            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(await studentItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentReadDto>> GetStudentById(int id) 
        {
            var student = _studentRepo.GetAllStudentByIdAsync(id);

            if (student == null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentReadDto>(await student));
        }

        [HttpPost]
        public async Task<ActionResult<StudentReadDto>> CreateStudent(StudentCreateDto studentCreateDto) 
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            await _studentRepo.CreateStudentAsync(studentModel);
            await _studentRepo.SaveChangesAsync();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return Ok(studentReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id, StudentUpdateDto studentUpdateDto) 
        {
            var studentModel = await _studentRepo.GetAllStudentByIdAsync(id);
            if (studentModel == null) 
            {
                return NotFound();
            }

            _mapper.Map(studentUpdateDto, studentModel);
            _studentRepo.UpdateStudent(studentModel);

            await _studentRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialStudentUpdate(int id, JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelFromRepo = await _studentRepo.GetAllStudentByIdAsync(id);

            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentModelFromRepo);

            _studentRepo.UpdateStudent(studentModelFromRepo);

            await _studentRepo.SaveChangesAsync();

            return Ok();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentById(int id)
        {
            var studentModelFromRepo = _studentRepo.GetAllStudentByIdAsync(id);

            if (studentModelFromRepo == null)
            {
                return NotFound();
            }

            await _studentRepo.DeleteStudentAsync(await studentModelFromRepo);
            await _studentRepo.SaveChangesAsync();

            return Ok();
        }

    }
}
