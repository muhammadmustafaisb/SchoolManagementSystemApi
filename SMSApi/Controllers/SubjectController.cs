using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories.Data;
using SMSApi.Core.Repositories.Dto.StudentDto;
using SMSApi.Core.Repositories.Dto.SubjectDto;
using SMSApi.Infrastructure.Data;

namespace SMSApi.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepo _subjectRepo;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepo subjectRepo, IMapper mapper)
        {
            _subjectRepo = subjectRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectReadDto>>> GetAllSubjects()
        {
            var subjectItems = _subjectRepo.GetAllSubjectAsync();

            return Ok(_mapper.Map<IEnumerable<SubjectReadDto>>(await subjectItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectReadDto>> GetSubjectById(int id)
        {
            var subjectItem = _subjectRepo.GetSubjectByIdAsync(id);
            if (subjectItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<SubjectReadDto>(await subjectItem));
        }

        [HttpPost]
        public async Task<ActionResult<SubjectReadDto>> CreateSubject(SubjectCreateDto subjectCreateDto)
        {
            var subjectModel = _mapper.Map<Subject>(subjectCreateDto);
            await _subjectRepo.CreateSubjectAsync(subjectModel);
            await _subjectRepo.SaveChangesAsync();

            var subjectReadDto = _mapper.Map<SubjectReadDto>(subjectModel);

            return Ok(subjectReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(int id, SubjectUpdateDto subjectUpdateDto)
        {
            var subjectModelFromRepo = await _subjectRepo.GetSubjectByIdAsync(id);
            if (subjectModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(subjectUpdateDto, subjectModelFromRepo);

            _subjectRepo.UpdateSubject(subjectModelFromRepo);

            await _subjectRepo.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialSubjectUpdate(int id, JsonPatchDocument<SubjectUpdateDto> patchDoc)
        {
            var subjectModelFromRepo = await _subjectRepo.GetSubjectByIdAsync(id);

            if (subjectModelFromRepo == null)
            {
                return NotFound();
            }

            var subjectToPatch = _mapper.Map<SubjectUpdateDto>(subjectModelFromRepo);
            patchDoc.ApplyTo(subjectToPatch, ModelState);

            if (!TryValidateModel(subjectToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(subjectToPatch, subjectModelFromRepo);

            _subjectRepo.UpdateSubject(subjectModelFromRepo);

            await _subjectRepo.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubjectById(int id)
        {
            var subjectModelFromRepo = _subjectRepo.GetSubjectByIdAsync(id);

            if (subjectModelFromRepo == null)
            {
                return NotFound();
            }

            await _subjectRepo.DeleteSubjectAsync(await subjectModelFromRepo);
            await _subjectRepo.SaveChangesAsync();

            return Ok();
        }

    }
}
