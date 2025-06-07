using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class RecomModel : PageModel
{
    
    private readonly DataBaseContext _context;
    public List<Reconocimientos> reconocimientos = new List<Reconocimientos>();
    

    public RecomModel(DataBaseContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        reconocimientos = _context.GetReconocimientos(HttpContext.Session.GetString("nombre"), HttpContext.Session.GetString("apellido"));

    }
    
    

    
}
