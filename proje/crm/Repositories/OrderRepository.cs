using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepositoy
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }
    }
}