using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI.Common;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string email {get;set;}
    
    [BindProperty]
    public string password {get;set;}
    
    public string Mensaje{get; set;}

    private readonly DataBaseContext _context;
    public Usuarios user;
    
    
    public IndexModel(DataBaseContext context)
    {
        _context = context;
    }
    
    public void OnGet()
    {
        Mensaje = "";

    }

    public void OnPost()
    {
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            Mensaje = "No deje los campos vacíos";
            return;
        }
        HttpContext.Session.SetString("email", email);
        HttpContext.Session.SetString("password", password);

        user = _context.CheckUsrId_Password(email, password);

        if (user.correo == null || user.contrasena == null)
        {
            Mensaje = "Usuario o contraseña incorrectos";
        }
        else if (user.correo == "" || user.contrasena == "")
        {
            Mensaje = "No deje los campos vacíos";
        }
        else
        {
            HttpContext.Session.SetString("nombre", user.nombre);
            HttpContext.Session.SetString("apellido", user.apellido);
            HttpContext.Session.SetString("username", user.nombre + " " + user.apellido); 
            HttpContext.Session.SetInt32("id_usuario", user.id_usuario);
            HttpContext.Session.SetInt32("monedas", user.monedas);
            HttpContext.Session.SetInt32("experiencia", user.experiencia);
            HttpContext.Session.SetInt32("puntos", user.puntos);
            HttpContext.Session.SetInt32("id_rol", user.id_rol);
            HttpContext.Session.SetInt32("id_tienda", user.id_tienda);
            Response.Redirect("Homepage");
        }

    }
}
