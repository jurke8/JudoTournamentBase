using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace JudoTournamentBase
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                //Create culture info object 
                CultureInfo cultureInfo = (CultureInfo)this.Session["Culture"];

                //Checking first if there is no value in session 
                //and set default language 
                //this can happen for first user's request
                if (cultureInfo == null)
                {
                    //Sets default culture to english invariant
                    string langName = "en-US";

                    //Try to get values from Accept lang HTTP header
                    if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                    {
                        //Gets accepted list 
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);

                    }
                    if (langName != "en-US")
                    {
                        cultureInfo = new CultureInfo("en-US");

                        this.Session["Culture"] = cultureInfo;
                    }
                    else
                    {
                        cultureInfo = new CultureInfo(langName);
                        this.Session["Culture"] = cultureInfo;
                    }
                }

                //Finally setting culture for each request
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(new CultureInfo("hr").Name);

            }
        }

    }
}
