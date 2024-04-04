using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Dto.StudentClassDto;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;

namespace SMSApi.Controllers
{
    [Route("api/StudentClass")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassRepository _studentClassRepository;
        private readonly IMapper _mapper;

        public StudentClassController(IStudentClassRepository studentClassRepo, IMapper mapper)
        {
            _studentClassRepository = studentClassRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClassReadDto>>> GetAllStudentsClass() 
        { 
            var studentClassItem = _studentClassRepository.GetAllStudentClassAsync();
           
            return Ok(_mapper.Map<IEnumerable<StudentClassReadDto>>(await studentClassItem));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClassReadDto>> GetStudentClassById(int id) 
        {
            var studentClassItem = _studentClassRepository.GetStudentClassByIdAsync(id);
            if (studentClassItem == null) 
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentClassReadDto>(await studentClassItem));
        }

        [HttpPost]
        public async Task<ActionResult<StudentClassReadDto>> CreateStudent(StudentClassCreateDto studentClassCreateDto) 
        {
            var studentModel = _mapper.Map<StudentClass>(studentClassCreateDto);
            await _studentClassRepository.CreateStudentClassAsync(studentModel);
            await _studentClassRepository.SaveChangesAsync();

            var studentClassReadDto = _mapper.Map<StudentClassReadDto>(studentModel);

            return Ok(studentClassReadDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentClass(int id, StudentClassUpdateDto studentClassUpdateDto) 
        {
            var studentModel = await _studentClassRepository.GetStudentClassByIdAsync(id);
            if (studentModel == null) 
            {
                return NotFound();
            }

            _mapper.Map(studentClassUpdateDto, studentModel);
            _studentClassRepository.UpdateStudentClass(studentModel);

            await _studentClassRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialStudentClassUpdate(int id, JsonPatchDocument<StudentClassUpdateDto> patchDoc)
        {
            var studentClassModelFromRepo = await _studentClassRepository.GetStudentClassByIdAsync(id);

            if (studentClassModelFromRepo == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentClassUpdateDto>(studentClassModelFromRepo);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentClassModelFromRepo);

            _studentClassRepository.UpdateStudentClass(studentClassModelFromRepo);

            await _studentClassRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentClassById(int id)
        {
            var studentClassModelFromRepo = _studentClassRepository.GetStudentClassByIdAsync(id);

            if (studentClassModelFromRepo == null)
            {
                return NotFound();
            }

            await _studentClassRepository.DeleteStudentClassAsync(await studentClassModelFromRepo);
            await _studentClassRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
