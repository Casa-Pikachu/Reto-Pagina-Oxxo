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
            Console.WriteLine($"UpdateTurno llamado:");
            Console.WriteLine($"ID Usuario: {id_usuario}");
            Console.WriteLine($"Empleado: '{empleado}'");
            Console.WriteLine($"Semana: '{semana}'");
            Console.WriteLine($"Turno recibido: {turno != null}");

            if (turno == null)
            {
                Console.WriteLine("Turno es null");
                return BadRequest("Datos de turno inválidos");
            }

            if (!DateTime.TryParse(semana, out DateTime fechaSemana))
            {
                Console.WriteLine($"Error parsing fecha: {semana}");
                return BadRequest("Formato de fecha inválido");
            }

            Console.WriteLine($"   Fecha parseada: {fechaSemana:yyyy-MM-dd}");
            Console.WriteLine($"   Días: L={turno.lunes}, M={turno.martes}, X={turno.miercoles}, J={turno.jueves}, V={turno.viernes}, S={turno.sabado}, D={turno.domingo}");

            // Asignar valores adicionales al objeto turno
            turno.semana = fechaSemana;
            turno.empleado = empleado;
            turno.id_usuario = id_usuario;

            var result = _db.updateHorario(id_usuario, empleado, fechaSemana, turno);

            if (result is OkResult)
            {
                Console.WriteLine("Actualización exitosa");
                return Ok(new { success = true, message = "Turno actualizado correctamente" });
            }

            Console.WriteLine($"Error en actualización: {result?.GetType().Name}");
            return result;
        }
        
        
    }
}