using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class PerfilModel : PageModel
{
     [BindProperty] //Conexión entre base de datos
    public string fotoP { get; set;} 
    [BindProperty]
    public string camino { get; set;}


    private readonly DataBaseContext _context;
    public List<Usuarios> usuarioLista = new List<Usuarios>(); 
    public Usuarios usuario;
    public List<Ranking> usuarioRanking = new List<Ranking>(); 
    
    public Ranking ranking;

    //constructor para poder usar los metodos
    public PerfilModel(DataBaseContext context) 
    {
        _context = context;
    }

    public void OnGet() 
    { 
        //Conexión a base de datos
        int? userId = HttpContext.Session.GetInt32("id_usuario");
        if (userId.HasValue)
    {
        usuario = _context.GetUserId(userId.Value);
        ranking = _context.GetRanking(userId.Value);
        camino = "~/imagen/Oxxo.png";
    }
    else
    {
        Response.Redirect("Index");
    }
        
    }

    public void OnPost()
{
    int? userId = HttpContext.Session.GetInt32("id_usuario");
    if (userId.HasValue)
    {
        usuario = _context.GetUserId(userId.Value);
        ranking = _context.GetRanking(userId.Value);
        camino = $"~/imagen/{fotoP}";
    }
    else
    {
        Response.Redirect("Index");
    }
}
}



