<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TFI_Agro_intelligent_DG.Carrito" Async="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carrito</h1>

    <table id="serviciosTable" class="table table-striped table-bordered" style="width:100%;">
        <thead>
            <tr>
                <th>Id</th>
                <th>Descripción</th>
                <th>Cantidad</th>
                <th></th>
                <th>Precio Unitario</th>
                <th>Precio</th>
            </tr>
        </thead>
        <tbody></tbody>
    </table>
    <div id ="Respuesta"></div>
    <script>
        var userid = '<%: Context.User.Identity.GetUserId()  %>';
        window.localStorage.setItem('Usuario', userid);
        console.log('userid: ' + userid);
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainScriptsContent" runat="server">
    <script>

        const productos = JSON.parse(window.localStorage.getItem('productos'));
        console.log("productos:", productos);
        $('#serviciosTable >tbody').html('');
        $.each(productos, (index, value) => {
            $('#serviciosTable >tbody').append(`<tr><td>${value.id}</td><td>${value.producto}</td><td>${value.cantidad}</td><td><span style="cursor:pointer;" onclick="addProduct('${value.producto}'); RefrescarTabla();">+</span> / <span style="cursor:pointer;" onclick="removeProduct('${value.producto}'); RefrescarTabla();">-</span></td><td>${value.precio}</td><td>${value.cantidad * value.precio}</td></tr><tr><td colspan=6 align=center><span style="cursor:pointer;" onclick="GuardarPedido()">Finalizar Pedido</span></td></tr>`);
        });

        const RefrescarTabla = () => {
            var productos = JSON.parse(window.localStorage.getItem('productos'));
            console.log("productos:", productos);
            $('#serviciosTable >tbody').html('');
            $.each(productos, (index, value) => {
                $('#serviciosTable >tbody').append(`<tr><td>${value.id}</td><td>${value.producto}</td><td>${value.cantidad}</td><td><span style="cursor:pointer;" onclick="addProduct('${value.producto}'); RefrescarTabla();">+</span> / <span style="cursor:pointer;" onclick="removeProduct('${value.producto}'); RefrescarTabla();">-</span></td><td>${value.precio}</td><td>${value.cantidad * value.precio}</td></tr><tr><td colspan=6 align=center><span style="cursor:pointer;" onclick="GuardarPedido()">Finalizar Pedido</span></td></tr>`);
            });
            $(".cart-table").hide();
        }

        const GuardarPedido = () => {
            const productos = JSON.parse(window.localStorage.getItem('productos'));
            console.log(productos);
            const data = []; //new Array(productos.length).fill(0).map(() => new Array(4).fill(0)) //[];
            $.each(productos, (index, value) => {
                data.push([String(value.id), value.producto, String(value.cantidad), value.precio]);
            });
            fetchApi(data)

            $("#Respuesta").html('Estamos procesando su compra...');


        };

        function RespuestaGenerarCarrito(carritoID) {
            var res = window.localStorage.getItem('generarCarritoRespuesta');
            //var res = carritoID;

            if (res > 0) {
                $(".bubble-cart").html('0');
                $("#serviciosTable").hide();
                const productos = [];
                window.localStorage.setItem('productos', productos);
                $("#Respuesta").html('Se genero el pedido correctamente con el numero #' + String(res) + "<br>Lleve este <a href=\"https://localhost:44325/Carrito/files/" + String(res) + "\" download>comprobante</a> para retirar el pedido.");
                window.localStorage.setItem('generarCarritoRespuesta', 0);
            } else {
                $("#Respuesta").html('Ocurrio un problema. Por favor reintentalo nuevamente.');
            }
        }

        function fetchApi(data) {


            var usuario = window.localStorage.getItem('Usuario');
            var jsonProds = JSON.stringify({ "data": { data }, usuario });
            /*var envioprueba = JSON.stringify({
                "data": {
                    "data": [
                        [
                            "1", "sads", "5", "100"
                        ],
                        [
                            "2", "sads", "2", "50"
                        ]
                    ]
                },
                    "usuario": "AAAAAAA"
                
            });*/

            return fetch('https://localhost:44325/Carrito', {
                method: 'POST',

                headers: {
                    //'Content-Type': 'application/x-www-form-urlencoded'
                    'Content-Type': 'application/json'
                },
                //body: jsonProds
                /* ESTO ANDA*/
                body: jsonProds
            })

                .then(res => res.json())
                .then(res => { window.localStorage.setItem('generarCarritoRespuesta', res) })
                .then(res => { console.log(res) })
                .then(res => RespuestaGenerarCarrito(res));
        }

    </script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainCssContent" runat="server">
    <link href="//cdn.datatables.net/1.10.24/css/jquery.dataTables.min.css" rel="shortcut icon" type="image/x-icon" />
</asp:Content>

