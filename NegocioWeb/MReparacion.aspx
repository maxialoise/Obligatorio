<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="MReparacion.aspx.cs" Inherits="NegocioWeb.MReparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Reparaciones a embarcacion: "></asp:Label>
    <asp:DropDownList ID="ddlReparaciones" runat="server"></asp:DropDownList>
    <b><asp:Label ID="lblAviso" runat="server"></asp:Label></b>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Mecanicos: "></asp:Label>
    <asp:CheckBoxList ID="cbMecanicos" runat="server"></asp:CheckBoxList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Materiales: "></asp:Label>
    <asp:DropDownList ID="ddlMateriales" runat="server"></asp:DropDownList>
    <asp:DropDownList ID="ddlCantidad" runat="server"></asp:DropDownList>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar items" OnClick="btnAgregar_Click" CssClass="btn btn-primary"/>
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar todos los Items" CssClass="btn btn-warning" OnClick="btnLimpiar_Click"/>
    <br />
    <asp:ListBox ID="lstSeleccion" runat="server"></asp:ListBox>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary"/>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
