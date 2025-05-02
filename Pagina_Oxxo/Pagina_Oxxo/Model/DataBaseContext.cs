using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Pagina_Oxxo.Model{
    public class DataBaseContext{
        public string ConnectionString {get; set;}

        public DataBaseContext(){
            // DB local Bruno
            ConnectionString = "Server=127.0.0.1;Port=3306;Database=reto_oxxo;Uid=root;password=BigDipper11*";
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

            public List<Ranking> GetRanking(){
            List<Ranking> ListaRank = new List<Ranking>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand rk = new MySqlCommand("SELECT * FROM Ranking", conexion);

            Ranking rank;

            using(var reader = rk.ExecuteReader()){
                while(reader.Read()){
                    rank = new Ranking();

                    rank.id_ranking = Convert.ToInt32(reader["id_ranking"]);
                    rank.puntaje = Convert.ToInt32(reader["puntaje"]);
                    rank.fecha_puntaje = reader["fecha_puntaje"].ToString();
                    rank.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    rank.id_minijuego = Convert.ToInt32(reader["id_minijuego"]);

                    ListaRank.Add(rank);
                }
            }
            conexion.Close();

            return ListaRank;
        }
    }
}
