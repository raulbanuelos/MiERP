using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DO_C_Orcen
    {
        public string Proyecto { get; set; }
        public string PlantaDestino { get; set; }
        public string EquipoRequerido { get; set; }
        public string EnviarA { get; set; }
        public int  CantidadTotal { get; set; }
        public int EntregaParcial { get; set; }
        public int Entrega { get; set; }
        public string NoVale { get; set; }
        public string Requisicion { get; set; }
        public string FechaPedido { get; set; }
        public string FechaEntrega { get; set; }
        public string OrdenCompra { get; set; }
    }
}
