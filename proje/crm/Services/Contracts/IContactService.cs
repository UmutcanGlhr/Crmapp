using Entities.Models;

namespace Services.Contracts
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAllContact(bool trackChanges);
        void CreateContact(Contact contact);
    }
}