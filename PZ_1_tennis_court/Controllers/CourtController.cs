using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Services;

namespace PZ_1_tennis_court.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourtController : ControllerBase
    {
        private readonly ICourtService _courtService;
        private readonly IMapper _mapper;

        public CourtController(ICourtService courtService, IMapper mapper)
        {
            _courtService = courtService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<CourtDTO>> GetAll()
        {
            var courts = _courtService.GetAllCourts();
            return Ok(courts);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult<CourtDTO> GetById(int id)
        {
            var court = _courtService.GetById(id);
            if (court == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Корт с ID {id} не найден." });
            return Ok(court);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult<CourtDTO> Create([FromBody] CreateCourtDTO createCourtDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var court = _courtService.Create(createCourtDTO);
            return CreatedAtAction(nameof(GetById), new { id = court.Id }, court);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public ActionResult<CourtDTO> Update(int id, [FromBody] UpdateCourtDTO updateCourtDTO)
        {
            var updatedCourt = _courtService.Update(id, updateCourtDTO);
            if (updatedCourt == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Корт с ID {id} не найден." });
            return Ok(updatedCourt);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _courtService.Delete(id);
            if (!result)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Корт с ID {id} не найден." });
            return NoContent();
        }
    }
}
