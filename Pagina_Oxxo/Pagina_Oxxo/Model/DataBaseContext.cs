using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Pagina_Oxxo.Model{
    public class DataBaseContext{
        public string ConnectionString {get; set;}

        public DataBaseContext(){
            // DB local Bruno
            ConnectionString = "Server=127.0.0.1;Port=3306;Database=reto_oxxo;Uid=root;";
        }

        private MySqlConnection GetConnection(){
            return new MySqlConnection(ConnectionString);
        }

        // Funcion para obtener todos los usuarios
        public List<Usuarios> GetAllUsers(){
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS", conexion);

            Usuarios usr1;
            
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    usr1 = new Usuarios();
                    
                    usr1.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usr1.nombre = reader["nombre"].ToString();
                    usr1.apellido = reader["apellido"].ToString();
                    usr1.correo = reader["correo"].ToString();
                    usr1.contrasena = reader["contrasena"].ToString();
                    usr1.monedas = Convert.ToInt32(reader["monedas"]);
                    usr1.experiencia = Convert.ToInt32(reader["experiencia"]);
                    usr1.puntos = Convert.ToInt32(reader["puntos"]);
                    usr1.id_rol = Convert.ToInt32(reader["id_rol"]);
                    usr1.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                    
                    ListaUsuarios.Add(usr1);
                }
            }

            conexion.Close();
            return ListaUsuarios;
        }

        // Funcion para obtener la informacion de un usuario en partcular
        public Usuarios GetUserInfo(string nombre, string apellido){
            Usuarios user = new Usuarios();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE nombre = \"{nombre}\" AND apellido = \"{apellido}\"", conexion);

            
            using(var reader = cmd.ExecuteReader()){
                if(reader.Read()){
                    user.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    user.nombre = reader["nombre"].ToString();
                    user.apellido = reader["apellido"].ToString();
                    user.correo = reader["correo"].ToString();
                    user.contrasena = reader["contrasena"].ToString();
                    user.monedas = Convert.ToInt32(reader["monedas"]);
                    user.experiencia = Convert.ToInt32(reader["experiencia"]);
                    user.puntos = Convert.ToInt32(reader["puntos"]);
                    user.id_rol = Convert.ToInt32(reader["id_rol"]);
                    user.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                }
            }

            conexion.Close();
            return user;
        }

        public Usuarios GetAsesor(int id_tienda){
            Usuarios user = new Usuarios();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE id_tienda = {id_tienda} AND id_rol = 1", conexion);

            using(var reader = cmd.ExecuteReader()){
                if(reader.Read()){
                    user.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    user.nombre = reader["nombre"].ToString();
                    user.apellido = reader["apellido"].ToString();
                    user.correo = reader["correo"].ToString();
                    user.contrasena = reader["contrasena"].ToString();
                    user.monedas = Convert.ToInt32(reader["monedas"]);
                    user.experiencia = Convert.ToInt32(reader["experiencia"]);
                    user.puntos = Convert.ToInt32(reader["puntos"]);
                    user.id_rol = Convert.ToInt32(reader["id_rol"]);
                    user.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                }
            }

            conexion.Close();
            return user;
        }

        public List<Anuncios> GetAnuncios(string nombre, string apellido){
            List<Anuncios> ListaAnuncios = new List<Anuncios>();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM ANUNCIOS WHERE id_usuario = (SELECT id_usuario FROM USUARIOS WHERE nombre = \"{nombre}\" AND apellido = \"{apellido}\")", conexion);

            Anuncios anuncio;
            
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    anuncio = new Anuncios();
                    
                    anuncio.id_anuncio = Convert.ToInt32(reader["id_anuncio"]);
                    anuncio.contenido = reader["contenido"].ToString();
                    anuncio.fecha_anuncio = Convert.ToDateTime(reader["fecha_anuncio"]).ToString("dd/MM/yyyy");
                    anuncio.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                                        
                    ListaAnuncios.Add(anuncio);
                }
            }

            conexion.Close();
            return ListaAnuncios;
        }

        public List<Usuarios> GetTop3(){
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS ORDER BY experiencia DESC LIMIT 3", conexion);

            Usuarios usr1;
            
            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    usr1 = new Usuarios();
                    
                    usr1.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usr1.nombre = reader["nombre"].ToString();
                    usr1.apellido = reader["apellido"].ToString();
                    usr1.correo = reader["correo"].ToString();
                    usr1.contrasena = reader["contrasena"].ToString();
                    usr1.monedas = Convert.ToInt32(reader["monedas"]);
                    usr1.experiencia = Convert.ToInt32(reader["experiencia"]);
                    usr1.puntos = Convert.ToInt32(reader["puntos"]);
                    usr1.id_rol = Convert.ToInt32(reader["id_rol"]);
                    usr1.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                    
                    ListaUsuarios.Add(usr1);
                }
            }

            conexion.Close();
            return ListaUsuarios;
        }

        // Devuelve los primeros 3 items de la tienda
        public List<Recompensas> GetRecompensas(){
            List<Recompensas> ListaItems = new List<Recompensas>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM RECOMPENSAS LIMIT 3", conexion);

            Recompensas item;

            using(var reader = cmd.ExecuteReader()){
                while(reader.Read()){
                    item = new Recompensas();

                    item.id_recompensa = Convert.ToInt32(reader["id_recompensa"]);
                    item.nombre_recompensa = reader["nombre_recompensa"].ToString();
                    item.descripcion_recompensa = reader["descripcion_recompensa"].ToString();
                    item.precio_recompensa = Convert.ToInt32(reader["precio_recompensa"]);

                    ListaItems.Add(item);
                }
            }

            conexion.Close();

            return ListaItems;
        }


        //Obtener una lista para obtener los lugares del 4to en adelante
        public List<Podios> GetElse(){
            List<Podios> PodioUsuarios = new List<Podios>();
            //lista vacía
        
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            //conectar a base de datos
            

            string query = @"
                    SELECT nombre, apellido, puntaje
                    FROM (
                        SELECT 
                            u.nombre, 
                            u.apellido, 
                            r.puntaje,
                            ROW_NUMBER() OVER (ORDER BY r.puntaje DESC) AS posicion
                        FROM usuarios u
                        JOIN ranking r ON u.id_usuario = r.id_usuario
                    ) AS sub  
                    WHERE posicion >= 4;";
        

                    /*se realiza una consulta sql 
                    se seleccionan los parametros de las tablas usuarios y ranking, para esto es necesario
                    unirlas con JOIN por medio de lo que tienen su PK y FK, que es el id de usuario. 

                    para obtener la posicion se hizo un row_number que saca el numero de fila una vez 
                    que se ordena de mayor a menor. Todo esto queda dentro de una subconsulta 
                    en la que luego se puede hacer la consulta en la que se elige el rango que se desea. 
                    */
                    

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //nuevo objeto para agregar los valores 
                    Podios usrpod = new Podios
                    {
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        puntaje = Convert.ToInt32(reader["puntaje"])
                        
                    };

                    PodioUsuarios.Add(usrpod);
                    //se le agrega
                
                }
            }

            conexion.Close();

            return PodioUsuarios;
        }


        //Obtener el medallero (cada lugar individual para ponerlo en las tarjetas)
        public Podios GetLugarMedalla(int posicion){

            //no es lista asi que pues nada mas se inicia como null
                    Podios resultado = null;
                    
                    MySqlConnection conexion = GetConnection();
                    conexion.Open();
                    //$ porque salia error 
                    string query = $@"
                            SELECT nombre, apellido, puntaje
                FROM (
                    SELECT 
                        u.nombre, 
                        u.apellido, 
                        r.puntaje,
                        ROW_NUMBER() OVER (ORDER BY r.puntaje DESC) AS posicion
                    FROM usuarios u
                    JOIN ranking r ON u.id_usuario = r.id_usuario
                ) AS sub  
                WHERE posicion = {posicion};";


                /*se realiza una consulta sql, muy parecida a la anterior con unos cambios.
                se seleccionan los parametros de las tablas usuarios y ranking, para esto es necesario
                unirlas con JOIN por medio de lo que tienen su PK y FK, que es el id de usuario. 

                para obtener la posicion se hizo un row_number que saca el numero de fila una vez 
                que se ordena de mayor a menor. Todo esto queda dentro de una subconsulta 
                en la que luego se puede hacer la consulta se pone la variable que se desea. Por ejemplo 
                ganador se usa la posicion 1.  
                */

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())

                    //objeto para agregar valores
                    resultado = new Podios
                        {
                            nombre = reader["nombre"].ToString(),
                            apellido = reader["apellido"].ToString(),
                            puntaje = Convert.ToInt32(reader["puntaje"])
                            
                        };
            }

            conexion.Close();

            return resultado; 
        }

        public Ranking GetRanking(int id_usuario_){
            Ranking rank = new Ranking();

            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand rk = new MySqlCommand($"SELECT * FROM Ranking where id_usuario = {id_usuario_} AND id_usuario = 3", conexion);

            using(var reader = rk.ExecuteReader()){
                if(reader.Read()){
                    

                    rank.id_ranking = Convert.ToInt32(reader["id_ranking"]);
                    rank.puntaje = Convert.ToInt32(reader["puntaje"]);
                    rank.fecha_puntaje = reader["fecha_puntaje"].ToString();
                    rank.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    rank.id_minijuego = Convert.ToInt32(reader["id_minijuego"]);
                }
            }
            
            conexion.Close();
            return rank;
        }

        public Usuarios GetUserId(int id_usuario){
            Usuarios usuario = new Usuarios();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE id_usuario = {id_usuario} AND id_usuario = 3", conexion);

            
            using(var reader = cmd.ExecuteReader()){
                if(reader.Read()){
                    usuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.correo = reader["correo"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                    usuario.monedas = Convert.ToInt32(reader["monedas"]);
                    usuario.experiencia = Convert.ToInt32(reader["experiencia"]);
                    usuario.puntos = Convert.ToInt32(reader["puntos"]);
                    usuario.id_rol = Convert.ToInt32(reader["id_rol"]);
                    usuario.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                }
            }

            conexion.Close();
            return usuario;
        }

    }
}
