using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        public ContactRepository(RepositoryContext context) : base(context)
        {
        }
    }
}