<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>"%>
<%@ Import Namespace="Telerik.Reporting.Examples.CSharp" %>

<%@ Register Assembly="Telerik.Reporting, Version=10.2.16.1025, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.Reporting" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.ReportViewer.WebForms, Version=10.2.16.1025, Culture=neutral, PublicKeyToken=a9d7983dfcc261be" Namespace="Telerik.ReportViewer.WebForms" TagPrefix="telerik" %>
<!DOCTYPE html>

<html>
<head runat="server">
    <meta name="viewport" content="width=device.width"/>
    <title>Dashboard</title>
</head>
<body>
    <script runat="server">
       public override void VerifyRenderingInServerForm(Control control)
        {
        
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var instanceReportSource = new InstanceReportSource {ReportDocument = new Dashboard()};
            ReportViewer1.ReportSource = instanceReportSource;
        }
    </script>

    <form id="main"  method="post" action="">
        <telerik:ReportViewer ID="ReportViewer1" Width="100%" Height="300px" runat="server"></telerik:ReportViewer>
    </form>
</body>
</html>
