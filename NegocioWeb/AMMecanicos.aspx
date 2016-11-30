<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="AMMecanicos.aspx.cs" Inherits="NegocioWeb.AMMecanicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:DropDownList runat="server" ID="ddlOpcion" AutoPostBack="True" OnSelectedIndexChanged="ddlOpcion_SelectedIndexChanged">
        <asp:ListItem Selected="True">Alta</asp:ListItem>
        <asp:ListItem>Modificacion</asp:ListItem>
    </asp:DropDownList>
    <br />
    <div runat="server" id="divBuscar">
        <asp:Label runat="server" Text="Numero de registro: "></asp:Label>
        <asp:TextBox runat="server" ID="txtBuscarReg"></asp:TextBox>
        <asp:Button runat="server" CausesValidation="False" Text="Buscar" ID="btnBuscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
    </div>

    <br />
    <br />

    <asp:Label runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" Text="Telefono: "></asp:Label>
    <asp:TextBox runat="server" ID="txtTelefono"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar un telefono" ControlToValidate="txtTelefono">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" Text="Calle :"></asp:Label>
    <asp:TextBox runat="server" ID="txtCalle"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe ingresar una calle" ControlToValidate="txtCalle">*</asp:RequiredFieldValidator>
    <asp:Label runat="server" Text="Numero de Puerta :"></asp:Label>
    <asp:TextBox runat="server" ID="txtNumPuerta"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe ingresar un Numero de puerta" ControlToValidate="txtNumPuerta">*</asp:RequiredFieldValidator>
    <asp:Label runat="server" Text="Ciudad :"></asp:Label>
    <asp:TextBox runat="server" ID="txtCiudad"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe ingresar una ciudad " ControlToValidate="txtCiudad">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" Text="Numero de Registro: "></asp:Label>
    <asp:TextBox runat="server" ID="txtNumRegistro"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe ingresar un numero de registro" ControlToValidate="txtNumRegistro">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" Text="Precio Jornal: "></asp:Label>
    <asp:TextBox runat="server" ID="txtPrecioJornal"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Debe ingresar un precio de jornal" Text="*" ControlToValidate="txtPrecioJornal"></asp:RequiredFieldValidator>
    <br />
    <asp:Label runat="server" Text="Tiene Capacitacion Extra: "></asp:Label>
    <asp:CheckBox runat="server" ID="cbCapExtra"></asp:CheckBox>
    <br />
    <asp:Button runat="server" Text="Ingresar" ID="btnIngresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
    <asp:Button runat="server" Text="Modificar" ID="btnModificar" OnClick="btnModificar_Click" CssClass="btn btn-primary" />
    <asp:Button runat="server" CausesValidation="False" Text="Limpiar" ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-warning" />
    <br />
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
</asp:Content>
