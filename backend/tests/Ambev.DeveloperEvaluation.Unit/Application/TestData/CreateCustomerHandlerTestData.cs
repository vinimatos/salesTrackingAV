using Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public static class CreateCustomerHandlerTestData
    {
        private static readonly Faker<CreateCustomerCommand> createCustomerHandlerFaker = new Faker<CreateCustomerCommand>()
            .RuleFor(u => u.Name, f => f.Person.FullName)
            .RuleFor(u => u.Email, f => f.Internet.Email())
            .RuleFor(u => u.PhoneNumber, f => $"+55{f.Random.Number(11, 99)}{f.Random.Number(100000000, 999999999)}")
            .RuleFor(u => u.Address, f => new DeveloperEvaluation.Application.Customer.Address.AddressDTO
            {
                Street = f.Address.StreetAddress(),
                Number = f.Address.FullAddress(),
                City = f.Address.City(),
                ZipCode = f.Address.CountryCode()
            });



        public static CreateCustomerCommand GenerateValidCommand()
        {
            return createCustomerHandlerFaker.Generate();
        }
    }
}
