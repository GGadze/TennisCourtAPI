using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Services;

namespace PZ_1_tennis_court.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            _reviewService = reviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewDTO>> GetAll()
        {
            var reviews = _reviewService.GetAllReviews();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public ActionResult<ReviewDTO> GetById(int id)
        {
            var review = _reviewService.GetById(id);
            if (review == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Отзыв с ID {id} не найден." });
            return Ok(review);
        }

        [HttpPost]
        public ActionResult<ReviewDTO> Create([FromBody] CreateReviewDTO createReviewDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var review = _reviewService.Create(createReviewDTO);
            return CreatedAtAction(nameof(GetById), new { id = review.Id }, review);
        }

        [HttpPut("{id}")]
        public ActionResult<ReviewDTO> Update(int id, [FromBody] UpdateReviewDTO updateReviewDTO)
        {
            var updatedReview = _reviewService.Update(id, updateReviewDTO);
            if (updatedReview == null)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Отзыв с ID {id} не найден." });
            return Ok(updatedReview);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _reviewService.Delete(id);
            if (!result)
                return NotFound(new { title = "Not Found", status = 404, detail = $"Отзыв с ID {id} не найден." });
            return NoContent();
        }
    }
}
