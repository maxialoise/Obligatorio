<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="GenerarTxt.aspx.cs" Inherits="NegocioWeb.GenerarTxt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnIngresar" runat="server" Text="Generar TXT" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>
