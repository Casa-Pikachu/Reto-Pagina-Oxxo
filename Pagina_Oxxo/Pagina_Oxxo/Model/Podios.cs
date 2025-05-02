using System;


//no borrar esta clase

namespace Pagina_Oxxo.Model{
    public class Podios{
        public int id_usuario {get;set;}
        public string nombre {get;set;}
        public string apellido {get;set;}
        public int puntaje {get;set;}

        public Podios(int id_usuario_,string nombre_,string apellido_,int puntaje_){
            id_usuario = id_usuario_;
            nombre = nombre_;
            apellido = apellido_;
            puntaje = puntaje_;
            
        }

        public Podios(){}
    }
}