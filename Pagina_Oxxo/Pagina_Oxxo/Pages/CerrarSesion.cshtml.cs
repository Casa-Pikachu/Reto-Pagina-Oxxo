using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pagina_Oxxo.Pages;

public class CerrarSesionModel : PageModel
{
    public IActionResult OnPost()
    {
        HttpContext.Session.Clear(); // Borra todos los datos de sesión
        return RedirectToPage("/Index"); // Redirige a la página de login o inicio
    }

    public IActionResult OnGet()
    {
        HttpContext.Session.Clear();
        return RedirectToPage("/Index");
    }
}
