﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace SampleWebAPISignalR
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        readonly string _connString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //Start SqlDependency with application initialization
            SqlDependency.Start(_connString);
        }

        protected void Application_End()
        {
            //Stop SQL dependency
            SqlDependency.Stop(_connString);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            // Preflight request comes with HttpMethod OPTIONS
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                // The following line solves the error message
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
                // If any http headers are shown in preflight error in browser console add them below
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept, Pragma, Cache-Control, Authorization ");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }
    }
}
