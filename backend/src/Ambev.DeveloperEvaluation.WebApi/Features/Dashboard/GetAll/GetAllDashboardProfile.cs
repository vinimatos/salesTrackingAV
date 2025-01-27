using Ambev.DeveloperEvaluation.Application.Customer;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Dashboard.GetAll
{
    public class GetAllDashboardProfile : Profile
    {
        public GetAllDashboardProfile()
        {
            CreateMap<GetAllDashboardCommandResult, GetAllDashboardResponse>();
        }
    }
}
