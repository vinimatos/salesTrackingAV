using Ambev.DeveloperEvaluation.Application.Order.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Order.Create;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct
{
    public class UpdateOrderProfile : Profile
    {
        public UpdateOrderProfile()
        {
            CreateMap<UpdateOrderRequest,UpdateOrderCommand>();
            CreateMap<UpdateOrderCommandResult, UpdateOrderResponse>();
        }
    }
}
