using Ambev.DeveloperEvaluation.Application.Order.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Order.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class CreateOrderProfile : Profile
    {
        public CreateOrderProfile()
        {
            CreateMap<CreateOrderRequest, CreateOrderCommand>();
            CreateMap<CreateOrderCommandResult, CreateOrderResponse>();
        }
    }
}
