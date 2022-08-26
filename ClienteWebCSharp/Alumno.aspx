<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alumno.aspx.cs" Inherits="ClienteWebCSharp.Alumno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Mantenimiento de Alumno</h3>

    <p>
        Codigo Alumno : <asp:TextBox runat="server" Id ="txtCodAlumno" />
    </p>
    <p>
        Apellidos : <asp:TextBox runat="server" Id ="txtApellidos" />
    </p>
    <p>
        Nombres : <asp:TextBox runat="server" Id ="txtNombres" />
    </p>
    <p>
        Lugar Nacimiento : <asp:TextBox runat="server" Id ="txtLugarNacimiento" />
    </p>
    <p>
        Fecha Nacimiento : <asp:TextBox runat="server" Id ="txtFechaNacimiento" />
        <asp:Label ID="Label1" runat="server" Text="AA-MM-DD HH:MM:SS AM"></asp:Label>
    </p>
    <p>
        Codigo Escuela : <asp:TextBox runat="server" Id ="txtCodEscuela" />
    </p>
    <p>
        <asp:Button  Text="Agregar" runat="server" Id="btnAgregar" OnClick="btnAgregar_Click"/>
        <asp:Button  Text="Eliminar" runat="server" Id="btnEliminar" OnClick="btnEliminar_Click"/>
        <asp:Button  Text="Actualizar" runat="server" Id="btnActualizar" OnClick="btnActualizar_Click"/>
    </p>
    <p>
        Buscar : <asp:TextBox runat="server" Id="txtBuscar" AutoPostBack="true" OnTextChanged="txtBuscar_Change"/>
        <asp:DropDownList runat="server" Id="ddlCriterio">
            <asp:ListItem Text="codAlumno" />
            <asp:ListItem Text="alumno" />
        </asp:DropDownList>
    </p>
    <p>
        <asp:GridView runat="server" Id="gvAlumnos"></asp:GridView>
    </p>






</asp:Content>
