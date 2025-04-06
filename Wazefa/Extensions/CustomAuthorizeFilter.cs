using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Extensions
{
    public class RoleAuthorizationRequirement(string role) : IAuthorizationRequirement
    {
        public string Role { get; } = role;
    }

    public class CustomAuthorizationHandler
        : AuthorizationHandler<RoleAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            RoleAuthorizationRequirement requirement)
        {
            if (context.User.Identity?.IsAuthenticated == true
                && context.User.IsInRole(requirement.Role))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
