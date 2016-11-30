<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="LReparacionesFinalizadas.aspx.cs" Inherits="NegocioWeb.LReparacionesFinalizadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grvFinalizadas" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered table-sm" OnRowCommand="grvClientes_RowCommand">
        <Columns>
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de ingreso" />
            <asp:BoundField DataField="FechaRealEngreso" HeaderText="Fecha de entrega" />
            <asp:BoundField DataField="CostoReparacion" HeaderText="Costo total de la reparacion" />
            <asp:ButtonField ButtonType="Button" CommandName="detalle" Text="Ver Detalle" />
        </Columns>
    </asp:GridView>

</asp:Content>
