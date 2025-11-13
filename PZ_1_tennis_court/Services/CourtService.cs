using AutoMapper;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class CourtService : ICourtService
    {
        private readonly ICourtRepository _courtRepo;
        private readonly IMapper _mapper;

        public CourtService(ICourtRepository courtRepo, IMapper mapper)
        {
            _courtRepo = courtRepo;
            _mapper = mapper;
        }

        public CourtDTO Create(CreateCourtDTO createCourtDTO)
        {
            var court = _mapper.Map<Court>(createCourtDTO);
            var created = _courtRepo.Create(court);
            return _mapper.Map<CourtDTO>(created);
        }

        public bool Delete(int id)
        {
            return _courtRepo.Delete(id);
        }

        public IEnumerable<CourtDTO> GetAllCourts()
        {
            var courts = _courtRepo.GetAll();
            return _mapper.Map<IEnumerable<CourtDTO>>(courts);
        }

        public CourtDTO GetById(int id)
        {
            var court = _courtRepo.GetById(id);
            return court == null ? null : _mapper.Map<CourtDTO>(court);
        }

        public CourtDTO Update(int id, UpdateCourtDTO updateCourtDTO)
        {
            var court = _courtRepo.GetById(id);
            if (court == null) return null;
            _mapper.Map(updateCourtDTO, court);
            var updated = _courtRepo.Update(court);
            return _mapper.Map<CourtDTO>(updated);
        }
    }
}
