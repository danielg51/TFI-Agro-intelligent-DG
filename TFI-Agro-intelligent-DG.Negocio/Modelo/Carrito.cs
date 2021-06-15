using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFI_Agro_intelligent_DG.Negocio.Modelo
{
    public class Carrito
    {
        public Carrito()
        {
        }
        [Key]
        public int CarritoId { get; set; }
        public ICollection<CarritoDetalle> DetalleCompra { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioId { get; set; } // TODO: Poner el usuario de identity o algo para hacer referencia en las tablas y poder usarlo com oobjeto
               

    }
}