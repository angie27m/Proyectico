using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Tienda_AddIdioma : System.Web.UI.Page
{
    List<string> compAct = new List<string>();
    AddIdioma add;
    protected void Page_Load(object sender, EventArgs e)
    {
        B_Comprobar.Enabled = true;

    }

    protected void B_Comprobar_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        compAct = add.getListaAct();
        DDL_Actual.DataSource = compAct;
        DDL_Actual.DataBind();
        B_Guardar.Enabled = true;
        Panel1.Visible = true;
        TB_Nombre.Enabled = false;
        TB_Terminacion.Enabled = false;
        B_Comprobar.Enabled = false;
    }

    protected void B_Guardar_Click(object sender, EventArgs e)
    {
        add = new AddIdioma(Session["idioma"].ToString());
        add.ValidarExistente(TB_Nombre.Text.ToString(), TB_Terminacion.Text.ToString());
        add.ActualizarIdioma(DDL_Actual.SelectedItem.ToString(), TB_Traduccion.Text.ToString());
        DDL_Actual.Items.Remove(DDL_Actual.SelectedItem.ToString());
        DDL_Actual.Items.Clear();
        compAct = add.getListaAct();        
        DDL_Actual.DataSource = compAct;
        DDL_Actual.DataBind();
        TB_Traduccion.Text = "";
    }
}