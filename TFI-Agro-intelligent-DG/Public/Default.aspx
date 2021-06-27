<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TFI_Agro_intelligent_DG._Default" Async="true"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron with-background">
        <h1>Agro Intelligent</h1>
        <p class="breadcrumb">Nuestra empresa se caracteriza por desarrollar soluciones innovadoras anticipándonos a las necesidades del agricultor, con el único objetivo de colaborar con el aumento de la producción.</p>
        <p><a href="https://localhost:44369/Public/About" class="btn btn-primary btn-lg">Acerca de Nosotros &raquo;</a></p>
    </div>

    <div class="row" >
        <div class="col-md-4">
            <h2><asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource.language, UniqueIrrigationSystem %>"></asp:Label></h2>
            <p>El riego de precisión utiliza las tecnologías disponibles para realizar una programación óptima del riego, estableciendo el momento, 
                la frecuencia y el tiempo de riego adecuados según las características del cultivo.</p>
            <p>
                <a class="btn btn-default" href="https://localhost:44369/Public/Catalogo">Ver más &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sistema Anti-helada</h2>
            <p> El sistema anti-Helada consta de una aplicación constante de agua, satura la superficie de humedad consiguiendo así reducir la evaporación y rebajar la conducción de calor 
                consiguiendo reducir la perdida calórica por hora que se produce en las parcelas de cultivos de cítricos. </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44369/Public/Catalogo">Ver más &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sistema Control de Plagas:</h2>
            <p>Agro-Intelligent ofrece al agricultor el suministro y asesoría con los mejores productos y servicios para el control de plagas. </p>
            <p>
                <a class="btn btn-default" href="https://localhost:44369/Public/Catalogo">Ver más &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainCssContent" runat="server">
    <style>
           .with-background {
        background:url('/content/Fondo.jpg');
        opacity:.8;
        color:black;
        font-weight:bold;
        }
    </style>
</asp:Content>
