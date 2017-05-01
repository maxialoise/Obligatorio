<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AGrupos.aspx.cs" Inherits="NegocioWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Titulo:"></asp:Label>
    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Tiempo previsto:(Días)"></asp:Label>
    <asp:TextBox ID="txtTiempo" runat="server"></asp:TextBox>
    <br />   
    <asp:Label ID="Label9" runat="server" Text="Costo:"></asp:Label>
    <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
    <br />      
    <asp:Label ID="Label3" runat="server" Text="Integrantes: "></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Cedula:"></asp:Label>
    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Email: (Será su nombre de usuario)"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Personas" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnLimpiar" runat="server" Text="Quitar Personas" CssClass="btn btn-warning" OnClick="btnLimpiar_Click" />
    <br />
    <asp:ListBox ID="lstSeleccion" runat="server"></asp:ListBox>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Crear" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>

