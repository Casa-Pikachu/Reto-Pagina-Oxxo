using System;

namespace Pagina_Oxxo.Model{
    public class Usuarios{
        public int id_usuario {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public string correo {get;set;}
        public string contrasena {get;set;}
        public int monedas {get;set;}
        public int experiencia {get;set;}
        public int puntos {get;set;}
        public int id_rol {get;set;}
        public int id_tienda {get;set;}

        public Usuarios(int id_usuario_,string nombre_,string apellido_,string correo_,string contrasena_,int monedas_,int experiencia_,int puntos_,int id_rol_,int id_tienda_){
            id_usuario = id_usuario_;
            nombre = nombre_;
            apellido = apellido_;
            correo = correo_;
            contrasena = contrasena_;
            monedas = monedas_;
            experiencia = experiencia_;
            puntos = puntos_;
            id_rol = id_rol_;
            id_tienda = id_tienda_;
        }

        public Usuarios(){}
    }
}