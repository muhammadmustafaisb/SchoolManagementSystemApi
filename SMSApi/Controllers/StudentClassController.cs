using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Data;
using SMSApi.Core.Repositories.Dto.StudentClassDto;
using SMSApi.Core.Repositories.Dto.StudentDto;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Controllers
{
    [Route("api/StudentClass")]
    [ApiController]
    public class StudentClassController : ControllerBase
    {
        private readonly IStudentClassRepo _studentClassRepo;
        private readonly IMapper _mapper;

        public StudentClassController(IStudentClassRepo studentClassRepo, IMapper mapper)
        {
            _studentClassRepo = studentClassRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentClassReadDto>>> GetAllStudentsClass() 
        { 
            var studentClassItem = _studentClassRepo.GetAllStudentClassAsync();
           
            return Ok(_mapper.Map<IEnumerable<StudentClassReadDto>>(await studentClassItem));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentClassReadDto>> GetStudentClassById(int id) 
        {
            var studentClassItem = _studentClassRepo.GetStudentClassByIdAsync(id);
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
            await _studentClassRepo.CreateStudentClassAsync(studentModel);
            await _studentClassRepo.SaveChangesAsync();

            var studentClassReadDto = _mapper.Map<StudentClassReadDto>(studentModel);

            return Ok(studentClassReadDto);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudentClass(int id, StudentClassUpdateDto studentClassUpdateDto) 
        {
            var studentModel = await _studentClassRepo.GetStudentClassByIdAsync(id);
            if (studentModel == null) 
            {
                return NotFound();
            }

            _mapper.Map(studentClassUpdateDto, studentModel);
            _studentClassRepo.UpdateStudentClass(studentModel);

            await _studentClassRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialStudentClassUpdate(int id, JsonPatchDocument<StudentClassUpdateDto> patchDoc)
        {
            var studentClassModelFromRepo = await _studentClassRepo.GetStudentClassByIdAsync(id);

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

            _studentClassRepo.UpdateStudentClass(studentClassModelFromRepo);

            await _studentClassRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudentClassById(int id)
        {
            var studentClassModelFromRepo = _studentClassRepo.GetStudentClassByIdAsync(id);

            if (studentClassModelFromRepo == null)
            {
                return NotFound();
            }

            await _studentClassRepo.DeleteStudentClassAsync(await studentClassModelFromRepo);
            await _studentClassRepo.SaveChangesAsync();

            return Ok();
        }

    }
}
