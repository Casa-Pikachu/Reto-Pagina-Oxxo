using System;

namespace Pagina_Oxxo.Model{

    public class Reconocimientos{
        public int id_reconocimientos {get;set;}
        public string contenido {get;set;}
        public string fecha_mensaje {get;set;}
        public string transmisor { get; set; }
        public int id_icono { get; set; }
        public int id_usuario { get; set; }

        public Reconocimientos(int id_reconocimientos_,string contenido_,string fecha_mensaje_, string transmisor_, int id_icono_, int id_usuario_){
            id_reconocimientos = id_reconocimientos_;
            contenido = contenido_;
            fecha_mensaje = fecha_mensaje_;
            transmisor = transmisor_;
            id_icono = id_icono_;
            id_usuario = id_usuario_;
        }

        public Reconocimientos(){}
    }
}