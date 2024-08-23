using Apexa.Api;
using Apexa.Data;
using Apexa.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Apexa.Controllers
{
    [SwaggerTag("Containt the endpoint for the advisors")]
    [ApiController]
    [Route("[controller]")]
    public class AdvisorsController : ControllerBase
    {
        private readonly IAdvisorRepository _advisorRepository;
        private readonly IMapper _mapper;

        public AdvisorsController(IAdvisorRepository advisorRepository, IMapper mapper)
        {
            _advisorRepository = advisorRepository;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(List<AdvisorReadDto>), (int)HttpStatusCode.OK)]
        [HttpGet]
        public async Task<IActionResult> ListAdvisors()
        {
            var advisorsFromRepo = await _advisorRepository.GetAdvisors();
            return Ok(_mapper.Map<List<AdvisorReadDto>>(advisorsFromRepo));
        }

        [ProducesResponseType(typeof(AdvisorReadDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [HttpGet("{advisorId}")]
        public async Task<IActionResult> GetAdvisor(int advisorId)
        {
            bool advisorExists = await _advisorRepository.AdviorExists(advisorId);
            if (advisorExists)
            {
                var advisorFromRepo = await _advisorRepository.GetAdvisorById(advisorId);
                return Ok(_mapper.Map<AdvisorReadDto>(advisorFromRepo));
            }
            return NotFound();
        }
       
        [ProducesResponseType(typeof(AdvisorReadDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ModelStateDictionary), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateAdvisor([FromBody] AdvisorCreationDto advisorCreated)
        {
            if (advisorCreated == null)
            {
                return BadRequest();
            }

            if (!string.IsNullOrWhiteSpace(advisorCreated.Sin))
            {
                bool sinIsTaken = await _advisorRepository.SinExists(advisorCreated.Sin);
                if (sinIsTaken)
                {
                    ModelState.AddModelError("Sin", ApiResources.SinTaken);
                }
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            Advisor advisorEntity = _mapper.Map<Advisor>(advisorCreated);

            Random random = new Random();
            int healthStatus  = random.Next(1, 10);

            if (healthStatus <= 6)
            {
                advisorEntity.HealthStatus = ApiResources.Green;
            }
            else if (healthStatus > 6 && healthStatus < 8)
            {
                advisorEntity.HealthStatus = ApiResources.Yelllow;
            }
            else
            {
                advisorEntity.HealthStatus = ApiResources.Red;
            }

            await _advisorRepository.AddAdvior(advisorEntity);
            await _advisorRepository.SaveChangesAsync();

            return Ok(_mapper.Map<AdvisorReadDto>(advisorEntity));
        }

        [ProducesResponseType(typeof(AdvisorReadDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ModelStateDictionary), (int)HttpStatusCode.UnprocessableEntity)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpPut("{advisorId}")]
        public async Task<IActionResult> UpdateAdvisor(int advisorId, [FromBody] AdvisorUpdateDto advisorUpdated)
        {
            bool advisorExists = await _advisorRepository.AdviorExists(advisorId);
            if (advisorExists)
            {
                if (advisorUpdated == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return UnprocessableEntity(ModelState);
                }

                var advisorFromRepo = await _advisorRepository.GetAdvisorById(advisorId);
                _mapper.Map(advisorUpdated, advisorFromRepo);
                await _advisorRepository.SaveChangesAsync();

                return Ok(_mapper.Map<AdvisorReadDto>(advisorFromRepo));
            }
            return NotFound();
        }

        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]       
        [HttpDelete("{advisorId}")]
        public async Task<IActionResult> DeleteAdvisor(int advisorId, [FromBody] AdvisorUpdateDto advisorUpdated)
        {
            bool advisorExists = await _advisorRepository.AdviorExists(advisorId);
            if (advisorExists)
            {                
                var advisorFromRepo = await _advisorRepository.GetAdvisorById(advisorId);
                _advisorRepository.DeleteAdvisor(advisorFromRepo);
                await _advisorRepository.SaveChangesAsync();

                return NoContent();
            }
            return NotFound();
        }
    }
}
