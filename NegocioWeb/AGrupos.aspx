<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AGrupos.aspx.cs" Inherits="NegocioWeb.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Titulo:"></asp:Label>
    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTitulo" ErrorMessage="Ingrese titulo"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Descripcion:"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Ingrese Descripcion"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Tiempo previsto:(Días)"></asp:Label>
    <asp:TextBox ID="txtTiempo" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTiempo" ErrorMessage="Ingrese Dias"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTiempo" ErrorMessage="Valor numerico &gt; 0" MaximumValue="999999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
    <br />   
    <asp:Label ID="Label9" runat="server" Text="Costo:"></asp:Label>
    <asp:TextBox ID="txtCosto" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCosto" ErrorMessage="Ingrese Costo"></asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtCosto" ErrorMessage="Ingrese valor &gt;0" MaximumValue="99999999" MinimumValue="0" Type="Integer"></asp:RangeValidator>
    <br />      
    <asp:Label ID="Label3" runat="server" Text="Integrantes: "></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtNom" ErrorMessage=" Ingrese Nombre"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Cedula:"></asp:Label>
    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCedula" ErrorMessage="Ingrese Cedula"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Email: (Será su nombre de usuario)"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Ingrese mail"></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPassword" ErrorMessage="Ingrese Password"></asp:RequiredFieldValidator>
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

