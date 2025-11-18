using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface IBookingService
    {
        IEnumerable<BookingDTO> GetAllBookings();
        BookingDTO GetById(int id);
        BookingDTO Create(CreateBookingDTO createBookingDTO);
        BookingDTO Update(int id, UpdateBookingDTO updateBookingDTO);
        bool Delete(int id);
        IEnumerable<BookingDTO> GetByUser(int userId);

    }
}
