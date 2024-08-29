using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Main.Application.Common;

[ApiController]
[Route("api/[controller]")]
public class ApiControllerBase : ControllerBase
{
    public class CustomErrorResponse
    {
        public List<CustomError> Errors { get; set; }
    }

    public class CustomError
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
    
    protected ActionResult Problem(List<Error> errors)
    {
        if (errors.Count is 0)
        {
            return Problem();
        }

        if (errors.All(error => error.Type == ErrorType.Validation))
        {
            return ValidationProblem(errors);
        }
        
        
        return Problem(errors[0]);
    }

    private ObjectResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };
        
        
        var customErrors = new List<CustomError>();
        
        customErrors.Add(new CustomError(){Code = error.Code, Message = error.Description});
        
        
        var errorResponse = new CustomErrorResponse
        {
            Errors  = customErrors
        };

        return new ObjectResult(errorResponse)
        {
            StatusCode = statusCode
        };

        //return Problem(statusCode: statusCode, title: error.Description);
    }

    private ActionResult ValidationProblem(List<Error> errors)
    {
        //var modelStateDictionary = new ModelStateDictionary();

        //errors.ForEach(error => modelStateDictionary.AddModelError(error.Code, error.Description));
        
        var customErrors = new List<CustomError>();
        foreach (Error error in errors)
        {
            customErrors.Add(new CustomError(){Code = error.Code, Message = error.Description});
        }
        
        var errorResponse = new CustomErrorResponse
        {
            Errors  = customErrors
        };

        return new ObjectResult(errorResponse)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };

        //return ValidationProblem(modelStateDictionary);
    }
    

}