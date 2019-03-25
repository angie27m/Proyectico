<%@ Page Title="" Language="C#" MasterPageFile="~/View/Tienda/MasterSuperAdmin.master" AutoEventWireup="true" CodeFile="~/Controller/Tienda/AgregarSede.aspx.cs" Inherits="View_Tienda_AgregarSede" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style11 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div>
            <table class="auto-style1">
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="L_Nombre_Sede" runat="server" Text="Nombre sede:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Nombre_Sede" runat="server" MaxLength="15"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="L_Ciudad" runat="server" Text="Ciudad:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Ciudad" runat="server" MaxLength="15"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="L_Direccion" runat="server" Text="Direccion:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Direccion" runat="server" MaxLength="15"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style11"></td>
                    <td class="auto-style11"></td>
                    <td class="auto-style11">
                        <asp:Button ID="B_Agregar_Sede" runat="server" OnClick="B_AgregarSede_Click" Text="Agregar" />
                    </td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:GridView ID="GV_Sedes" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GV_Sedes_RowDataBound" OnPageIndexChanging="GV_Sedes_PageIndexChanging" PageSize="6">
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LB_Eliminar0" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" CommandArgument='<%# Bind("Idsede") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NombreSede" HeaderText="Nombre Sede" />
                                <asp:BoundField DataField="Ciudad" HeaderText="Ciudad" />
                                <asp:BoundField DataField="Direccion" HeaderText="Direccion" />                                                                
                                
                            </Columns>
                            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" ForeColor="#003399" />
                            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                            <SortedAscendingCellStyle BackColor="#EDF6F6" />
                            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                            <SortedDescendingCellStyle BackColor="#D6DFDF" />
                            <SortedDescendingHeaderStyle BackColor="#002876" />
                        </asp:GridView>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
</asp:Content>

