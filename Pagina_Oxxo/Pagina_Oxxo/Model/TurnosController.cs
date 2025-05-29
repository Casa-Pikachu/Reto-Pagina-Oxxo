using Microsoft.AspNetCore.Mvc;
using Pagina_Oxxo.Model;

namespace Pagina_Oxxo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnosController : ControllerBase
    {
        private readonly DataBaseContext _db;

        public TurnosController(DataBaseContext db)
        {
            _db = db;
        }

        [HttpPut("{id_usuario}/{empleado}/{semana}")]
        public IActionResult UpdateTurno(int id_usuario, string empleado, string semana, [FromBody] Turnos turno)
        {
            if (turno == null)
                return BadRequest("Datos de turno inválidos");

            if (!DateTime.TryParse(semana, out DateTime fechaSemana))
                return BadRequest("Formato de fecha inválido");

            turno.semana = fechaSemana;
            turno.empleado = empleado;
            turno.id_usuario = id_usuario;

            var result = _db.updateHorario(id_usuario, empleado, fechaSemana, turno);

            return result is OkResult
                ? Ok(new { success = true, message = "Turno actualizado correctamente" })
                : result;
        }
    }
}
