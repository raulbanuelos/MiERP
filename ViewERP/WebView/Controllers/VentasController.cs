using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebView.Models;

namespace WebView.Controllers
{
    public class VentasController : Controller
    {
        // GET: Ventas
        public ActionResult AgregarVenta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GuardarVenta(double monto, DateTime fecha)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            int r = DataManager.InsertVenta(idUsuario, monto, fecha);

            var jsonResult = Json(r, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaDiaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaDiaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaMesActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaMesActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaSemanaActual(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            double venta = DataManager.GetVentaSemanaActual(idUsuario);

            var jsonResult = Json(venta, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        [HttpPost]
        public JsonResult GetVentaUltimosMeses(string parametro)
        {
            int idUsuario = ((DO_Persona)Session["UsuarioConectado"]).idUsuario;
            List<FO_Item> lista = DataManager.GetVentaUltimosMeses(idUsuario);

            var jsonResult = Json(lista, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}

/*
 USE [RGP2-PBA]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TBL_DEPOSITOS](

[ID_DEPOSITO][int] IDENTITY(1, 1) NOT NULL,

[ID_USUARIO] [int] NULL,
	[FECHA_INGRESO] [datetime] NULL,
	[FECHA_REGISTRO] [datetime] NULL,
	[MONTO] [float] NULL,
	[BANCO] [varchar](50) NULL,
	[DESCRIPCION] [varchar](max)NULL,
	[URL_ARCHIVO] [varchar](max)NULL,
 CONSTRAINT[PK_TBL_DEPOSITOS] PRIMARY KEY CLUSTERED 
(

    [ID_DEPOSITO] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO

ALTER TABLE [dbo].[TBL_DEPOSITOS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_DEPOSITOS_TBL_USUARIO] FOREIGN KEY([ID_USUARIO])
REFERENCES[dbo].[TBL_USUARIO]([ID_USUARIO])
GO

ALTER TABLE [dbo].[TBL_DEPOSITOS] CHECK CONSTRAINT[FK_TBL_DEPOSITOS_TBL_USUARIO]
GO

 
 */


/*
 * USE [RGP2-PBA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RAÚL BAÑUELOS
-- Create date: 25 OCT 2020
-- Description: < Description,,>
     -- =============================================
 ALTER PROCEDURE[dbo].[SP_ERP_GET_VENTA_ULTIMOS_MESES]
    @idUsuario INT
AS
BEGIN
    SELECT  CAST(MONTH(FECHA_INGRESO) AS VARCHAR(2)) +'-' + '01-' + CAST(YEAR(FECHA_INGRESO) AS VARCHAR(4)) AS MESES, SUM(MONTO) AS MONTO
    FROM TBL_VENTA
    WHERE (ID_USUARIO = @idUsuario) AND(FECHA_INGRESO BETWEEN DATEADD(DAY, 1, EOMONTH(GETDATE(), -11))  AND GETDATE())
    GROUP BY CAST(MONTH(FECHA_INGRESO) AS VARCHAR(2)) +'-' + '01-' + CAST(YEAR(FECHA_INGRESO) AS VARCHAR(4))
END

 */


/*
 * 
 * USE [RGP2-PBA]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RAÚL BAÑUELOS
-- Create date: 26 OCT 2020
-- Description: < Description,,>
 -- =============================================
 ALTER PROCEDURE[dbo].[SP_ERP_GET_SEMANA_ACTUAL]


AS
BEGIN
	SELECT * 
	FROM TBL_SEMANA
	WHERE GETDATE() BETWEEN DIA_INICIAL AND DIA_FINAL
END

 * 
 */