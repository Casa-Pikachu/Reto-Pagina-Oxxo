using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class IndexModel : PageModel{
    private readonly DataBaseContext _context;
    public Usuarios user;
    public List<Anuncios> anuncios = new List<Anuncios>();
    public List<Usuarios> top3 = new List<Usuarios>();
    public List<Recompensas> recompensas = new List<Recompensas>();

    public IndexModel(DataBaseContext context){
        _context = context;
    }

    public void OnGet(){
        user = _context.GetUserInfo("Bruno", "Zabala");
        anuncios = _context.GetAnuncios("Bruno", "Zabala");
        top3 = _context.GetTop3();
        recompensas = _context.GetRecompensas();
    }
}
