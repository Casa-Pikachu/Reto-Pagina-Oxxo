using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class RecomModel : PageModel
{

    private readonly DataBaseContext _context;
    public List<Reconocimientos> reconocimientos = new List<Reconocimientos>();
    public List<Usuarios> usuariosTienda = new List<Usuarios>();


    public RecomModel(DataBaseContext context)
    {
        _context = context;
    }



    public void OnGet()
    {
        int idTienda = HttpContext.Session.GetInt32("id_tienda") ?? 0;
        usuariosTienda = _context.GetAllUsersByTienda(idTienda, HttpContext.Session.GetInt32("id_usuario") ?? 0);
        reconocimientos = _context.GetReconocimientos(HttpContext.Session.GetString("nombre"), HttpContext.Session.GetString("apellido"));

        

    }

    public IActionResult OnPost()
    {
        int usuarioSelectId = HttpContext.Session.GetInt32("id_usuario") ?? 0;

        if (usuarioSelectId == 0)
        {
            TempData["MensajeFalta"] = "Debe iniciar sesión para enviar reconocimientos.";
            return RedirectToPage("/Login");  // O donde corresponda
        }

        string receptorStr = Request.Form["usuarioSelect"];
        string contenido = Request.Form["contenidoMedalla"];
        string idIconoStr = Request.Form["medallaSelect"];

        if (string.IsNullOrEmpty(receptorStr) || string.IsNullOrEmpty(contenido) || string.IsNullOrEmpty(idIconoStr))
        {
            TempData["MensajeFalta"] = "No deje los campos vacíos.";
            return RedirectToPage("/Recom");
        }

        if (!int.TryParse(receptorStr, out int receptor) || !int.TryParse(idIconoStr, out int id_icono))
        {
            TempData["MensajeFalta"] = "Por favor seleccione un usuario y medalla válidos.";
            return RedirectToPage("/Recom");
        }

        string transmisor = GetUsuarioIDForms(usuarioSelectId);

        _context.InsertarReconocimiento(transmisor, contenido, id_icono, receptor);

        TempData["MensajeExito"] = "¡Medalla enviada correctamente!";
        return RedirectToPage("/Recom");
    }

    
    public string GetUsuarioIDForms(int id_usuario)
    {
        var usuario = _context.GetUserId(id_usuario);
        return usuario.nombre + " " + usuario.apellido; 
    }
}
