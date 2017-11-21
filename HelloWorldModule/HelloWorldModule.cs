using System;
using System.Web;

namespace HelloWorldModule
{
    public class HelloWorldModule : IHttpModule
    {
        public HelloWorldModule()
        {
        }

        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }
            
        // En el método Init registrar los eventos HttpApplication 
        // agregando sus handlers.
        public void Init(HttpApplication application)
        {
            application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            application.EndRequest += (new EventHandler(this.Application_EndRequest));
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            // Objeto HttpContext para acceder a las propiedades request y response
            HttpContext context = ((HttpApplication)source).Context;

            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<h1><font color=red>" +
                    "HelloWorldModule: Beginning of Request" +
                    "</font></h1><hr>");
            }

        }

        private void Application_EndRequest(Object source, EventArgs e)
        {
            // Objeto HttpContext para acceder a las propiedades request y response
            HttpContext context = ((HttpApplication)source).Context;

            string filePath = context.Request.FilePath;
            string fileExtension = VirtualPathUtility.GetExtension(filePath);
            if (fileExtension.Equals(".aspx"))
            {
                context.Response.Write("<hr><h1><font color=red>" +
                    "HelloWorldModule: End of Request</font></h1>");
            }
        }


        public void Dispose() { }
    }
}
