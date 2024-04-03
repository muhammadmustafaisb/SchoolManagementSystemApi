using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Dto.SubjectDto;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;

namespace SMSApi.Controllers
{
    [Route("api/Subject")]
    [ApiController]
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectReadDto>>> GetAllSubjects()
        {
            var subjectItems = _subjectRepository.GetAllSubjectAsync();

            return Ok(_mapper.Map<IEnumerable<SubjectReadDto>>(await subjectItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectReadDto>> GetSubjectById(int id)
        {
            var subjectItem = _subjectRepository.GetSubjectByIdAsync(id);
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
            await _subjectRepository.CreateSubjectAsync(subjectModel);
            await _subjectRepository.SaveChangesAsync();

            var subjectReadDto = _mapper.Map<SubjectReadDto>(subjectModel);

            return Ok(subjectReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateSubject(int id, SubjectUpdateDto subjectUpdateDto)
        {
            var subjectModelFromRepo = await _subjectRepository.GetSubjectByIdAsync(id);
            if (subjectModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(subjectUpdateDto, subjectModelFromRepo);

            _subjectRepository.UpdateSubject(subjectModelFromRepo);

            await _subjectRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialSubjectUpdate(int id, JsonPatchDocument<SubjectUpdateDto> patchDoc)
        {
            var subjectModelFromRepo = await _subjectRepository.GetSubjectByIdAsync(id);

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

            _subjectRepository.UpdateSubject(subjectModelFromRepo);

            await _subjectRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubjectById(int id)
        {
            var subjectModelFromRepo = _subjectRepository.GetSubjectByIdAsync(id);

            if (subjectModelFromRepo == null)
            {
                return NotFound();
            }

            await _subjectRepository.DeleteSubjectAsync(await subjectModelFromRepo);
            await _subjectRepository.SaveChangesAsync();

            return Ok();
        }

    }
}
