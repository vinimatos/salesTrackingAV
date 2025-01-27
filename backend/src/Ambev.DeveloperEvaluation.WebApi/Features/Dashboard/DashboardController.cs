using Ambev.DeveloperEvaluation.Application.Dashboard;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Dashboard.GetAll;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Dashboard
{
    public class DashboardController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DashboardController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetAllDashboardResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllDashboardCommand(), cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<GetAllDashboardResponse>
            {
                Success = true,
                Data = _mapper.Map<GetAllDashboardResponse>(response)
            });
        }
    }
}
