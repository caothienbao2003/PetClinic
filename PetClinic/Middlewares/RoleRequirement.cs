using Microsoft.AspNetCore.Authorization;

namespace PetClinic.Middlewares
{
    public class RoleRequirement : IAuthorizationRequirement
    {
        public int AllowedRoles { get; }

        public RoleRequirement(int allowedRoles)
        {
            AllowedRoles = allowedRoles;
        }
    }
}
