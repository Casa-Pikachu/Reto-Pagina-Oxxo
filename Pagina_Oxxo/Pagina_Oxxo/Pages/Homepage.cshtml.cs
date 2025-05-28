using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class HomepageModel : PageModel
{
    private readonly DataBaseContext _context;

    public string mensaje { get; set; }
    public string textTienda_Asesor { get; set; }

    public Usuarios user;
    public List<Anuncios> anuncios = new List<Anuncios>();
    public List<Usuarios> top3 = new List<Usuarios>();
    public List<Recompensas> recompensas = new List<Recompensas>();
    public Usuarios asesor;

    public HomepageModel(DataBaseContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        int? userId = HttpContext.Session.GetInt32("id_usuario");
        if (userId.HasValue)
        {
            user = _context.GetUserInfo(HttpContext.Session.GetString("nombre"), HttpContext.Session.GetString("apellido"));
            anuncios = _context.GetAnuncios(HttpContext.Session.GetString("nombre"), HttpContext.Session.GetString("apellido"));
            top3 = _context.GetTop3();
            recompensas = _context.GetRecompensas();
            asesor = _context.GetAsesor(user.id_tienda);
            textTienda_Asesor = tienda_asesor();
            mensaje = "Bienvenido, " + HttpContext.Session.GetString("username");
        }
        else
        {
            Response.Redirect("Index");
        }
    }
    
    public string tienda_asesor()
    {
        if (user.id_tienda == 1)
        {
            return "Monterrey";
        }
        else if (user.id_tienda == 2)
        {
            return "San Nicolás";
        }
        else if (user.id_tienda == 3)
        {
            return "San Pedro";
        }
        else if (user.id_tienda == 4)
        {
            return "Guadalupe";
        }
        else if (user.id_tienda == 5)
        {
            return "Santa Catarina";
        }
        return "Tienda no encontrada";
    }

    
}
