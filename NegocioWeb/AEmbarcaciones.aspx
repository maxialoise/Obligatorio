<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AEmbarcaciones.aspx.cs" Inherits="NegocioWeb.AEmbarcaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="Label1" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Fecha de construnccion: "></asp:Label>
    <asp:TextBox ID="txtFecha" runat="server" ClientIDMode="Static"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha" ErrorMessage="Debe ingresar una fecha">*</asp:RequiredFieldValidator>
    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="Lo ingresado no es una fecha" Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Tipo de motor: "></asp:Label>
    <asp:TextBox ID="txtTipoMotor" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTipoMotor" ErrorMessage="Debe ingresar un tipo de motor">*</asp:RequiredFieldValidator>
    <br />
    <asp:Button CssClass="btn btn-primary" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
    <br />
    <asp:Label CssClass="alert-danger" ID="lblError" runat="server"></asp:Label>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
</asp:Content>
