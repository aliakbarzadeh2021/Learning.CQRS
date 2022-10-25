using System;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Learning.CQRS.WriteApi.Activator.SeedWorks.Attributes
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    public class PrivilegeBehaviorAttribute : AuthorizeAttribute
    {
        //private readonly IUserQueryService _userQueryService;
        public PrivilegeBehaviorAttribute()
        {
            //_userQueryService = Bootstrapper.Container.Resolve<IUserQueryService>();
        }

        public int Order { get; set; }

        public string Action { get; set; }

        public string Title { get; set; }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.RequestContext.Principal != null)
            {
                return true;
            }
            return false;
     
        }
    }
}
