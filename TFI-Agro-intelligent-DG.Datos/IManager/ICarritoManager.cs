using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Negocio.Modelo;

namespace TFI_Agro_intelligent_DG.Datos.IManager
{
    public interface ICarritoManager
    {

        Task<Carrito> GetCarrito(int id);

        int AgregarCarrito(string usuarioID);

        int AgregarCarritoDetalle(int packID, int cantidad, int carritoID);

        string GetPedidoPDF(int carritoID);

    }
}
