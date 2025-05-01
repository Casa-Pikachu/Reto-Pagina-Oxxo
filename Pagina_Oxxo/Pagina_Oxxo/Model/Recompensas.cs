using System;

namespace Pagina_Oxxo.Model{
    public class Recompensas{
        public int id_recompensa {get;set;}
        public string nombre_recompensa {get;set;}
        public string descripcion_recompensa {get;set;}
        public int precio_recompensa {get;set;}

        public Recompensas(int id_recompensa_,string nombre_recompensa_,string descripcion_recompensa_,int precio_recompensa_){
            id_recompensa = id_recompensa_;
            nombre_recompensa = nombre_recompensa_;
            descripcion_recompensa = descripcion_recompensa_;
            precio_recompensa = precio_recompensa_;
        }

        public Recompensas(){}
    }
}