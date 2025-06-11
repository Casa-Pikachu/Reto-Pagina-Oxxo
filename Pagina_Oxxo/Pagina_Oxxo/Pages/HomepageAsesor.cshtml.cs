using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class HomepageAsesorModel : PageModel
{
    private readonly DataBaseContext _context;

    public string mensaje { get; set; }
    public string mensaje1 { get; set; }

    public Usuarios user;
    public List<Anuncios> anuncios = new List<Anuncios>();
    public List<Usuarios> top3 = new List<Usuarios>();
    public List<Recompensas> recompensas = new List<Recompensas>();
    public Usuarios asesor;

    public List<Usuarios> usuariosTienda = new List<Usuarios>();


    public HomepageAsesorModel(DataBaseContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("id_usuario");

        int idTienda = HttpContext.Session.GetInt32("id_tienda") ?? 0;
        if (userId == null)
        {
            Response.Redirect("Index");
        }

        else
        {
            user = _context.GetUserInfo(userId.Value);
            top3 = _context.GetTop3();
            recompensas = _context.GetRecompensas();
            mensaje = "Bienvenido, " + HttpContext.Session.GetString("username");
            usuariosTienda = _context.GetAllUsersByTienda(idTienda, HttpContext.Session.GetInt32("id_usuario") ?? 0);
        }
    }

    public IActionResult OnPost()
    {
        string receptorStr = Request.Form["usuarioSelect"];
        string contenido = Request.Form["contenidoAnuncio"];

        if (string.IsNullOrEmpty(receptorStr) || string.IsNullOrEmpty(contenido))
        {
            TempData["MensajeFalta"] = "No deje los campos vacíos";
            return RedirectToPage("/HomepageAsesor");
        }

        if (!int.TryParse(receptorStr, out int receptor) || receptor == 0)
        {
            TempData["MensajeFalta"] = "Debe seleccionar un usuario válido.";
            return RedirectToPage("/HomepageAsesor");
        }

        _context.InsertarAnuncio(contenido, receptor);
        TempData["MensajeExito"] = "Anuncio enviado correctamente!";
        return RedirectToPage("/HomepageAsesor");
} 
    
    
    

    
}
