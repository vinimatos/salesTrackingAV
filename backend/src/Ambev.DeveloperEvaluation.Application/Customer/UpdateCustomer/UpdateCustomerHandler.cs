using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(ICustomerRepository customerRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerCommandResult> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var customer = _mapper.Map<Domain.Entities.Customers>(command);

            var createdProduct = await _customerRepository.UpdateAsync(customer, cancellationToken);
            return new UpdateCustomerCommandResult 
            { 
                Date = DateTime.UtcNow,
            };
        }
    }
}
