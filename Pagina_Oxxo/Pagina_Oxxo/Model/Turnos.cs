using System;

namespace Pagina_Oxxo.Model
{
    public class Turnos
    {
        public int id_turnos { get; set; }
        public DateTime semana { get; set; }
        public string empleado { get; set; }
        public string horario { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
        public int id_usuario { get; set; }

        public Turnos(int id_turnos_, DateTime semana_, string empleado_, string horario_, bool lunes_, bool martes_, bool miercoles_, bool jueves_, bool viernes_, bool sabado_, bool domingo_, int id_usuario_)
        {
            id_turnos = id_turnos_;
            semana = semana_;
            empleado = empleado_;
            horario = horario_;
            lunes = lunes_;
            martes = martes_;
            miercoles = miercoles_;
            jueves = jueves_;
            viernes = viernes_;
            sabado = sabado_;
            domingo = domingo_;
            id_usuario = id_usuario_;
        }

        public Turnos(){}
    }

}