using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(RepositoryContext context) : base(context)
        {
        }
    }
}