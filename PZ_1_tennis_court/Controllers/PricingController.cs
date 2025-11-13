using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Services;

namespace PZ_1_tennis_court.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IPricingService _pricingService;
        private readonly IMapper _mapper;

        public PricingController(IPricingService pricingService, IMapper mapper)
        {
            _pricingService = pricingService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PricingDTO>> GetAll()
        {
            var pricings = _pricingService.GetAllPricings();
            return Ok(pricings);
        }

        [HttpGet("{id}")]
        public ActionResult<PricingDTO> GetById(int id)
        {
            var pricing = _pricingService.GetById(id);
            if (pricing == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Тариф с ID {id} не найден." });
            return Ok(pricing);
        }

        [HttpPost]
        public ActionResult<PricingDTO> Create([FromBody] CreatePricingDTO createPricingDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pricing = _pricingService.Create(createPricingDTO);
            return CreatedAtAction(nameof(GetById), new { id = pricing.Id }, pricing);
        }

        [HttpPut("{id}")]
        public ActionResult<PricingDTO> Update(int id, [FromBody] UpdatePricingDTO updatePricingDTO)
        {
            var updatedPricing = _pricingService.Update(id, updatePricingDTO);
            if (updatedPricing == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Тариф с ID {id} не найден." });
            return Ok(updatedPricing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _pricingService.Delete(id);
            if (!result)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Тариф с ID {id} не найден." });
            return NoContent();
        }
    }
}
