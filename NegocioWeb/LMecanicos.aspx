<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="LMecanicos.aspx.cs" Inherits="NegocioWeb.LMecanicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grvMecanicos" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered table-sm">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="Direccion.Calle" HeaderText="Calle" />
            <asp:BoundField DataField="Direccion.NumPuerta" HeaderText="Numero de puerta" />
            <asp:BoundField DataField="Direccion.Ciudad" HeaderText="Ciudad" />
            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
            <asp:BoundField DataField="NumRegistro" HeaderText="Numero de registro" />
            <asp:BoundField DataField="PrecioJornal" HeaderText="Precio de jornal" />
            <asp:BoundField DataField="TieneCapExtra" HeaderText="Tiene Cap extra" />
        </Columns>
    </asp:GridView>
</asp:Content>
