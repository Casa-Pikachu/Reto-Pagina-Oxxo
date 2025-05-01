using System;

namespace Pagina_Oxxo.Model{
    public class Minijuegos{
        public int id_minijuego {get;set;}
        public string nombre_minijuego {get;set;}

        public Minijuegos(int id_minijuego_,string nombre_minijuego_){
            id_minijuego = id_minijuego_;
            nombre_minijuego = nombre_minijuego_;
        }

        public Minijuegos(){}
    }
}