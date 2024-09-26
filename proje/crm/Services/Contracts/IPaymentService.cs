using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
  public interface IPaymentService
  {
    void CreatePayment(PaymentDtoForCreation paymentDto);
    IEnumerable<Payment> GetAllPayment(bool trackChanges);

  }
}