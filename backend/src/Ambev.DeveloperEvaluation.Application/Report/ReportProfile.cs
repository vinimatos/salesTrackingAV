using Ambev.DeveloperEvaluation.Application.Customer.Address;
using Ambev.DeveloperEvaluation.Application.Report;
using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Customer.CreateCustomer
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<Items, ReportCommandResult>();
        }
    }
}
