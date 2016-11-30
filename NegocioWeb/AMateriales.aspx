<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AMateriales.aspx.cs" Inherits="NegocioWeb.AMateriales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label3" runat="server" Text="Tipo material: "></asp:Label>
    <asp:DropDownList ID="ddTipo" runat="server" OnSelectedIndexChanged="ddTipo_SelectedIndexChanged" AutoPostBack="True">
        <asp:ListItem Selected="True">Importado</asp:ListItem>
        <asp:ListItem>Nacional</asp:ListItem>
    </asp:DropDownList>
    <br />

    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Peso: "></asp:Label>
    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Costo de compra: "></asp:Label>
    <asp:TextBox ID="txtCostoCompra" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Nombre de empresa: "></asp:Label>
    <asp:TextBox ID="txtNombreEmp" runat="server"></asp:TextBox>
    <br />
    <div runat="server" id="divImportado">
        <asp:Label ID="Label6" runat="server" Text="Pais de origen: "></asp:Label>
        <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
        <br />
    </div>
    <div runat="server" id="divNacional">
        <asp:Label ID="Label8" runat="server" Text="Años en plaza: "></asp:Label>
        <asp:TextBox ID="txtAnioPlaza" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Costo fijo: "></asp:Label>
        <asp:TextBox ID="txtCostoFijo" runat="server"></asp:TextBox>
        <br />
    </div>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
     <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
