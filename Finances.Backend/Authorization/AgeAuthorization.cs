using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Finances.Backend.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinAge requirement)
        {
            var birthClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if(birthClaim is null)
                return Task.CompletedTask;

            var birth = Convert.ToDateTime(birthClaim.Value);
            var today = DateTime.Today;
            var age = today.Year - birth.Year;
            if (today.DayOfYear < birth.DayOfYear)
                age--;

            if (age >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
