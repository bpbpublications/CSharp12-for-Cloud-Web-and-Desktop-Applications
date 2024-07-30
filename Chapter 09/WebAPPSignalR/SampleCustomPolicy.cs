using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace WebAPPSignalR
{
    public class SampleCustomPolicy :
    AuthorizationHandler<SampleCustomPolicy, HubInvocationContext>,
    IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SampleCustomPolicy requirement, HubInvocationContext resource)
        {
            if (context.User.Identity != null &&
           !string.IsNullOrEmpty(context.User.Identity.Name) &&
           IsUserAllowedToDoThis(resource.HubMethodName,
                                context.User.Identity.Name))
            {
                context.Succeed(requirement);

            }
            return Task.CompletedTask;
        }
        private bool IsUserAllowedToDoThis(string hubMethodName,
        string currentUsername)
        {
            return !(currentUsername.EndsWith("@gmail.com") &&
                hubMethodName.Equals("SendMessageToCaller", StringComparison.OrdinalIgnoreCase));
        }
    }
}
