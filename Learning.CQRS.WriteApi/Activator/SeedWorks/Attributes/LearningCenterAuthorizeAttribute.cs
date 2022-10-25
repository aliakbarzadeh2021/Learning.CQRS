using System;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Learning.CQRS.WriteApi.Activator.SeedWorks.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class LearningCenterAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return true;
        }
    }
}
