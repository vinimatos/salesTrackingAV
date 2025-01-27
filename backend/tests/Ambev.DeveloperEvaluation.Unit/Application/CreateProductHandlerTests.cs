using System;
using System.Threading;
using System.Threading.Tasks;
using Ambev.DeveloperEvaluation.Application.Products;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Products.CreateUser;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class CreateProductHandlerTests
    {
        private readonly IProductRepository _productRepository;
        private readonly IRatingRepository _ratingRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductHandler _handler;

        public CreateProductHandlerTests()
        {
            _productRepository = Substitute.For<IProductRepository>();
            _ratingRepository = Substitute.For<IRatingRepository>();
            _mapper = Substitute.For<IMapper>();
            _handler = new CreateProductHandler(_productRepository, _ratingRepository, _mapper);
        }

        [Fact(DisplayName = "When creating a product with valid input, should return success response")]
        public async Task Handle_ValidRequest_ReturnsSuccessResponse()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                Ratings = new RatingDTO { Rate = 4, Count = 2 }
            };

            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                Count = command.Ratings.Count,
                Rate = command.Ratings.Rate
            };

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                Price = command.Price,
                Rating = rating
            };

            var result = new CreateProductCommandResult
            {
                Data = DateTime.UtcNow
            };

            _mapper.Map<Rating>(command.Ratings).Returns(rating);
            _ratingRepository.CreateAsync(Arg.Any<Rating>(), Arg.Any<CancellationToken>()).Returns(rating);
            _mapper.Map<Product>(command).Returns(product);
            _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>()).Returns(product);
            _mapper.Map<CreateProductCommandResult>(product).Returns(result);

            // Act
            var createProductResult = await _handler.Handle(command, CancellationToken.None);

            // Assert
            createProductResult.Should().NotBeNull();
            await _ratingRepository.Received(1).CreateAsync(Arg.Any<Rating>(), Arg.Any<CancellationToken>());
            await _productRepository.Received(1).CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>());
        }

        [Fact(DisplayName = "When creating a product with invalid input, should throw ValidationException")]
        public async Task Handle_InvalidRequest_ThrowsValidationException()
        {
            // Arrange
            var invalidCommand = new CreateProductCommand
            {
                Title = "",
                Description = "Invalid Product",
                Price = -1, 
                Ratings = null
            };

            var validator = new CreateProductValidator();
            var validationResult = await validator.ValidateAsync(invalidCommand, CancellationToken.None);

            validationResult.IsValid.Should().BeFalse();

            // Act and Assert
            Func<Task> act = async () => await _handler.Handle(invalidCommand, CancellationToken.None);
            await act.Should().ThrowAsync<ValidationException>().WithMessage("Validation failed");
        }

        [Fact(DisplayName = "When creating a product and rating creation fails, should throw Exception")]
        public async Task Handle_RatingCreationFails_ThrowsException()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                Ratings = new RatingDTO{ Count = 4, Rate = 1 }
            };

            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                Count = command.Ratings.Count,
                Rate = command.Ratings.Rate
            };

            _mapper.Map<Rating>(command.Ratings).Returns(rating);

            // Simulate failure during rating creation
            _ratingRepository.CreateAsync(Arg.Any<Rating>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromException<Rating>(new Exception("Rating creation failed")));

            // Act and Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);
            await act.Should().ThrowAsync<Exception>().WithMessage("Rating creation failed");
        }

        [Fact(DisplayName = "When creating a product and product creation fails, should throw Exception")]
        public async Task Handle_ProductCreationFails_ThrowsException()
        {
            // Arrange
            var command = new CreateProductCommand
            {
                Title = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                Ratings = new RatingDTO { Count = 4, Rate =2 }
            };

            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                Count = command.Ratings.Count,
                Rate = command.Ratings.Rate
            };

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Title = command.Title,
                Description = command.Description,
                Price = command.Price,
                Rating = rating
            };

            _mapper.Map<Rating>(command.Ratings).Returns(rating);
            _ratingRepository.CreateAsync(Arg.Any<Rating>(), Arg.Any<CancellationToken>()).Returns(rating);
            _mapper.Map<Product>(command).Returns(product);

            // Simulate failure during product creation
            _productRepository.CreateAsync(Arg.Any<Product>(), Arg.Any<CancellationToken>())
                .Returns(Task.FromException<Product>(new Exception("Product creation failed")));

            // Act and Assert
            Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);
            await act.Should().ThrowAsync<Exception>().WithMessage("Product creation failed");
        }
    }
}
