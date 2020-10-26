using Microsoft.ApplicationInsights.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_Semana
    {
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public int NoSemana { get; set; }
        public int Year { get; set; }
        public string SFechaInicial { get; set; }
        public string SFechaFinal { get; set; }
    }
}