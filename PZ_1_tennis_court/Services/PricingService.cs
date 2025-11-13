using AutoMapper;
using PZ_1_tennis_court.Models;
using PZ_1_tennis_court.Models.DTO;
using PZ_1_tennis_court.Repositories;

namespace PZ_1_tennis_court.Services
{
    public class PricingService : IPricingService
    {
        private readonly IPricingRepository _pricingRepo;
        private readonly IMapper _mapper;

        public PricingService(IPricingRepository pricingRepo, IMapper mapper)
        {
            _pricingRepo = pricingRepo;
            _mapper = mapper;
        }

        public PricingDTO Create(CreatePricingDTO createPricingDTO)
        {
            var pricing = _mapper.Map<Pricing>(createPricingDTO);
            var created = _pricingRepo.Create(pricing);
            return _mapper.Map<PricingDTO>(created);
        }

        public bool Delete(int id)
        {
            return _pricingRepo.Delete(id);
        }

        public IEnumerable<PricingDTO> GetAllPricings()
        {
            var pricings = _pricingRepo.GetAll();
            return _mapper.Map<IEnumerable<PricingDTO>>(pricings);
        }

        public PricingDTO GetById(int id)
        {
            var pricing = _pricingRepo.GetById(id);
            return pricing == null ? null : _mapper.Map<PricingDTO>(pricing);
        }

        public PricingDTO Update(int id, UpdatePricingDTO updatePricingDTO)
        {
            var pricing = _pricingRepo.GetById(id);
            if (pricing == null) return null;
            _mapper.Map(updatePricingDTO, pricing);
            var updated = _pricingRepo.Update(pricing);
            return _mapper.Map<PricingDTO>(updated);
        }
    }
}
