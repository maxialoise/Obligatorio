<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AReparacion.aspx.cs" Inherits="NegocioWeb.AReparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Fecha ingreso: "></asp:Label>
    <asp:TextBox ID="txtFecha" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Fecha prometida de entrega: "></asp:Label>
    <asp:TextBox ID="txtFechaDos" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Embarcacion a reparar: "></asp:Label>
    <asp:DropDownList ID="ddlEmbarcaciones" runat="server" SelectionMode="Single"></asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
