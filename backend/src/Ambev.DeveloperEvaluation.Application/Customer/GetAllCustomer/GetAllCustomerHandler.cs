using Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer
{
    public class GetAllCustomerHandler : IRequestHandler<GetAllCustomerCommand, GetAllCustomerCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetAllCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<GetAllCustomerCommandResult> Handle(GetAllCustomerCommand command, CancellationToken cancellationToken)
        {
           var customerList = await _customerRepository.GetAllAsync(cancellationToken);

            return new GetAllCustomerCommandResult
            {
                Customers = customerList
            };
        }
    }
}
