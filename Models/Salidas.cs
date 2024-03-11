using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using TecnoDiversity.Models.Temp;

namespace TecnoDiversity.Models;

public class Salida
{
  [Key]
  public int SalidaId { get; set; }
  public DateTime Fecha { get; set; }
  public string userId { get; set; }
  public string UserEmail { get; set; }
  public bool Cancelado { get; set; }
  public decimal Total { get; set; }
  public FormasDePago FormasPago { get; set; }
}

public class DescripcionSalida
{
  [Key]
  public int DescripcionId { get; set; }
  public int SalidaId { get; set; }
  public int ProductoId { get; set; }
  public decimal Precio { get; set; }
  public int Cantidad { get; set; }
  public decimal SubTotal { get; set; }
  public virtual Producto? Producto { get; set; }

}