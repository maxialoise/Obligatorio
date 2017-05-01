<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AsignarEvaluadores.aspx.cs" Inherits="NegocioWeb.AsignarEvaluadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Evaluadores: "></asp:Label>
    <asp:DropDownList ID="ddlEvaluadores" runat="server"></asp:DropDownList>
    <b>
        <asp:Label ID="lblAvisoEval" runat="server"></asp:Label>
    </b>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Emprendimientos: "></asp:Label>
    <asp:DropDownList ID="ddlEmprendimientos" runat="server"></asp:DropDownList>
    <b>
        <asp:Label ID="lblAvisoEmpren" runat="server"></asp:Label>
    </b>
    <br />
    <asp:Button ID="btnIngresar" runat="server" Text="Asignar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
