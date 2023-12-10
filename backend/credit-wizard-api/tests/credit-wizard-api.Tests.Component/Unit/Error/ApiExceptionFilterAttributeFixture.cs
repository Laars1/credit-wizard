using credit_wizard_api.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace credit_wizard_api.Tests.Component.Unit.Error
{
    public class ApiExceptionFilterAttributeFixture
    {
        private readonly ApiExceptionFilterAttribute _apiExceptionFilterAttribute;

        public ApiExceptionFilterAttributeFixture()
        {
            _apiExceptionFilterAttribute = new ApiExceptionFilterAttribute();
        }

        [Fact]
        public void OnHandle_ShouldHandleEntityNotFoundException_AndSetResult()
        {
            // Arrange
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContextMock = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new EntityNotFoundException()
            };

            // Act
            _apiExceptionFilterAttribute.OnException(exceptionContextMock);

            // Assert
            exceptionContextMock.ExceptionHandled.Should().BeTrue();
            exceptionContextMock.Result.Should().NotBeNull();
            exceptionContextMock.Result.Should().BeAssignableTo<NotFoundObjectResult>();
        }

        [Fact]
        public void OnHandle_ShouldHandleEntityAlreadyExistsException_AndSetResultToBadRequest()
        {
            // Arrange
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContextMock = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new EntityAlreadyExistsException()
            };

            // Act
            _apiExceptionFilterAttribute.OnException(exceptionContextMock);

            // Assert
            exceptionContextMock.ExceptionHandled.Should().BeTrue();
            exceptionContextMock.Result.Should().NotBeNull();
            exceptionContextMock.Result.Should().BeAssignableTo<BadRequestObjectResult>();
            var objectResult = exceptionContextMock.Result as BadRequestObjectResult;
            objectResult!.StatusCode.Should().Be(400);
        }

        [Fact]
        public void OnHandle_ShouldHandleReferenceAlredyExistsException_AndSetResultToConflict()
        {
            // Arrange
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContextMock = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new ReferenceAlreadyExistsException()
            };

            // Act
            _apiExceptionFilterAttribute.OnException(exceptionContextMock);

            // Assert
            exceptionContextMock.ExceptionHandled.Should().BeTrue();
            exceptionContextMock.Result.Should().NotBeNull();
            exceptionContextMock.Result.Should().BeAssignableTo<ConflictObjectResult>();
            var objectResult = exceptionContextMock.Result as ConflictObjectResult;
            objectResult!.StatusCode.Should().Be(409);
        }

        [Fact]
        public void OnHandle_ShouldHandleReferenceNotExistsException_AndSetResultToNotFound()
        {
            // Arrange
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContextMock = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new ReferenceNotExistsException("", "", "")
            };

            // Act
            _apiExceptionFilterAttribute.OnException(exceptionContextMock);

            // Assert
            exceptionContextMock.ExceptionHandled.Should().BeTrue();
            exceptionContextMock.Result.Should().NotBeNull();
            exceptionContextMock.Result.Should().BeAssignableTo<NotFoundObjectResult>();
            var objectResult = exceptionContextMock.Result as NotFoundObjectResult;
            objectResult!.StatusCode.Should().Be(404);
        }

        [Fact]
        public void OnHandle_ShouldHandleEntityAlreadyCompletedException_AndSetResultToBadRequest()
        {
            // Arrange
            var actionContext = new ActionContext
            {
                HttpContext = new DefaultHttpContext(),
                RouteData = new RouteData(),
                ActionDescriptor = new ActionDescriptor()
            };
            var exceptionContextMock = new ExceptionContext(actionContext, new List<IFilterMetadata>())
            {
                Exception = new EntityAlreadyCompletedException("", "")
            };

            // Act
            _apiExceptionFilterAttribute.OnException(exceptionContextMock);

            // Assert
            exceptionContextMock.ExceptionHandled.Should().BeTrue();
            exceptionContextMock.Result.Should().NotBeNull();
            exceptionContextMock.Result.Should().BeAssignableTo<BadRequestObjectResult>();
            var objectResult = exceptionContextMock.Result as BadRequestObjectResult;
            objectResult!.StatusCode.Should().Be(400);
        }
    }
}
