using System;

namespace Pagina_Oxxo.Model{

    public class Anuncios{
        public int id_anuncio {get;set;}
        public string contenido {get;set;}
        public string fecha_anuncio {get;set;}
        public int id_usuario {get;set;}

        public Anuncios(int id_anuncio_,string contenido_,string _fecha_anuncio,int id_usuario_){
            id_anuncio = id_anuncio_;
            contenido = contenido_;
            fecha_anuncio = _fecha_anuncio;
            id_usuario = id_usuario_;
        }

        public Anuncios(){}
    }
}