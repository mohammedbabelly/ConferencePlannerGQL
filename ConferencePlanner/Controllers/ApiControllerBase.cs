using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ConferencePlanner.Controllers {
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
