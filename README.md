# Xamarin.iOS-Chart-Getting-Started
This is the demo application of Xamarin.iOS SfChart control. The minimal set of required properties have been configured in this project to get started with SfChart in Xamarin.iOS platform.

## <a name="description"></a>Description ##

## Initialize chart

Add reference to [Syncfusion.Xamarin.SfChart.IOS](https://www.nuget.org/packages/Syncfusion.Xamarin.SfChart.ios/#) NuGet and import the control namespace `Syncfusion.SfChart.iOS` as shown below in your respective Page.

```C#
using Syncfusion.SfChart.iOS;
```

Then initialize an empty chart with [`PrimaryAxis`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.ChartBase.html#Syncfusion_SfChart_iOS_ChartBase_PrimaryAxis) and [`SecondaryAxis`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.ChartBase.html#Syncfusion_SfChart_iOS_ChartBase_SecondaryAxis) as shown below,

###### C#
```C#
public override void ViewDidLoad ()
{
    base.ViewDidLoad ();

    //Initialize the Chart with required frame. This frame can be any rectangle, which bounds inside the view.
    SFChart chart = new SFChart ();
    chart.Frame   = this.View.Frame;

    //Adding Primary Axis for the Chart.
    SFCategoryAxis primaryAxis = new SFCategoryAxis ();
    chart.PrimaryAxis          = primaryAxis;

    //Adding Secondary Axis for the Chart.
    SFNumericalAxis secondaryAxis = new SFNumericalAxis ();
    chart.SecondaryAxis           = secondaryAxis; 

    this.View.AddSubview (chart);
}
```

## Populate chart with data

To visualize the comparison of person heights in chart data, create an instance of [`SFColumnSeries`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFColumnSeries.html), add it to the [`Series`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.ChartBase.html#Syncfusion_SfChart_iOS_ChartBase_Series) collection property of [`SFChart`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html), and then set actual `Data` collection to the [`ItemsSource`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html#Syncfusion_SfChart_iOS_SFSeries_ItemsSource) property of [`SFSeries`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html) as demonstrated in the following code snippet..

> You need to get the `Name` and `Height` values in `Data` collection to [`SFColumnSeries`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFColumnSeries.html) by setting [`XBindingPath`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html#Syncfusion_SfChart_iOS_SFSeries_XBindingPath) and [`YBindingPath`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFXyDataSeries.html#Syncfusion_SfChart_iOS_SFXyDataSeries_YBindingPath) with respective field names to plot the series.

###### C#
```C#
//Initializing primary axis
SFCategoryAxis primaryAxis = new SFCategoryAxis();

primaryAxis.Title.Text = new NSString("Name");

chart.PrimaryAxis = primaryAxis;

//Initializing secondary Axis
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

chart.Series.Add(series);
```

```C#
public class ChartData   
{   
    public string Name { get; set; }

    public double Height { get; set; }
}
```

## Add Title

You can add title to chart to provide quick information to the user about the data being plotted in the chart. You can set title using [`SFChart.Title`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.ChartBase.html#Syncfusion_SfChart_iOS_ChartBase_Title) property as shown below.

###### C#
```C#
chart.Title.Text = "Chart";
```

Refer this [link](https://help.syncfusion.com/xamarin-ios/sfchart/chart-title) to learn more about the options available in [`SfChart`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html) to customize chart title.

## Enable data labels

You can add data labels to improve the readability of the chart. This can be achieved using [`SFSeries.DataMarker`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html#Syncfusion_SfChart_iOS_SFSeries_DataMarker) property as shown below.

###### C#
```C#
series.DataMarker.ShowLabel = true;
```

Refer this [link](https://help.syncfusion.com/xamarin-ios/sfchart/data-marker) to learn more about the options available in [`SfChart`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html) to customize data markers.

## Enable legend

You can enable legend using [`SFChart.Legend`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html#Syncfusion_SfChart_iOS_SFChart_Legend) property as shown below,

###### C#
```C#
chart.Legend.Visible = true;
```

Additionally, you need to set label for each series using [`SFSeries.Label`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html#Syncfusion_SfChart_iOS_SFSeries_Label) property, which will be displayed in corresponding legend.

###### C#
```C#
series.Label = "Heights";
```

Refer this [link](https://help.syncfusion.com/xamarin-ios/sfchart/legend) to learn more about the options available in [`SfChart`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html) to customize legend.

## Enable tooltip

Tooltips are used to show information about the segment, when you tap on the segment. You can enable tooltip by setting [`SFSeries.EnableTooltip`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFSeries.html#Syncfusion_SfChart_iOS_SFSeries_EnableTooltip) property to true.

###### C#
```C#
series.EnableTooltip = true;
```

Refer this [link](https://help.syncfusion.com/xamarin-ios/sfchart/tooltip) to learn more about the options available in [`SfChart`](https://help.syncfusion.com/cr/xamarin-ios/Syncfusion.SfChart.iOS.SFChart.html) to customize tooltip.

The following code example gives you the complete code of above configurations.

###### C#
```C#
using Syncfusion.SfChart.iOS;

namespace Chart_GettingStarted
{
    public partial class ViewController : UIViewController
    {
	public override void ViewDidLoad()
	{
	    base.ViewDidLoad()    
	    //Initialize the Chart with required frame. This frame can be any rectangle, which bounds inside the view.
	    SFChart chart = new SFChart();
	    chart.Title.Text = "Chart";
	    chart.Frame = this.View.Frame;
              
	    //Adding Primary Axis for the Chart.
	    SFCategoryAxis primaryAxis = new SFCategoryAxis();
	    primaryAxis.Title.Text = new NSString("Name");
	    chart.PrimaryAxis = primaryAxis
	    
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
    }
}
```

## <a name="output"></a>Output ##
![Xamarin.iOS SFChart Getting_Started image]()

For more details please refer this UG [Xamarin.iOS SFChart](https://help.syncfusion.com/xamarin-ios/sfchart/getting-started).
