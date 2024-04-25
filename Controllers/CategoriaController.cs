using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoDiversity.Data;
using TecnoDiversity.Models;

namespace TecnoDiversity.Controllers;

public class CategoriaController : Controller{
  private readonly ILogger<CategoriaController> _logger;
  private readonly ApplicationDbContext _context;

  public CategoriaController(ILogger<CategoriaController> logger, ApplicationDbContext context){
    _logger = logger;
    _context = context;
  }

  public IActionResult Index(){
    return View();
  }
  

  public JsonResult AgregarCategoria(string NombreCategoria, int ID = 0){
    var returned = true;
    try{
      var upperName = NombreCategoria.ToUpper();
      var categoria = new Categoria{Nombre = upperName};
      var categoriaExiste = _context.Categorias.FirstOrDefault(c => c.Nombre == upperName);
      if (categoriaExiste != null)
      {
        returned = false;
        return Json(new {returned, Error = "La categoria ya existe"});
      }else{
        if (ID != 0)
        {
          var categoriaEditar = _context.Categorias.Find(ID);
          categoriaEditar.Nombre = upperName;
          _context.SaveChanges();
          return Json(new {returned, categoriaEditar });
        }else{
          _context.Categorias.Add(categoria);
          _context.SaveChanges();
          return Json(new {returned, categoria });
        }
      }
    }catch(Exception e){
      returned = false;
      return Json(new {returned, Error = e.Message });
    }
  }
}
