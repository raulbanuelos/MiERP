using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class DO_OrganizationChart
    {
        #region Constructor
        public DO_OrganizationChart()
        {
            Yo = new DO_Persona();
            Promotores = new List<DO_Persona>();
        }
        #endregion

        #region Properties
        public DO_Persona Yo { get; set; }

        public List<DO_Persona> Promotores { get; set; }
        #endregion
    }
}