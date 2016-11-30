<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="FinalizarReparacion.aspx.cs" Inherits="NegocioWeb.FinalizarReparacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Embarcaciones pendientes de reparacion: "></asp:Label>
    <asp:DropDownList ID="ddlReparaciones" runat="server"></asp:DropDownList>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Finalizar reparacion" OnClick="btnIngresar_Click" />
      <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
