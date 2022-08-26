<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Escuela.aspx.cs" Inherits="ClienteWebCSharp.Escuela" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento para Escuela</h3>
    <p>
        CodEscuela : <asp:TextBox runat="server" Id ="txtCodEscuela" />
    </p>
    <p>
        Escuela : <asp:TextBox runat="server" Id ="txtEscuela" />
    </p>
    <p>
        Facultad : <asp:TextBox runat="server" Id ="txtFacultad" />
    </p>
    <p>
        <asp:Button  Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"/>
        <asp:Button  Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click"/>
        <asp:Button  Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click"/>
    </p>
    <p>
        Buscar : <asp:TextBox runat="server" ID="buscar" AutoPostBack="true" OnTextChanged="txtBuscar_Change"/>
        <asp:DropDownList runat="server" ID="criterio">
            <asp:ListItem Text="codEscuela" />
            <asp:ListItem Text="escuela" />
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView runat="server" ID="gvEscuela"></asp:GridView>
    </p>
</asp:Content>
