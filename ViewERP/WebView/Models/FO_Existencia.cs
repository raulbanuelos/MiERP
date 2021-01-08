using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebView.Models
{
    public class FO_Existencia
    {
        #region Constructor
        public FO_Existencia()
        {
            Existencias = new List<DO_Existencia>();
            Almacen = new DO_Almacen();
        } 
        #endregion

        #region Properties
        public List<DO_Existencia> Existencias { get; set; }

        public DO_Almacen Almacen { get; set; } 
        #endregion
    }
}