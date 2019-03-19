﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Logica;

public partial class View_Login_Rec_Idioma : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Example ge = new Example();
        

        //if (!IsPostBack)
        //{
           // DDL_Idioma.Items.Add("Seleccione un idioma -- Choose a language");
            DDL_Idioma.Items.Add("Español");
            DDL_Idioma.Items.Add("English");
        //}
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["idioma"] = DDL_Idioma.SelectedItem.ToString();
        Response.Redirect("~/View/Login-Rec/NuevoLogin.aspx");
    }
}