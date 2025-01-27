using Ambev.DeveloperEvaluation.Application.Customer.UpdateCustomer;
using Ambev.DeveloperEvaluation.Application.Dashboard;
using Ambev.DeveloperEvaluation.Application.Order.CreateOrder;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Customer.UpdateCustomer;
using Ambev.DeveloperEvaluation.WebApi.Features.Dashboard.GetAll;
using Ambev.DeveloperEvaluation.WebApi.Features.Order.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products
{
    public class OrderController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(typeof(ApiResponseWithData<GetAllOrderResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(new GetAllOrderCommand(), cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<GetAllOrderResponse>
            {
                Success = true,
                Data = _mapper.Map<GetAllOrderResponse>(response)
            });
        }


        [HttpPost("add")]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateOrderResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateOrderCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateOrderResponse>
            {
                Success = true,
                Message = "Order created successfully",
                Data = _mapper.Map<CreateOrderResponse>(response)
            });
        }


        [HttpPut("update/{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<UpdateOrderResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrder([FromRoute] Guid id, [FromBody] UpdateOrderRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateOrderCommand>(request);
            command.Id = id;
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<UpdateOrderResponse>
            {
                Success = true,
                Message = "User created successfully",
                Data = _mapper.Map<UpdateOrderResponse>(response)
            });
        }
    }
}
