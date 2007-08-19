<%@ Application Language="C#" %>
<%@ Import Namespace="log4net" %>
<%@ Import Namespace="log4net.Config" %>
<script RunAt="server">

	protected static readonly ILog log = LogManager.GetLogger(
		System.Reflection.MethodBase.GetCurrentMethod().DeclaringType
		);

	void Application_Start(Object sender, EventArgs e) {
		XmlConfigurator.Configure();
		log.Debug("Iquomi Web Site startup");
	}

	void Application_End(Object sender, EventArgs e) {
		log.Debug("Iquomi Web Site shutdown");
	}

	void Application_Error(Object sender, EventArgs e) {
		log.Error("Error in application on " + this.Context.Request.Url, this.Context.Error);
    }

	void Session_Start(Object sender, EventArgs e) {

	}

	void Session_End(Object sender, EventArgs e) {
		// Note: The Session_End event is raised only when the sessionstate mode
		// is set to InProc in the Web.config file. If session mode is set to StateServer 
		// or SQLServer, the event is not raised.
	}
    
</script>