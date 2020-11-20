using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_ChartData
    {
        public List<string> labels { get; set; }
        public List<DataSetChart> datasets { get; set; }
    }

    public class DataSetChart
    {
        public string label { get; set; }
        public string backgroundColor { get; set; }
        public string borderColor { get; set; }
        public int borderWidth { get; set; }
        public List<double> data { get; set; }

    }
}