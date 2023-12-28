using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee.Controllers
{
    public class AuthenController : Controller
    {
        // GET: Base
        public class NotAuthorizeAttribute : FilterAttribute
        {
            // Does nothing, just used for decoration
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            object[] attributes = filterContext.ActionDescriptor.GetCustomAttributes(true);
            if (attributes.Any(a => a is NotAuthorizeAttribute)) return;
            if (Session["user"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/FormDangNhap");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}