using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class PerfilModel : PageModel
{

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
        usuarioLista = _context.GetAllUsers();
        usuarioRanking = _context.GetRanking();

    }
}



