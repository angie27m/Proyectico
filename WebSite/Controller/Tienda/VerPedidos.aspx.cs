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

public partial class View_Tienda_VerPedidos : System.Web.UI.Page
{
    
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DS_Pedidos reporte_pedidos = ObtenerInforme();
                CRS_Pedidos.ReportDocument.SetDataSource(reporte_pedidos);
                CRV_Pedidos.ReportSource = CRS_Pedidos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected DS_Pedidos ObtenerInforme()
        {
            //DataRow fila;
            DataTable pedidosInformacion = new DataTable();
            DS_Pedidos datos = new DS_Pedidos();

            pedidosInformacion = datos.Tables["Pedidos"];

            VerPedidos verP = new VerPedidos(pedidosInformacion);
            verP.obtenerInforme();
            return datos;
        }
    }
