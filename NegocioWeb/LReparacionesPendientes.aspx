<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="LReparacionesPendientes.aspx.cs" Inherits="NegocioWeb.LReparacionesPendientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grvPendientes" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered table-sm">
        <Columns>
            <asp:BoundField DataField="FechaIngreso" HeaderText="Fecha de ingreso" />
            <asp:BoundField DataField="Embarcacion.Nombre" HeaderText="Nombre de embarcacion" />
            <asp:BoundField DataField="FechaPrometidaEgreso" HeaderText="Fecha prometida de egreso" />
        </Columns>
    </asp:GridView>
</asp:Content>
