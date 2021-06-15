<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Carrito" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Catálogo</h1>

    <table id="serviciosTable" class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <tr>
                <th>Id</th>
                <th>Descripción</th>
                <th>Cantidad</th>
                <th></th>
                <th>Precio</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainScriptsContent" runat="server">
    <script>

        const productos = JSON.parse(window.localStorage.getItem('productos'));
         console.log("productos:", productos);
        $('#serviciosTable >tbody').html('');
        $.each(productos, (index, value) => {
            $('#serviciosTable >tbody').append(`<tr><td>A PROGRAMAR!</td><td>${value.producto}</td><td>${value.cantidad}</td><td><span style="cursor:pointer;" onclick="addProduct('${value.producto}')">+</span> / <span style="cursor:pointer;" onclick="removeProduct('${value.producto}')">-</span></td><td>A PROGRAMAR!</td></tr><tr><td colspan=5 align=center><a runat="server" href="~/Public/Carrito">Generar pedido</a></td></tr>`);
        });
        $(".bubble-cart").html(productos.length);


    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainCssContent" runat="server">
    <link href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="shortcut icon" type="image/x-icon" />
</asp:Content>

