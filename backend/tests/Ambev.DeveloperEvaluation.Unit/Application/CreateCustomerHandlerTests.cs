using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Xunit;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateCustomerHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly CreateCustomerHandler _handler;

        public CreateCustomerHandlerTests()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _addressRepository = Substitute.For<IAddressRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateCustomerHandler(_customerRepository, _addressRepository, _mapper);
        }

        [Fact(DisplayName = "When create Customer must return success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = CreateCustomerHandlerTestData.GenerateValidCommand();
            var customer = new Customers
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber,
                Address = new Address
                {
                    Street = command.Address.Street,
                    Number = command.Address.Number,
                    City = command.Address.City,
                    ZipCode = command.Address.ZipCode
                }
            };

            var result = new CreateCustomerCommandResult
            {
                Date = DateTime.UtcNow
            };

            _mapper.Map<Customers>(command).Returns(customer);
            _mapper.Map<CreateCustomerCommandResult>(customer).Returns(result);

            _customerRepository.CreateAsync(Arg.Any<Customers>(), Arg.Any<CancellationToken>())
                .Returns(customer);
            _addressRepository.CreateAsync(Arg.Any<Address>(), Arg.Any<CancellationToken>())
                .Returns(new Address());

            // Act
            var createUserResult = await _handler.Handle(command, CancellationToken.None);

            // Assert
            createUserResult.Should().NotBeNull();
            createUserResult.Date.Should().BeAfter(DateTime.MinValue);
            await _customerRepository.Received(1).CreateAsync(Arg.Any<Customers>(), Arg.Any<CancellationToken>());
            await _addressRepository.Received(1).CreateAsync(Arg.Any<Address>(), Arg.Any<CancellationToken>());
        }


        [Fact(DisplayName = "When an invalid address is provided, address creation should fail gracefully.")]
        public async Task Handle_AddressCreationFails_ThrowsException()
        {
            // Arrange
            var command = CreateCustomerHandlerTestData.GenerateValidCommand();
            var customer = new Customers
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Email = command.Email,
                PhoneNumber = command.PhoneNumber
            };

            _mapper.Map<Customers>(command).Returns(customer);

            // Simulate address creation failure
            _addressRepository.CreateAsync(Arg.Any<Address>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromException<Address>(new Exception("Address creation failed")));

            // Act and Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);
            await act.Should().ThrowAsync<Exception>().WithMessage("Address creation failed");
        }
    }
}
