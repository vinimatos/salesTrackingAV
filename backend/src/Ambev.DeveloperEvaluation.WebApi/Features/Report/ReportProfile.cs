using Ambev.DeveloperEvaluation.Application.Report;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Report
{
    public class ReportProfile : Profile
    {
        public ReportProfile()
        {
            CreateMap<ReportCommandResult, ReportResponse>();
            CreateMap<ReportRequest, ReportCommand>();
        }
    }
}

