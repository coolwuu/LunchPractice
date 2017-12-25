using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LunchSystem.Filter
{
    public class LunchAuthorize : AuthorizeAttribute
    {

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (Convert.ToBoolean(filterContext.HttpContext.Session["auth"]))
            {
                //驗證成功
                //filterContext.Result = new ViewResult() { ViewName = "Backend" };
            }
            else
            {
                HandleUnauthorizedRequest(filterContext);
            }
        }
    }
}