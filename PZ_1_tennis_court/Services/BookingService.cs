using AutoMapper;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepo;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepo, IMapper mapper)
        {
            _bookingRepo = bookingRepo;
            _mapper = mapper;
        }

        public BookingDTO Create(CreateBookingDTO createBookingDTO)
        {
            var booking = _mapper.Map<Booking>(createBookingDTO);
            var created = _bookingRepo.Create(booking);
            return _mapper.Map<BookingDTO>(created);
        }

        public bool Delete(int id)
        {
            return _bookingRepo.Delete(id);
        }

        public IEnumerable<BookingDTO> GetAllBookings()
        {
            var bookings = _bookingRepo.GetAll();
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }



        public BookingDTO GetById(int id)
        {
            var booking = _bookingRepo.GetById(id);
            return booking == null ? null : _mapper.Map<BookingDTO>(booking);
        }

        public IEnumerable<BookingDTO> GetByUser(int userId)
        {
            var bookings = _bookingRepo.GetBookingsByUser(userId);
            return _mapper.Map<IEnumerable<BookingDTO>>(bookings);
        }

        public BookingDTO Update(int id, UpdateBookingDTO updateBookingDTO)
        {
            var booking = _bookingRepo.GetById(id);
            if (booking == null) return null;
            _mapper.Map(updateBookingDTO, booking);
            var updated = _bookingRepo.Update(booking);
            return _mapper.Map<BookingDTO>(updated);
        }

        
    }
}
