using Ambev.DeveloperEvaluation.Application.Report;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Report
{
    public class ReportController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ReportController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<ReportResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll([FromBody] ReportRequest request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<ReportCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            var reportlistResponse = new List<Items>();
            foreach(var item in response)
            {
                var newItem = new Items
                {
                    OrderItems = item.OrderItems,
                    Product = item.Product,
                    Quantity = item.Quantity
                };

                reportlistResponse.Add(newItem);
            }

            return Created(string.Empty, new ApiResponseWithData<ReportResponse>
            {
                Success = true,
                Message = "User created successfully",
                Data = new ReportResponse
                {
                    Items = reportlistResponse
                }
            });
        }
    }
}
