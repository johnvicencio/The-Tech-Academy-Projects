using System.Web;
using System.Web.Mvc;

namespace AgencyAddressBook.App_Start
{
    public class GlobalApplicationActionFilter : ActionFilterAttribute

    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Name of application
            filterContext.Controller.ViewBag.ApplicationName = "Agency Address Book";

            // Search

            filterContext.Controller.ViewBag.SearchCount = null;


            // shows the path based on URL
            filterContext.Controller.ViewBag.ControllerName = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower();

            string secondController = HttpContext.Current.Request.RequestContext.RouteData.Values["controller"].ToString().ToLower();
            filterContext.Controller.ViewBag.ActionMethod = HttpContext.Current.Request.RequestContext.RouteData.Values["action"].ToString().ToLower();

            switch (secondController)
            {
                case "broker":
                    filterContext.Controller.ViewBag.SecondControllerName = "client";
                    break;
                case "client":
                    filterContext.Controller.ViewBag.SecondControllerName = "proposal";
                    break;
                default:
                    filterContext.Controller.ViewBag.SecondControllerName = "";
                    filterContext.Controller.ViewBag.ThirdControllerName = "";
                    break;
            }
        }
    }
}