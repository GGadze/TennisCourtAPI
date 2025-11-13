using PZ_1_tennis_court.Models.DTO;

namespace PZ_1_tennis_court.Services
{
    public interface IPricingService
    {
        IEnumerable<PricingDTO> GetAllPricings();
        PricingDTO GetById(int id);
        PricingDTO Create(CreatePricingDTO createPricingDTO);
        PricingDTO Update(int id, UpdatePricingDTO updatePricingDTO);
        bool Delete(int id);
    }
}
