using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;
using MySql.Data.MySqlClient;

namespace Pagina_Oxxo.Pages
{
    public class TurnosModel : PageModel
    {
        private readonly DataBaseContext db = new();
        public List<Turnos> TurnosLista { get; set; } = new();
        public List<DateTime> FechasUnicas { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public DateTime SemanaSeleccionada { get; set; }

        public int id_usuario;

        public void OnGet()
        {
            id_usuario = HttpContext.Session.GetInt32("id_usuario") ?? 0;
            FechasUnicas = db.GetSemanasDisponibles(id_usuario);

            if (SemanaSeleccionada == DateTime.MinValue)
            {
                TurnosLista = new List<Turnos>();
                return;
            }
            TurnosLista = db.getHorarios(SemanaSeleccionada, id_usuario).ToList();
        }
    }
}
