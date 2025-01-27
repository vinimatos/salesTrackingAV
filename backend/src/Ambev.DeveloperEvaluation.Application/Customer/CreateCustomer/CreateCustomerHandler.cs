using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IAddressRepository addressRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
        public async Task<CreateCustomerCommandResult> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var address = _mapper.Map<Domain.Entities.Address>(command.Address);
            var createdRating = await _addressRepository.CreateAsync(address, cancellationToken);

            var customer = _mapper.Map<Domain.Entities.Customers>(command);

            customer.Address = address;

            var createdProduct = await _customerRepository.CreateAsync(customer, cancellationToken);
            var result = _mapper.Map<CreateCustomerCommandResult>(createdProduct);
            return result;
        }
    }
}
