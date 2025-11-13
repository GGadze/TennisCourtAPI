using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface ICourtService
    {
        IEnumerable<CourtDTO> GetAllCourts();
        CourtDTO GetById(int id);
        CourtDTO Create(CreateCourtDTO createCourtDTO);
        CourtDTO Update(int id, UpdateCourtDTO updateCourtDTO);
        bool Delete(int id);
    }
}
