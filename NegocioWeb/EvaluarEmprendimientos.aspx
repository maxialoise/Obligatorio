<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="EvaluarEmprendimientos.aspx.cs" Inherits="NegocioWeb.EvaluarEmprendimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label2" runat="server" Text="Emprendimientos: "></asp:Label>
    <asp:DropDownList ID="ddlEmprendimientos" runat="server" OnSelectedIndexChanged="ddlEmprendimientos_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    <b>
        <asp:Label ID="lblAvisoEmpren" runat="server"></asp:Label>
    </b>
    <br />
    <asp:Label ID="lblId" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblTitulo" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblDescripcion" runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label ID="lblTiempoPrevisto"  runat="server" Visible="false"></asp:Label>
    <br />
    <asp:Label  ID="lblPuntaje"  runat="server" Visible="False">Puntaje:</asp:Label>
    <asp:TextBox ID="txtPuntaje" runat="server" Visible="false"></asp:TextBox>
    <br />
     <asp:Label  ID="lblJustificacion"  runat="server" Visible="False">Justificación:</asp:Label>
    <asp:TextBox ID="txtJustificacion" runat="server" Visible="false"></asp:TextBox>
    <br />

    <asp:Button ID="btnIngresar" runat="server" Text="Asignar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</asp:Content>
