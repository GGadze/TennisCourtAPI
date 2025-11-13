using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Services;

namespace PZ_1_tennis_court.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookingDTO>> GetAll()
        {
            var bookings = _bookingService.GetAllBookings();
            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public ActionResult<BookingDTO> GetById(int id)
        {
            var booking = _bookingService.GetById(id);
            if (booking == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Бронирование с ID {id} не найдено." });
            return Ok(booking);
        }

        [HttpPost]
        public ActionResult<BookingDTO> Create([FromBody] CreateBookingDTO createBookingDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var booking = _bookingService.Create(createBookingDTO);
            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public ActionResult<BookingDTO> Update(int id, [FromBody] UpdateBookingDTO updateBookingDTO)
        {
            var updatedBooking = _bookingService.Update(id, updateBookingDTO);
            if (updatedBooking == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Бронирование с ID {id} не найдено." });
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _bookingService.Delete(id);
            if (!result)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Бронирование с ID {id} не найдено." });
            return NoContent();
        }
    }
}
