using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;  

namespace Pagina_Oxxo.Pages
{
    public class TiendaModel : PageModel
    {
        private readonly DataBaseContext _context;
        public int MonedasUsuario { get; set; }
        // Lista que almacenará los productos obtenidos
        public List<Recompensas> Recompensas { get; set; }
        public int id_usuario;
        public int monedasAmmount;

        // Constructor para inyectar el contexto de base de datos
        public TiendaModel(DataBaseContext context)
        {
            _context = context;
        }

        
        public void OnGet()
        {
            if (HttpContext.Session.GetInt32("id_usuario") is int id)
            {
                id_usuario = id;
                monedasAmmount = _context.GetMonedasUsuario(id_usuario);
                Recompensas = _context.GetRecompensasConEstadoCompra(id_usuario);
            }
            else
            {
                id_usuario = 0;
                monedasAmmount = 0;
                Recompensas = new List<Recompensas>();
            }
        }


        
    }

}
