using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace PetClinic.Middlewares
{
    public class RoleAuthorizationHandler : AuthorizationHandler<RoleRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleRequirement requirement)
        {
            var userRole = context.User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => int.Parse(c.Value))
                .ToArray();

            if (userRole.Contains(requirement.AllowedRoles))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
