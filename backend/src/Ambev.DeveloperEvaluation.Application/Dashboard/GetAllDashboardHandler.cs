using Ambev.DeveloperEvaluation.Application.Dashboard;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Customer
{
    public class GetAllDashboardHandler : IRequestHandler<GetAllDashboardCommand, GetAllDashboardCommandResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;

        public GetAllDashboardHandler(ICustomerRepository customerRepository, IProductRepository productRepository, ICartRepository cartRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        public async Task<GetAllDashboardCommandResult> Handle(GetAllDashboardCommand command, CancellationToken cancellationToken)
        {
            var customerList = await _customerRepository.GetAllAsync(cancellationToken);
            var productList = await _productRepository.GetAllAsync(cancellationToken);
            var cartList = await _cartRepository.GetAllAsync(cancellationToken);

            return new GetAllDashboardCommandResult
            {
                Customers = customerList.Count,
                Orders = cartList.Count,
                Products = productList.Count
            };
        }
    }
}
