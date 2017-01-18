namespace Telerik.Reporting.Examples.CSharp.Choropleth
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PopulationDensity.
    /// </summary>
    [Description("A choropleth map, showing the population density in the 100 most populated countries.")]
    public partial class PopulationDensity : Telerik.Reporting.Report
    {
        public PopulationDensity()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}