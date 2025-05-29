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

<<<<<<< Updated upstream
        public int id_usuario;

        public void OnGet()
        {
            id_usuario = HttpContext.Session.GetInt32("id_usuario") ?? 0;
            FechasUnicas = db.GetSemanasDisponibles(id_usuario);

=======
        public int id_usuario = 1;

        public void OnGet()
        {
            FechasUnicas = db.GetSemanasDisponibles(id_usuario);
            
>>>>>>> Stashed changes
            if (SemanaSeleccionada == DateTime.MinValue)
            {
                TurnosLista = new List<Turnos>();
                return;
            }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
            TurnosLista = db.getHorarios(SemanaSeleccionada, id_usuario).ToList();
        }
    }
}
<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
