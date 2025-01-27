using Ambev.DeveloperEvaluation.Application.Customer;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Dashboard
{
    public class GetAllOrderCommand : IRequest<GetAllOrderCommandResult>
    {
    }
}
