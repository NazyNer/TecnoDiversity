using System.ComponentModel.DataAnnotations;

namespace TecnoDiversity.Models;

public class Producto
{
    [Key]
    public int ProductoId { get; set; }
    public string Nombre { get; set; }
    public decimal PrecioVenta { get; set; }
    public decimal PrecioCompra { get; set; }
    public string Descripcion { get; set; }
    public int Cantidad { get; set; }
    public int SubCategoriaId { get; set; }
    public virtual SubCategoria? SubCategoria { get; set; }
}
