<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context));
        DevExpress.XtraReports.Web.ReportDesigner.DefaultReportDesignerContainer.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
    }

    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        var context = HttpContext.Current;
        var response = context.Response;

        if (!Request.Url.Host.StartsWith("www") & !Request.Url.IsLoopback & !Request.Url.Host.StartsWith("1"))
        {
			if(!Request.Url.Host.Contains('.local')) 
			{
				UriBuilder builder = new UriBuilder(Request.Url);
				builder.Host = "www." + Request.Url.Host;
				Response.StatusCode = 301;
				Response.AddHeader("Location", builder.ToString());
				Response.End();
			}
			
            if (Request.Url.Scheme == "http")
                Response.Redirect(Request.Url.ToString().Replace("http","https"));
        }
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown 
    }

    void Application_Error(object sender, EventArgs e)
    {

    }

    void Session_Start(object sender, EventArgs e)
    {
        Session.Timeout = 3600;
    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
