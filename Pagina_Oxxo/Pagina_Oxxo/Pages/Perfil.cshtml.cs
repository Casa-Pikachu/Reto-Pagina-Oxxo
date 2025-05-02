using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class PerfilModel : PageModel
{
     [BindProperty] //Conexión entre base de datos
    public string fotoP { get; set;} 
    [BindProperty]
    public string camino { get; set; }


    private readonly DataBaseContext _context;
    public List<Usuarios> usuarioLista { get; set;} 
    public List<Ranking> usuarioRanking {set;get;}

    //constructor para poder usar los metodos
    public PerfilModel(DataBaseContext context) 
    {
        _context = context;
    }

    public void OnGet() 
    { 
        //Conexión a base de datos
        usuarioLista = _context.GetAllUsers();
        usuarioRanking = _context.GetRanking();

        camino = "~/imagen/Oxxo.png";
    }

    public void OnPost()
    {
        //Se vuelven a cargar los datos al hacer post
        usuarioLista = _context.GetAllUsers();
        usuarioRanking = _context.GetRanking();

        //se enlaza el camino para llegar a la imagen y su nombre
        camino = $"~/imagen/{fotoP}";
    }
}



