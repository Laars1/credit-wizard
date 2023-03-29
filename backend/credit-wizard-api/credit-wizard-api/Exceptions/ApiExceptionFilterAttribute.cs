using credit_wizard_api.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace credit_wizard_api.Exceptions;

public sealed class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

    public ApiExceptionFilterAttribute()
    {
        // Here additional handlers can be defined.
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
        {
            { typeof(EntityNotFoundException), HandleEntityNotFoundException },
            { typeof(EntityAlreadyExistsException), HandleEntityAlreadyExistsException },
        };
    }

    /// <summary>
    /// Runs when an exception in the controller action occured.
    /// </summary>
    /// <param name="context">Context with thrown exception.</param>
    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    /// <summary>
    /// Handles the thrown exception. It either executes the corresponding handler or the handler for unknown exceptions.
    /// </summary>
    /// <param name="context">Context with thrown exception.</param>
    private void HandleException(ExceptionContext context)
    {
        var type = context.Exception.GetType();

        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            context.ExceptionHandled = true;
            return;
        }

        HandleUnknownException(context);
    }

    /// <summary>
    /// Handles all exceptions that were thrown but do not correspond to an registered handler.
    /// Returns an internal server error (500) error response.
    /// </summary>
    /// <param name="context">Context with thrown exception.</param>
    private void HandleUnknownException(ExceptionContext context)
    {
        var statusCode = StatusCodes.Status500InternalServerError;
        
        context.Result = new ObjectResult(new ErrorResultDto()
        {
            ErrorType = "Internal Server Error",
            StatusCode = statusCode,
            Message = context.Exception.Message
        })
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true;
    }

    /// <summary>
    /// Handles the <see cref="EntityNotFoundException"/>.
    /// Returns a not found (404) error response
    /// </summary>
    /// <param name="context">Context with thrown exception.</param>
    private void HandleEntityNotFoundException(ExceptionContext context)
    {
        var exception = context.Exception as EntityNotFoundException;

        context.Result = new NotFoundObjectResult(
            GenerateProblemDetails(
                "Not Found",
                StatusCodes.Status404NotFound,
                exception!));
    }
    
    /// <summary>
    /// Handles the <see cref="EntityAlreadyExistsException"/>.
    /// Returns a bad request (400) error response
    /// </summary>
    /// <param name="context">Context with thrown exception.</param>
    private void HandleEntityAlreadyExistsException(ExceptionContext context)
    {
        var exception = context.Exception as EntityAlreadyExistsException;

        context.Result = new BadRequestObjectResult(
            GenerateProblemDetails(
                "Bad Request",
                StatusCodes.Status400BadRequest,
                exception!));
    }

    /// <summary>
    /// Generates problem details for a specific exception.
    /// </summary>
    /// <param name="statusCode">Status code of response.</param>
    /// <param name="exception">Thrown exception for message and generation of data object.</param>
    /// <returns>ProblemDetails object with all details specified.</returns>
    private ErrorResultDto GenerateProblemDetails(string errorName,int statusCode, Exception exception)
    {
        return new ErrorResultDto()
        {
            ErrorType = errorName,
            StatusCode = statusCode,
            Message = exception.Message,
        };
    }
}