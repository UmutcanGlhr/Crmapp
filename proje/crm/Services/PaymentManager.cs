using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;


namespace Services
{
    public class PaymentManager : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryManager _manager;

        public PaymentManager(IMapper mapper, IRepositoryManager manager)
        {
            _mapper = mapper;
            _manager = manager;
        }

        public void CreatePayment(PaymentDtoForCreation paymentDto)
        {
            Payment payment = _mapper.Map<Payment>(paymentDto);
            _manager.Payment.Create(payment);
            _manager.Save();

        }

        public IEnumerable<Payment> GetAllPayment(bool trackChanges)
        {
            return _manager.Payment.FindAll(trackChanges);
        }
    }

}