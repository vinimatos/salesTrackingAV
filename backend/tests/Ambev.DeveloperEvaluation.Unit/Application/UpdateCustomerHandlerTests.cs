using Ambev.DeveloperEvaluation.Application.Customer.Address;
using Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class UpdateCustomerHandlerTests
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly UpdateCustomerHandler _handler;

        public UpdateCustomerHandlerTests()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _addressRepository = Substitute.For<IAddressRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new UpdateCustomerHandler(_customerRepository, _addressRepository, _mapper);
        }

        [Fact(DisplayName = "When update Customer is successful, should return success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new UpdateCustomerCommand
            {
                Id = Guid.NewGuid(),
                Name = "Updated Customer Name",
                Email = "updated@example.com",
                PhoneNumber = "+5511123456789",
                Address = new AddressDTO
                {
                    Street = "Updated Street",
                    Number = "123",
                    City = "Updated City",
                    ZipCode = "00000-000"
                }
            };

            var customer = new Customers
            {
                Id = command.Id,
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

            var result = new UpdateCustomerCommandResult
            {
                Date = DateTime.UtcNow
            };

            _mapper.Map<Customers>(command).Returns(customer);
            _mapper.Map<UpdateCustomerCommandResult>(customer).Returns(result);

            _customerRepository.UpdateAsync(Arg.Any<Customers>(), Arg.Any<CancellationToken>())
                .Returns(customer);

            // Act
            var updateCustomerResult = await _handler.Handle(command, CancellationToken.None);

            // Assert
            updateCustomerResult.Should().NotBeNull();
            updateCustomerResult.Date.Should().BeAfter(DateTime.MinValue);
            await _customerRepository.Received(1).UpdateAsync(Arg.Any<Customers>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "When customer update fails, should throw exception")]
        public async Task Handle_CustomerUpdateFails_ThrowsException()
        {
            // Arrange
            var command = new UpdateCustomerCommand
            {
                Id = Guid.NewGuid(),
                Name = "Updated Customer Name",
                Email = "updated@example.com",
                PhoneNumber = "+5511123456789",
                Address = new AddressDTO
                {
                    Street = "Updated Street",
                    Number = "123",
                    City = "Updated City",
                    ZipCode = "00000-000"
                }
            };

            var customer = new Customers
            {
                Id = command.Id,
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

            _mapper.Map<Customers>(command).Returns(customer);

            _customerRepository.UpdateAsync(Arg.Any<Customers>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromException<Customers>(new Exception("Customer update failed")));

            // Act and Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);
            await act.Should().ThrowAsync<Exception>().WithMessage("Customer update failed");
        }
    }
}
