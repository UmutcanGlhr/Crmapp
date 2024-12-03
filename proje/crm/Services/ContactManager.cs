using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ContactManager : IContactService
    {
        private readonly IRepositoryManager _manager;

        public ContactManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public void CreateContact(Contact contact)
        {
            
            var model = new Contact(){
                ContactID = Guid.NewGuid().ToString(),
                isim = contact.isim,
                Email=contact.Email,
                Konu = contact.Konu,
                Mesaj = contact.Mesaj
            };
            _manager.Contact.Create(model);
            _manager.Save();
        }

        public IEnumerable<Contact> GetAllContact(bool trackChanges)
        {
            return _manager.Contact.FindAll(trackChanges);
        }
    }
}