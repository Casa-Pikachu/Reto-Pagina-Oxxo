using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Pagina_Oxxo.Model{
    public class DataBaseContext{
        public string ConnectionString {get; set;}

        public DataBaseContext(){
            ConnectionString = "Server=127.0.0.1;Port=3306;Database=reto_oxxo;Uid=root";
        }

        private MySqlConnection GetConnection(){
            return new MySqlConnection(ConnectionString);
        }

        public List<Usuarios> GetAllUsers(){
            List<Usuarios> ListaUsuarios = new List<Usuarios>();
            
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand("Select * from Usuarios", conexion);

            Usuarios usr1;
            
            using (var reader = cmd.ExecuteReader()){
                while (reader.Read()){
                    usr1 = new Usuarios();
                    
                    usr1.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usr1.nombre = reader["nombre"].ToString();
                    usr1.apellido = reader["apellido"].ToString();
                    usr1.correo = reader["correo"].ToString();
                    usr1.contrasena = reader["contrasena"].ToString();
                    usr1.monedas = Convert.ToInt32(reader["monedas"]);
                    usr1.id_rol = Convert.ToInt32(reader["id_rol"]);
                    usr1.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                    
                    ListaUsuarios.Add(usr1);
                }
            }

            conexion.Close();
            return ListaUsuarios;
        }
    }
}