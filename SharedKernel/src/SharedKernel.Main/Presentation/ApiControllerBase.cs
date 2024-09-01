using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedKernel.Main.Application.Interfaces.Services;
using SharedKernel.Main.Contracts;

namespace SharedKernel.Main.Presentation;

[ApiController]
[Route("api/[controller]")]
public partial class ApiControllerBase : ControllerBase
{
    private IMapper _mapper;
    private ISender? _mediator;
    protected readonly ILogger<ApiControllerBase> _logger;
    protected readonly ICurrentUser CurrentUser;
    
    
    public ApiControllerBase(ILogger<ApiControllerBase> logger , ICurrentUser currentUser)
    {
        _logger = logger;
        CurrentUser = currentUser;
    }
    
    public ApiControllerBase()
    {
    }



    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>()!;

    
    protected ActionResult Problem(List<ErrorOr.Error> errors)
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

    private ObjectResult Problem(ErrorOr.Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Unauthorized => StatusCodes.Status403Forbidden,
            _ => StatusCodes.Status500InternalServerError,
        };

        var errorEntity = new StatusEntityModel() { Code = error.Code, Message = error.Description };
        /*var customErrors = new List<StatusEntityModel>();
        
        customErrors.Add(errorEntity);
        
        
        var errorResponse = new ErrorModel
        {
            Errors  = customErrors
        };*/

        var result = ToResponse(errorEntity);

        return new ObjectResult(result)
        {
            StatusCode = statusCode
        };

        //return Problem(statusCode: statusCode, title: error.Description);
    }

    private ActionResult ValidationProblem(List<ErrorOr.Error> errors)
    {
        //var modelStateDictionary = new ModelStateDictionary();

        //errors.ForEach(error => modelStateDictionary.AddModelError(error.Code, error.Description));
        
        var errorEntities = new List<StatusEntityModel>();
        
        foreach (ErrorOr.Error error in errors)
        {
            errorEntities.Add(new StatusEntityModel(){Code = error.Code, Message = error.Description});
        }
        
        /*var errorResponse = new ErrorModel
        {
            Status = new StatusEntityModel(){Code = ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString(), Message = "Basic validation error"},
            Errors  = errorEntities,
            Data = new object()
        };*/
        
        var errorResponse = new StatusModel()
        {
            Status = new StatusEntityModel(){Code = ApplicationStatusCodes.API_ERROR_BASIC_VALIDATION_FAILED.ToString(), Message = errorEntities.First().Message},
            Data = new object()
        };

        return new ObjectResult(errorResponse)
        {
            StatusCode = StatusCodes.Status400BadRequest
        };

        //return ValidationProblem(modelStateDictionary);
    }
    

    protected object ToSuccess(object data)
    {
        var status = new StatusEntityModel(){Code = ApplicationStatusCodes.API_SUCCESS.ToString(), Message = "Success"};

        return ToResponse(status, data);
        
    }


    

    private object ToResponse(StatusEntityModel status, object? data = null)
    {
        if (data is null)
        {
            data = new object();
        }
        var response = new StatusModel()
        {
            Status = status,
            Data = data
        };

        return response;
    }
    

}