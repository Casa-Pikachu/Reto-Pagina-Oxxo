using System;

namespace Pagina_Oxxo.Model{

    public class Anuncios{
        public int id_anuncio {get;set;}
        public string contenido {get;set;}
        public int id_usuario {get;set;}

        public Anuncios(int id_anuncio_,string contenido_,int id_usuario_){
            id_anuncio = id_anuncio_;
            contenido = contenido_;
            id_usuario = id_usuario_;
        }

        public Anuncios(){}
    }
}