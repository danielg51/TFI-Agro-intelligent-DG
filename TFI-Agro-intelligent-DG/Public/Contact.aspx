<%@ Page Title="Contáctenos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Contact" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Nuestros Datos.</h3>
    <address>
        Agro-intelligent.<br />
        Av. Laurencena, Paraná, Entre Ríos<br />
        <abbr title="Telefono">TEL:</abbr>
        (+54) 0343 4230122
    </address>

    <address>
        <strong>Ventas:</strong>   <a href="mailto:Ventas@Agro-intelligent.com.ar">Ventas@Agro-intelligent.com.ar</a><br />
        <strong>Contacto:</strong> <a href="mailto:Info@Agro-intelligent.com">Info@Agro-intelligent.com.ar</a>
    </address>
</asp:Content>
