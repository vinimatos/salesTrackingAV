using Ambev.DeveloperEvaluation.Application.Customer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Dashboard.GetAll
{
    public class GetAllOrderProfile : Profile
    {
        public GetAllOrderProfile()
        {
            CreateMap<GetAllOrderCommandResult, GetAllOrderResponse>();
        }
    }
}
