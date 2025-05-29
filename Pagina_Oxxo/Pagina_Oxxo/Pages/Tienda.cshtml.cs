using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;
using System.Collections.Generic;
using System.Linq;  

namespace Pagina_Oxxo.Pages
{
    public class TiendaModel : PageModel
    {
        private readonly DataBaseContext _context;
        public int MonedasUsuario { get; set; }

        // Lista que almacenará los productos obtenidos
        public List<Recompensas> Recompensas { get; set; }

        // Constructor para inyectar el contexto de base de datos
        public TiendaModel(DataBaseContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Obtener todos los productos de la base de datos
            Recompensas = _context.GetAllRecompensas();
        }

        
    }

}
