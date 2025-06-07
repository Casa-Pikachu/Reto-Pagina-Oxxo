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

        if (reconocimientos.Count == 0)
        {
            reconocimientos.Add(new Reconocimientos { mensaje = "No hay reconocimientos disponibles." });
        }

    }

    public void OnPost()
    {
        int usuarioSelectId = HttpContext.Session.GetInt32("id_usuario") ?? 0;

        string transmisor =  GetUsuarioIDForms(usuarioSelectId); //ID del usuario que envía el reconocimiento
        int receptor = int.Parse(Request.Form["usuarioSelect"]);//ID del usuario que recibe el reconocimiento
        string contenido = Request.Form["contenidoMedalla"];
        int id_icono = int.Parse(Request.Form["medallaSelect"]);


        _context.InsertarReconocimiento(transmisor, contenido, id_icono, receptor);
        Response.Redirect("/Recom");


    }
    
    public string GetUsuarioIDForms(int id_usuario)
    {
        var usuario = _context.GetUserId(id_usuario);
        return usuario.nombre + " " + usuario.apellido; 
    }
}
