<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Catalogo" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Catálogo</h1>

    <table id="serviciosTable" class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <tr>
                <th>Id</th>
                <th>Descripción</th>
                <th>Precio</th>
                <th>Acciones</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainScriptsContent" runat="server">
    <script>


        $(document).ready(function () {
            fetch('https://localhost:44325/Pack')
                .then(response => response.json())
                .then(data => {
                    console.log(data.data);
                    $.each(data.data, (index, value) => {
                        $('#serviciosTable >tbody').append(`<tr><td>${value[0]}</td><td>${value[2]}</td><td>${value[3]}</td><td><button type="button" onclick="agregarAlCarrito(${value[0]}, '${value[2]}', '${value[3]}')">Agregar al Carrito</button></td></tr>`);
                    });
                });
        });
        const productos = [];
        let cantidadProductos = 0;
        const agregarAlCarrito = (id, producto, precio) => {
            let productos = JSON.parse(window.localStorage.getItem('productos'));
            productoActual = productos.pop(productos.find(p => p.producto = producto));
            if (productoActual) {
                productoActual.cantidad++;
                productos.push(productoActual);
                window.localStorage.setItem('productos', JSON.stringify(productos));
            }
            else {
                cantidadProductos++;
                productos.push({ id: id, producto: producto, cantidad: 1, precio: precio });
                window.localStorage.setItem('productos', JSON.stringify(productos));
            }
            $(".bubble-cart").html(productos.length);
            console.log(producto);
        };
    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainCssContent" runat="server">
    <link href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="shortcut icon" type="image/x-icon" />
</asp:Content>

