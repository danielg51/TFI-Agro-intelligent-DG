using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFI_Agro_intelligent_DG.Contexts;
using TFI_Agro_intelligent_DG.Negocio.Modelo;
using PdfSharp.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace TFI_Agro_intelligent_DG.Datos.Managers
{
    public class CarritoManager : TFI_Agro_intelligent_DG.Datos.IManager.ICarritoManager
    {
        ServicioContext _context;

        public CarritoManager(ServicioContext context)
        {
            _context = context;
        }

        private async Task<Pack> AddPack(Pack pack)
        {
            if (pack != null)
            {
                _context.Packs.Add(pack);
                await _context.SaveChangesAsync();
                return pack;
            }
            return null;
        }

        private async Task<Pack> DeletePack(int id)
        {
            var pack = await _context.Packs.FindAsync(id);
            _context.Entry(pack).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
            return pack;
        }

        private async Task<Pack> GetPackById(int id)
        {
            var pack = await _context.Packs.FindAsync(id);
            return pack;
        }

        public async Task<Carrito> GetCarrito(int carritoID)
        {
            var packs = await _context.Carritos.Where(x => x.CarritoId == carritoID)
                                            .Include(x => x.DetalleCompra)
                                            .ThenInclude(x => x.Pack)
                                            .FirstOrDefaultAsync();
            return packs;
        }

        public int AgregarCarrito(string usuarioID)
        {
            try
            {
                Carrito carrito = new Carrito()
                {
                    FechaCreacion = DateTime.Now,
                    UsuarioId = usuarioID
                };
                _context.Carritos.Add(carrito);
                _context.SaveChanges();

                return carrito.CarritoId;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }

        public int AgregarCarritoDetalle(int packID, int cantidad, int carritoID)
        {
            Carrito carrito = _context.Carritos.Where(x => x.CarritoId == carritoID)
                                            .Include(x => x.DetalleCompra)
                                            .FirstOrDefault();
            CarritoDetalle det = new CarritoDetalle()
            {
                Pack = _context.Packs.Where(x => x.PackId == packID).FirstOrDefault(),
                Cantidad = cantidad
            };
            carrito.DetalleCompra.Add(det);
            //_context.Entry(pack).State = EntityState.Modified;
            _context.SaveChanges();
            return det.CarritoDetalleId;
        }

        public string GetPedidoPDF(int carritoID)
        {
            string archivoNombre = "pedido_" + carritoID.ToString() + ".pdf";
            var carrito = _context.Carritos.Where(x => x.CarritoId == carritoID).Include(x => x.DetalleCompra).ThenInclude(x => x.Pack).FirstOrDefault();
            StringBuilder html = new StringBuilder();
            html.AppendLine("<html>");
            html.AppendLine("<body>");
            html.AppendLine("<div>Detalle del pedido #" + carritoID.ToString() + "</div>");
            html.AppendLine("<table id = \"serviciosTable\" border=\"1\" style=\"width:100%;\">");
            html.AppendLine("<thead>");
            html.AppendLine("<tr>");
            html.AppendLine("<th>Id</th>");
            html.AppendLine("<th>Descripción</th>");
            html.AppendLine("<th>Cantidad</th>");
            html.AppendLine("<th>Precio Unitario</th>");
            html.AppendLine("<th>Precio</th>");
            html.AppendLine("</tr>");
            html.AppendLine("</thead>");
            html.AppendLine("<tbody>");
            double precioTotal = 0;
            foreach (var item in carrito.DetalleCompra)
            {
                html.AppendLine("<tr>");
                html.AppendLine("<td>" + item.CarritoDetalleId.ToString() + "</td>");
                html.AppendLine("<td>" + item.Pack.Descripcion.ToString() + "</td>");
                html.AppendLine("<td>" + item.Cantidad.ToString() + "</td>");
                html.AppendLine("<td>" + item.Pack.Precio.ToString() + "</td>");
                double precio = item.Pack.Precio * item.Cantidad;
                html.AppendLine("<td>" + precio.ToString() + "</td>");
                html.AppendLine("</tr>");
                precioTotal += precio;
            }
            html.AppendLine("</tbody>");
            html.AppendLine("<tfoot>");
            html.AppendLine("<tr>");
            html.AppendLine("<td colspan=5 align=right>Precio Total: " + precioTotal.ToString() + "</td>");
            html.AppendLine("</tr>");
            html.AppendLine("</tfoot>");
            html.AppendLine("</table>");
            html.AppendLine("</body>");
            html.AppendLine("</html>");

            byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = PdfGenerator.GeneratePdf(html.ToString(), PdfSharp.PageSize.A4);
                pdf.Save(archivoNombre);

            }
            //return File.Open(archivoNombre, FileMode.Open);
            return archivoNombre;
        }

    }
}
