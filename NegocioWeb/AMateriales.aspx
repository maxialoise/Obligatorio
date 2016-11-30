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
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Peso: "></asp:Label>
    <asp:TextBox ID="txtPeso" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPeso" ErrorMessage="Debe ingresar un peso">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPeso" ErrorMessage="El peso debe de ser mayor a cero" MaximumValue="999999999999" MinimumValue="0,1" Type="Double">*</asp:RangeValidator>
    <br />

    <asp:Label ID="Label4" runat="server" Text="Costo de compra: "></asp:Label>
    <asp:TextBox ID="txtCostoCompra" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="Debe ingresar un costo de compra">*</asp:RequiredFieldValidator>
    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtCostoCompra" ErrorMessage="El costo de compra debe ser mayor a cero" MaximumValue="9999999999999" MinimumValue="0,1">*</asp:RangeValidator>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Nombre de empresa: "></asp:Label>
    <asp:TextBox ID="txtNombreEmp" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombreEmp" ErrorMessage="Debe ingresar un nombre de empresa">*</asp:RequiredFieldValidator>
    <br />
    <div runat="server" id="divImportado">
        <asp:Label ID="Label6" runat="server" Text="Pais de origen: "></asp:Label>
        <asp:TextBox ID="txtPais" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPais" ErrorMessage="Debe ingresar un pais de origen">*</asp:RequiredFieldValidator>
        <br />
    </div>
    <div runat="server" id="divNacional">
        <asp:Label ID="Label8" runat="server" Text="Años en plaza: "></asp:Label>
        <asp:TextBox ID="txtAnioPlaza" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAnioPlaza" ErrorMessage="Debe ingresar los años en plaza">*</asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Costo fijo: "></asp:Label>
        <asp:TextBox ID="txtCostoFijo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCostoFijo" ErrorMessage="Debe ingresar el costo fijo">*</asp:RequiredFieldValidator>
        <br />
    </div>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click"  CssClass="btn btn-primary"/>
    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" OnClick="btnLimpiar_Click"  CssClass="btn btn-warning"/>
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</asp:Content>
