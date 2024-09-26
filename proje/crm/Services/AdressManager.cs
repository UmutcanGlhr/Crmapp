using AutoMapper;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class AdressManager : IAdressService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        public AdressManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateAddress(AdressDtoForInsertion adressDto)
        {
            Adress adress = _mapper.Map<Adress>(adressDto);
            _manager.Adress.Create(adress);
            _manager.Save();
        }

        public IEnumerable<Adress> GetAllAddress(string? id)
        {
            return _manager.Adress.GetAllAddress(id);
        }

        public Adress? GetOneAddress(int id, bool trackChanges)
        {
            var address = _manager.Adress.GetOneAddress(id, trackChanges);
            if (address is null)
                throw new Exception(" Product Not Found");
            return address;
        }
    }
}