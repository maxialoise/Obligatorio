<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="LEmbarcaciones.aspx.cs" Inherits="NegocioWeb.LEmbarcaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="grvEmbarcaciones" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-bordered table-sm">
        <Columns>
            <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="FechaConstruccion" HeaderText="Fecha de Construccion" />
            <asp:BoundField DataField="TipoMotor" HeaderText="Tipo de motor" />
        </Columns>
    </asp:GridView>
</asp:Content>
