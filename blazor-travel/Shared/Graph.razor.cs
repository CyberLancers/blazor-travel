using Business.Services;
using ChartJs.Blazor.Common;
using ChartJs.Blazor.Common.Axes;
using ChartJs.Blazor.Common.Axes.Ticks;
using ChartJs.Blazor.Common.Enums;
using ChartJs.Blazor.Common.Time;
using ChartJs.Blazor.LineChart;
using ChartJs.Blazor.Util;
using Microsoft.AspNetCore.Components;

namespace blazor_travel.Shared;

public partial class Graph
{
    [Inject]
    protected ICruiseService CruiseService { get; set; }
    
    [Parameter]
    public int ItineraryId { get; set; }
    
    protected LineConfig _lineConfig { get; set; }
    
    private ChartJs.Blazor.Chart _chart;
    
    private LineDataset<TimePoint> _InsideDataSet;
    private LineDataset<TimePoint> _OutsideDataSet;
    private LineDataset<TimePoint> _BalconyDataSet;
    private LineDataset<TimePoint> _SuiteDataSet;
    
    protected override async Task OnInitializedAsync()
    {
        var timeMeasurement = new Dictionary<TimeMeasurement, string>();
        timeMeasurement.Add(TimeMeasurement.Day, "Day");
        
        _lineConfig = new LineConfig
        {
            Options = new LineOptions
            {
                Responsive = true,
                Title = new OptionsTitle
                {
                    Display = false
                },
                Legend = new Legend
                {
                    Display = true
                },
                Tooltips = new Tooltips
                {
                    Mode = InteractionMode.Nearest,
                    Intersect = false
                },
                Hover = new Hover()
                {
                    Intersect = true,
                    Mode = InteractionMode.Nearest
                },
                Scales = new Scales
                {
                    YAxes = new List<CartesianAxis>
                    {
                        new LinearCartesianAxis()
                        {
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Amount",
                            }
                        }
                    },
                    XAxes = new List<CartesianAxis>
                    {
                        new TimeAxis
                        {
                            Time = new TimeOptions
                            {
                                TooltipFormat = "MM.DD.YYYY"
                            },
                            ScaleLabel = new ScaleLabel
                            {
                                LabelString = "Date"
                            }
                        }
                    }
                }
            }
        };
        
        _InsideDataSet = new LineDataset<TimePoint>
        {
            BackgroundColor = ColorUtil.FromDrawingColor(System.Drawing.Color.White),
            BorderColor = ColorUtil.FromDrawingColor(System.Drawing.Color.Red),
            Label = "Weight per Day",
            Fill = FillingMode.Disabled
        };
        
        _OutsideDataSet = new LineDataset<TimePoint>
        {
            BackgroundColor = ColorUtil.FromDrawingColor(System.Drawing.Color.White),
            BorderColor = ColorUtil.FromDrawingColor(System.Drawing.Color.Green),
            Label = "Weight per Day",
            Fill = FillingMode.Disabled
        };
        
        _BalconyDataSet = new LineDataset<TimePoint>
        {
            BackgroundColor = ColorUtil.FromDrawingColor(System.Drawing.Color.White),
            BorderColor = ColorUtil.FromDrawingColor(System.Drawing.Color.Blue),
            Label = "Weight per Day",
            Fill = FillingMode.Disabled
        };
        
        _SuiteDataSet = new LineDataset<TimePoint>
        {
            BackgroundColor = ColorUtil.FromDrawingColor(System.Drawing.Color.White),
            BorderColor = ColorUtil.FromDrawingColor(System.Drawing.Color.Violet),
            Label = "Weight per Day",
            Fill = FillingMode.Disabled
        };

        var rates = await CruiseService.GetRates(ItineraryId, 1);
        _InsideDataSet.AddRange(rates
            .Select(p => new TimePoint(p.DateChecked, (double)p.Amount)));
        _lineConfig.Data.Datasets.Add(_InsideDataSet);
        
        rates = await CruiseService.GetRates(ItineraryId, 2);
        _OutsideDataSet.AddRange(rates
            .Select(p => new TimePoint(p.DateChecked, (double)p.Amount)));
        _lineConfig.Data.Datasets.Add(_OutsideDataSet);
        
        rates = await CruiseService.GetRates(ItineraryId, 3);
        _BalconyDataSet.AddRange(rates
            .Select(p => new TimePoint(p.DateChecked, (double)p.Amount)));
        _lineConfig.Data.Datasets.Add(_BalconyDataSet);
        
        rates = await CruiseService.GetRates(ItineraryId, 4);
        _SuiteDataSet.AddRange(rates
            .Select(p => new TimePoint(p.DateChecked, (double)p.Amount)));
        _lineConfig.Data.Datasets.Add(_SuiteDataSet);
        //await _lineChartJs.Update();
    }
}