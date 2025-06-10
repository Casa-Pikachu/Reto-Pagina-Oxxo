using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Pages
{
    public class PodioModel : PageModel
    {
        private readonly DataBaseContext _context;

        // Propiedades públicas para acceder desde la vista
        public List<Podios> ListaUsuarios { get; set; }
        public Podios PrimerLugar { get; set; }
        public Podios SegundoLugar { get; set; }
        public Podios TercerLugar { get; set; }

        // Constructor que inicializa la conexión
        public PodioModel()
        {
            _context = new DataBaseContext();
        }

        // Se ejecuta al cargar la página
        public void OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("id_usuario");
            if (userId != null)
            {
                // Obtiene los datos del podio y los usuarios
                PrimerLugar = _context.GetLugarMedalla(1);
                SegundoLugar = _context.GetLugarMedalla(2);
                TercerLugar = _context.GetLugarMedalla(3);
                ListaUsuarios = _context.GetElse();
            }
            else
            {
                Response.Redirect("Index");
            }
            
            
        }
    }
}

