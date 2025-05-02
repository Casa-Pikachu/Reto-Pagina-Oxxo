using System;

namespace Pagina_Oxxo.Model{
    public class Ranking{
        public int id_ranking {get;set;}
        public int puntaje {get;set;}
        public string fecha_puntaje {get;set;}

        public int id_usuario {get;set;}
        public int id_minijuego {get;set;}

        public Ranking(int id_ranking_,int puntaje_,string _fecha_puntaje,int id_usuario_,int id_minijuego_){
            id_ranking = id_ranking_;
            puntaje = puntaje_;
            fecha_puntaje = _fecha_puntaje;
            id_usuario = id_usuario_;
            id_minijuego = id_minijuego_;
        }

        public Ranking(){}
    }
}