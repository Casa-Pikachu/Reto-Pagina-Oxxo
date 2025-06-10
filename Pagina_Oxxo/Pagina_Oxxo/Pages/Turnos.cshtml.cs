using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pagina_Oxxo.Model;
using System.Collections.Generic;
using System.Linq;

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

        [BindProperty]
        public List<Turnos> TurnosActualizados { get; set; } = new();

        public void OnGet()
        {
            id_usuario = HttpContext.Session.GetInt32("id_usuario") ?? 0;
            FechasUnicas = db.GetSemanasDisponibles(id_usuario);

            if (SemanaSeleccionada == DateTime.MinValue)
            {
                TurnosLista = new List<Turnos>();
                TurnosActualizados = new List<Turnos>();
                return;
            }

            TurnosLista = db.getHorarios(SemanaSeleccionada, id_usuario).ToList();

            // Clonar TurnosLista en TurnosActualizados para el binding
            TurnosActualizados = TurnosLista
                .Select(t => new Turnos
                {
                    empleado = t.empleado,
                    horario = t.horario,
                    lunes = t.lunes,
                    martes = t.martes,
                    miercoles = t.miercoles,
                    jueves = t.jueves,
                    viernes = t.viernes,
                    sabado = t.sabado,
                    domingo = t.domingo
                })
                .ToList();
        }

        public IActionResult OnPost()
        {
            id_usuario = HttpContext.Session.GetInt32("id_usuario") ?? 0;

            if (SemanaSeleccionada == DateTime.MinValue || TurnosActualizados.Count == 0)
                return Page();

            foreach (var turno in TurnosActualizados)
            {
                turno.semana = SemanaSeleccionada;
                turno.id_usuario = id_usuario;

                db.updateHorario(id_usuario, turno.empleado, SemanaSeleccionada, turno);
            }

            // Volver a cargar datos actualizados
            TurnosLista = db.getHorarios(SemanaSeleccionada, id_usuario).ToList();
            FechasUnicas = db.GetSemanasDisponibles(id_usuario);

            // Volver a sincronizar para evitar errores de binding en siguiente renderizado
            TurnosActualizados = TurnosLista
                .Select(t => new Turnos
                {
                    empleado = t.empleado,
                    horario = t.horario,
                    lunes = t.lunes,
                    martes = t.martes,
                    miercoles = t.miercoles,
                    jueves = t.jueves,
                    viernes = t.viernes,
                    sabado = t.sabado,
                    domingo = t.domingo
                })
                .ToList();

            return Page();
        }
    }
}
