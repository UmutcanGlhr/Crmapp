using Entities.Models;

namespace Services.Contracts
{
    public interface IAdressService
    {
        void CreateAddress(AdressDtoForInsertion adressDto);

        Adress? GetOneAddress(int id, bool trackChanges);
        IEnumerable<Adress> GetAllAddress(string? id);
    }
}