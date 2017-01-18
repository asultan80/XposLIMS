namespace Telerik.Reporting.Examples.CSharp
{
    using System.ComponentModel;

    [Description("A collection of Product-related reports")]
    public class ReportBook : Telerik.Reporting.ReportBook
    {
        public ReportBook()
        {
            this.Reports.Add(new SalesByRegionDashboard());
            this.Reports.Add(new Dashboard());
            this.Reports.Add(new ProductSales()); 
            this.Reports.Add(new ProductCatalog());
            this.Reports.Add(new ProductLineSales());

            this.Reports[0].DocumentMapText = "Sales By Region";
            this.Reports[1].DocumentMapText = "Dashboard";
            this.Reports[2].DocumentMapText = "Product Sales";
            this.Reports[4].DocumentMapText = "Product Line Sales";
        }
    }
}