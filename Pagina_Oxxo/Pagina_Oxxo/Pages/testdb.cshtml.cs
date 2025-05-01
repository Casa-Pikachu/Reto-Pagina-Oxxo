using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class testdbModel : PageModel{
    private readonly DataBaseContext _context;
    public List<Usuarios> ListaUsuarios{get; set;}

    public testdbModel(DataBaseContext context){
        _context = context;
    }

    // Crea una lista vacia cuando inicia la pagina
    public void OnGet(){
        ListaUsuarios = new List<Usuarios>();  
    }

    // Cuando se presiona el botón
    public void OnPost(){
        ListaUsuarios = _context.GetAllUsers();  
    }
}
