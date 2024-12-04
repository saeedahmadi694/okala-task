using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace okala_task.Filters;

public class UnhandledExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly ILogger<UnhandledExceptionFilterAttribute> _logger;

    public UnhandledExceptionFilterAttribute(ILogger<UnhandledExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    private static int _exceptionTracker = 1;


    public override async Task OnExceptionAsync(ExceptionContext context)
    {
        var actionDescriptor =
            (Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor;
        Type controllerType = actionDescriptor.ControllerTypeInfo;

        var controllerBase = typeof(ControllerBase);
        var controller = typeof(Controller);

        if (controllerType.IsSubclassOf(controllerBase) && !controllerType.IsSubclassOf(controller))
        {
            IActionResult result;

            string exceptionTracker = DateTime.Today.Day.ToString() + _exceptionTracker;
            _exceptionTracker++;
            _logger.LogError(context.Exception, $"Exception {exceptionTracker}");
            result = new ObjectResult(new ProblemDetails()
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal server error",
                Detail = context.Exception.Message,                
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };


            context.Result = result;
        }
        else if (controllerType.IsSubclassOf(controllerBase) && controllerType.IsSubclassOf(controller))
        {
            // Handle page exception
        }

        await base.OnExceptionAsync(context);
    }

}
