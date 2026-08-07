using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Filters
{
    //Prevent account if his roles has updated but his token is still valid (not expired yet) based on specific role (User role)
    //Then AuthenticationFilter prevent the account without needing to refresh the token
    public class AuthenticationFilter : IAsyncActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public AuthenticationFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated == true)
            {
                var user = await _currentUserService.GetCurrentUser();
                var userRoles = await _currentUserService.GetCurrentUserRoles(user);
                if (userRoles.FirstOrDefault(x => x == "User") == null)
                {
                    context.Result = new ObjectResult("Forbidden") { StatusCode = StatusCodes.Status403Forbidden };
                }
                else
                {
                    await next();
                }
            }
            else
            {
                context.Result = new ObjectResult("Unauthorized") { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
