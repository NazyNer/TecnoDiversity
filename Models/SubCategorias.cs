using System.ComponentModel.DataAnnotations;

namespace TecnoDiversity.Models;

public class SubCategoria
{
    [Key]
    public int SubCategoriaId { get; set; }
    public int CategoriaId { get; set; }
    public string Nombre { get; set; }
    public virtual Categoria? Categoria { get; set; }
}
