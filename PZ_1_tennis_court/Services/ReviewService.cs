using AutoMapper;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepo;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepo, IMapper mapper)
        {
            _reviewRepo = reviewRepo;
            _mapper = mapper;
        }

        public ReviewDTO Create(CreateReviewDTO createReviewDTO)
        {
            var review = _mapper.Map<Review>(createReviewDTO);
            var created = _reviewRepo.Create(review);
            return _mapper.Map<ReviewDTO>(created);
        }

        public bool Delete(int id)
        {
            return _reviewRepo.Delete(id);
        }

        public IEnumerable<ReviewDTO> GetAllReviews()
        {
            var reviews = _reviewRepo.GetAll();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public ReviewDTO GetById(int id)
        {
            var review = _reviewRepo.GetById(id);
            return review == null ? null : _mapper.Map<ReviewDTO>(review);
        }

        public IEnumerable<ReviewDTO> GetByCourt(int courtId)
        {
            var reviews = _reviewRepo.GetReviewsByCourt(courtId);
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public ReviewDTO Update(int id, UpdateReviewDTO updateReviewDTO)
        {
            var review = _reviewRepo.GetById(id);
            if (review == null) return null;
            _mapper.Map(updateReviewDTO, review);
            var updated = _reviewRepo.Update(review);
            return _mapper.Map<ReviewDTO>(updated);
        }
    }
}
