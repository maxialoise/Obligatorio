<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpresa.Master" AutoEventWireup="true" CodeBehind="DetalleReparacion.aspx.cs" Inherits="NegocioWeb.DetalleReparacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:gridview id="grvMateriales" runat="server" autogeneratecolumns="False" cssclass="table table-hover table-bordered table-sm">
        <Columns>
            <asp:BoundField DataField="Material.Nombre" HeaderText="Material" />
            <asp:BoundField DataField="Cantidad" HeaderText="Canitdad" />
        </Columns>
    </asp:gridview>
    <br />
     <asp:gridview id="grvMecanicos" runat="server" autogeneratecolumns="False" cssclass="table table-hover table-bordered table-sm">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre mecanico" />
             <asp:BoundField DataField="NumRegistro" HeaderText="Numero de registro" />
        </Columns>
    </asp:gridview>
</asp:Content>
