using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TFI_Agro_intelligent_DG
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
$(document).ready(function () {
    fetch('https://localhost:44325/Carrito', {
        method: 'POST', // or 'PUT'
        body: JSON.stringify({ CarritoID: 1 }), // data can be `string` or {object}!
        headers: {
            'Content-Type': 'application/json'
        }
    })
        .then(response => response.json())
        .then(data => {
            console.log(data.data);
            $.each(data.data, (index, value) => {
                $('#serviciosTable >tbody').append(`<tr><td>${value[0]}</td><td>${value[1]}</td><td>${value[2]}</td><td><span style="cursor:pointer;" onclick="addProduct('${value[0]}')">+</span> / <span style="cursor:pointer;" onclick="removeProduct('${value[0]}')">-</span></td><td>${value[3]}</td></tr><tr><td colspan=5 align=center><span style="cursor:pointer;" onclick="">Confirmar pedido</span></td></tr>`);
            });
        }));
});
const productos = [];
let cantidadProductos = 0;
const agregarAlCarrito = (producto) => {
    cantidadProductos++;
    productos.push({ producto: producto, cantidad: 1 });
    window.localStorage.setItem('productos', JSON.stringify(productos));
    $(".bubble-cart").html(productos.length);
    console.log(producto);
};*/
        }
    }
}