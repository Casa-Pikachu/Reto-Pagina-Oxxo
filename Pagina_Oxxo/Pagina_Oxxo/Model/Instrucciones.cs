using System;

namespace Pagina_Oxxo.Model{
    public class Instrucciones
    {
        public int id_instruccion { get; set; }
        public string titulo_instruccion { get; set; }
        public string descripcion_instruccion { get; set; }

        public Instrucciones(int id_instruccion_, string titulo_instruccion_, string descripcion_instruccion_)
        {
            id_instruccion = id_instruccion_;
            titulo_instruccion = titulo_instruccion_;
            descripcion_instruccion = descripcion_instruccion_;
        }

        public Instrucciones() { }
    }
}