using System;
using UIKit;
using Syncfusion.SfChart.iOS;
using Foundation;
using System.Collections.ObjectModel;

namespace SFChart_iOS_GettingStarted
{
    public partial class ViewController : UIViewController
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            //Initialize the Chart with required frame. This frame can be any rectangle, which bounds inside the view.
            SFChart chart = new SFChart();
            chart.Title.Text = "Chart";
            chart.Frame = this.View.Frame;

            //Adding Primary Axis for the Chart.
            SFCategoryAxis primaryAxis = new SFCategoryAxis();
            primaryAxis.Title.Text = new NSString("Name");
            chart.PrimaryAxis = primaryAxis;

            //Adding Secondary Axis for the Chart.
            SFNumericalAxis secondaryAxis = new SFNumericalAxis();
            secondaryAxis.Title.Text = new NSString("Height (in cm)");
            chart.SecondaryAxis = secondaryAxis;

            ObservableCollection<ChartData> Data = new ObservableCollection<ChartData>()
            {
                new ChartData { Name = "David", Height = 180 },
                new ChartData { Name = "Michael", Height = 170 },
                new ChartData { Name = "Steve", Height = 160 },
                new ChartData { Name = "Joel", Height = 182 }
            };

            //Initializing column series
            SFColumnSeries series = new SFColumnSeries();
            series.ItemsSource = Data;
            series.XBindingPath = "Name";
            series.YBindingPath = "Height";

            series.DataMarker.ShowLabel = true;
            series.Label = "Heights";
            series.EnableTooltip = true;

            chart.Series.Add(series);
            chart.Legend.Visible = true;
            this.View.AddSubview(chart);
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}