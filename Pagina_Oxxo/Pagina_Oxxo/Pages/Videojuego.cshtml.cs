using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class VideojuegoModel : PageModel
{
    private readonly DataBaseContext _context;

    public List<Instrucciones> listaHistoria { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaPersonajes { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaPrincipal { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaMinijuego { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaLicencias { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaFuentes { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaSprites { get; set; } = new List<Instrucciones>();
    public List<Instrucciones> listaCreditos { get; set; } = new List<Instrucciones>();


    public VideojuegoModel(DataBaseContext context)
    {
        _context = context;
    }


    public void OnGet()
    {
        if (HttpContext.Session.GetInt32("id_usuario") == null)
        {
            Response.Redirect("Index");
            return;
        }

        else
        {
            listaHistoria = _context.GetInstruction("Historia");
            listaPersonajes = _context.GetInstruction("Personajes");
            listaPrincipal = _context.GetInstruction("Pantalla principal");
            listaMinijuego = _context.GetInstruction("Minijuegos");
            listaLicencias = _context.GetInstruction("Licencias");
            listaFuentes = _context.GetInstruction("Fuentes");
            listaSprites = _context.GetInstruction("Sprites");
            listaCreditos = _context.GetInstruction("Creditos");
        }
    }
}
