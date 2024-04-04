using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Core.Dto.FeeDto;
using SMSApi.Core.Models;
using SMSApi.Core.Repositories;

namespace SMSApi.Controllers
{
    [Route("api/Fee")]
    [ApiController]
    public class FeeController : Controller
    {
        private readonly IFeeRepository _feeRepository;
        private readonly IMapper _mapper;

        public FeeController(IFeeRepository feeRepository, IMapper mapper)
        {
            _feeRepository = feeRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeeReadDto>>> GetAllFees()
        {
            var feeItems = _feeRepository.GetAllFeesAsync();

            return Ok(_mapper.Map<IEnumerable<FeeReadDto>>(await feeItems));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FeeReadDto>> GetFeeById(int id)
        {
            var feeItem = _feeRepository.GetFeeByIdAsync(id);
            if (feeItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<FeeReadDto>(await feeItem));
        }

        [HttpPost]
        public async Task<ActionResult<FeeReadDto>> CreateFee(FeeCreateDto feeCreateDto)
        {
            var feeModel = _mapper.Map<Fee>(feeCreateDto);
            await _feeRepository.CreateFeeAsync(feeModel);
            await _feeRepository.SaveChangesAsync();

            var feeReadDto = _mapper.Map<FeeReadDto>(feeModel);

            return Ok(feeReadDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFee(int id, FeeUpdateDto feeUpdateDto)
        {
            var feeModelFromRepo = await _feeRepository.GetFeeByIdAsync(id);
            if (feeModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(feeUpdateDto, feeModelFromRepo);

            _feeRepository.UpdateFee(feeModelFromRepo);

            await _feeRepository.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialFeeUpdate(int id, JsonPatchDocument<FeeUpdateDto> patchDoc)
        {
            var feeModelFromRepo = await _feeRepository.GetFeeByIdAsync(id);

            if (feeModelFromRepo == null)
            {
                return NotFound();
            }

            var feeToPatch = _mapper.Map<FeeUpdateDto>(feeModelFromRepo);
            patchDoc.ApplyTo(feeToPatch, ModelState);

            if (!TryValidateModel(feeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(feeToPatch, feeModelFromRepo);

            _feeRepository.UpdateFee(feeModelFromRepo);

            await _feeRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFeeById(int id)
        {
            var feeModelFromRepo = _feeRepository.GetFeeByIdAsync(id);

            if (feeModelFromRepo == null)
            {
                return NotFound();
            }

            await _feeRepository.DeleteFeeAsync(await feeModelFromRepo);
            await _feeRepository.SaveChangesAsync();

            return Ok();
        }
    }
}
