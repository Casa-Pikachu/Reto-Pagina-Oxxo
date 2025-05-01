using System;

namespace Pagina_Oxxo.Model{
    public class Tiendas{
        public int idTienda {get;set;}
        public string ubicacion {get;set;}

        public Tiendas(int idTienda_,string ubicacion_){
            idTienda = idTienda_;
            ubicacion = ubicacion_;
        }

        public Tiendas(){}
    }
}