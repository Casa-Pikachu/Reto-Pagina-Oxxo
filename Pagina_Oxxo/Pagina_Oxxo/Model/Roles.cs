using System;

namespace Pagina_Oxxo.Model{
    public class Roles{
        public int id_rol {get;set;}
        public string descripcion_rol {get;set;}

        public Roles(int id_rol_,string descripcion_rol_){
            id_rol = id_rol_;
            descripcion_rol = descripcion_rol_;
        }

        public Roles(){}
    }
}