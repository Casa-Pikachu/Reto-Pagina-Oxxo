using System;

namespace Pagina_Oxxo.Model{
    public class Ranking{
        public int id_ranking {get;set;}
        public int puntaje {get;set;}
        public int id_usuario {get;set;}
        public int id_minijuego {get;set;}

        public Ranking(int id_ranking_,int puntaje_,int id_usuario_,int id_minijuego_){
            this.id_ranking = id_ranking_;
            this.puntaje = puntaje_;
            this.id_usuario = id_usuario_;
            this.id_minijuego = id_minijuego_;
        }

        public Ranking(){}
    }
}