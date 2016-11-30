<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AEmbarcaciones.aspx.cs" Inherits="NegocioWeb.AEmbarcaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Fecha de construnccion: "></asp:Label>
    <asp:TextBox ID="txtFecha" runat="server" ClientIDMode="Static"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de motor: "></asp:Label>
    <asp:TextBox ID="txtTipoMotor" runat="server"></asp:TextBox>
    <br />
    <asp:Button CssClass="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    <br />
    <asp:Label CssClass="alert-danger" ID="lblError" runat="server"></asp:Label>
</asp:Content>
