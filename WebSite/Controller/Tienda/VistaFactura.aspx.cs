using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos;
using Logica;
using Utilitarios.DataSet;

public partial class View_Tienda_VistaFactura : System.Web.UI.Page
{
    DataTable idVenta
    {
        get { return Session["idVenta"] as DataTable; }
        set { Session["idVenta"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        idVenta = Session["idVenta"] as System.Data.DataTable;
        VistaFactura vistaF = new VistaFactura(idVenta);
        vistaF.pageLoad();
        try
        {
            DS_Factura DS_Factura_ = ObtenerInforme();
            CRS_Factura.ReportDocument.SetDataSource(DS_Factura_);
            CRV_Factura.ReportSource = CRS_Factura;
        }
        catch (Exception)
        {
            throw;
        }
        
        string a = vistaF.devuelveMensaje();
#pragma warning disable CS0618 // Type or member is obsolete
        RegisterStartupScript("mensaje", "<script type='text/javascript'>alert('" + a + "');</script>");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    protected DS_Factura ObtenerInforme()
    {
        DS_Factura datos = new DS_Factura();
        VistaFactura vistaF = new VistaFactura(idVenta);
        vistaF.obtenerInforme();
        Session["idVenta"] = null;
        return datos;
    }
}