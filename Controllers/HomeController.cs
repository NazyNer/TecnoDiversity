using System.Diagnostics;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TecnoDiversity.Data;
using TecnoDiversity.Models;
using TecnoDiversity.Utils;


namespace TecnoDiversity.Controllers;

public class HomeController : Controller
{
    const int CantidadDeRoles = 3;
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly RoleManager<IdentityRole> _rolManager;
    private readonly IEmailSender _emailSender;
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, RoleManager<IdentityRole> rolManager, UserManager<IdentityUser> userManager, IEmailSender emailSender)
    {
        _logger = logger;
        _context = context;
        _rolManager = rolManager;
        _emailSender = emailSender;
    }

    public async Task<JsonResult> CargarRolesDb()
    {
        try{
            var RolAdmin = _context.Roles.SingleOrDefault(r => r.Name == "Administrador");
            if (RolAdmin == null){
                var roleResult = await _rolManager.CreateAsync(new IdentityRole("Administrador"));
            }
            var RolUsuario = _context.Roles.SingleOrDefault(r => r.Name == "Usuario");
            if (RolUsuario == null){
                var roleResult = await _rolManager.CreateAsync(new IdentityRole("Usuario"));
            }
            var RolCaja = _context.Roles.SingleOrDefault(r => r.Name == "Caja");
            if (RolCaja == null){
                var roleResult = await _rolManager.CreateAsync(new IdentityRole("Caja"));
            }
            var ConfirmarRoles = _context.Roles.Count();
            if (ConfirmarRoles == CantidadDeRoles)
            {
                return Json(true);
            }
        }catch(Exception e){
            return Json(false, e);
        }
        return Json(false);
    }

    public async Task<IActionResult> Index()
    {
        var ConfirmarRoles = _context.Roles.ToList().Count;
        if (ConfirmarRoles != CantidadDeRoles)
        {
            await CargarRolesDb();
        }

        var receiver = "nemaldonado663@gmail.com";
        var subject = "Prueba de correo";
        var message = "Hola, este es un correo de prueba";
        
        await _emailSender.SendEmailAsync(receiver, subject, message);

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
