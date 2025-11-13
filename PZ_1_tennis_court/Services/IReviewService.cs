using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetAllReviews();
        ReviewDTO GetById(int id);
        ReviewDTO Create(CreateReviewDTO createReviewDTO);
        ReviewDTO Update(int id, UpdateReviewDTO updateReviewDTO);
        bool Delete(int id);
        IEnumerable<ReviewDTO> GetByCourt(int courtId);
    }
}
