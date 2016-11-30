<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NegocioWeb.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Usuario:"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
    <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" CssClass="btn btn-primary"/>
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    <br />
</asp:Content>
