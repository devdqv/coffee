using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_62134455.Controllers
{
    public class Authen_62134455Controller : Controller
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
                filterContext.Result = new RedirectResult("/Login_62134455/FormDangNhap");
            }
            base.OnActionExecuting(filterContext);
        }
    }
}