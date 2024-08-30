using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Main.Application.Common.Constants;
using SharedKernel.Main.Contracts.Common;

namespace SharedKernel.Main.Application.Common;

[ApiController]
[Route("api/[controller]")]
public partial class ApiControllerBase : ControllerBase
{
    private IMapper _mapper;
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>()!;
    protected IMapper Mapper => _mapper ??= HttpContext.RequestServices.GetService<IMapper>()!;

    
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

    private ActionResult ValidationProblem(List<Error> errors)
    {
        //var modelStateDictionary = new ModelStateDictionary();

        //errors.ForEach(error => modelStateDictionary.AddModelError(error.Code, error.Description));
        
        var errorEntities = new List<StatusEntityModel>();
        
        foreach (Error error in errors)
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


    

    private object ToResponse(StatusEntityModel status, object data = null)
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