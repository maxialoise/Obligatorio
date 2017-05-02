<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AUsuario.aspx.cs" Inherits="NegocioWeb.AUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label4" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Cedula:"></asp:Label>
    <asp:TextBox ID="txtCedula" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label>
    <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="lblTel" runat="server" Text="Telefono:" Visible="false"></asp:Label>
    <asp:TextBox ID="txtTel" runat="server" Visible="false"></asp:TextBox>
    <br />

    <asp:Label ID="lblCalif" runat="server" Text="Calificacion:" Visible="false"></asp:Label>
    <asp:TextBox ID="txtCalif" runat="server" Visible="false"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Rol:"></asp:Label>
    <asp:DropDownList ID="ddlRol" runat="server" OnSelectedIndexChanged="ddlRol_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem Value="Admin">Administrador</asp:ListItem>
        <asp:ListItem Value="Evaluador">Evaluador</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btnCrear_Click" />
    <br />
    <br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
     <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
</asp:Content>
