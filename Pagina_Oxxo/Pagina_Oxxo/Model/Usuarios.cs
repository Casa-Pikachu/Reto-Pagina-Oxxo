using System;

namespace Pagina_Oxxo.Model{
    public class Usuarios{
        public int id_usuario {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string correo {get;set;}
        public string contrasena {get;set;}
        public int monedas {get;set;}
        public int id_rol {get;set;}
        public int id_tienda {get;set;}

        public Usuarios(int id_usuario_,string nombre_,string apellido_,string correo_,string contrasena_,int monedas_,int id_rol_,int id_tienda_){
            this.id_usuario = id_usuario_;
            this.nombre = nombre_;
            this.apellido = apellido_;
            this.correo = correo_;
            this.contrasena = contrasena_;
            this.monedas = monedas_;
            this.id_rol = id_rol_;
            this.id_tienda = id_tienda_;
        }

        public Usuarios(){}
    }
}