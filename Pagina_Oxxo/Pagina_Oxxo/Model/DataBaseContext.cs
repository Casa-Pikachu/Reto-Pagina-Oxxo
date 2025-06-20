using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Pagina_Oxxo.Model{
    public class DataBaseContext
    {
        public string ConnectionString { get; set; }

        public DataBaseContext()
        {
            ConnectionString = "Server=mysql-370e2f78-tec-f8a4.b.aivencloud.com;Port=27566;Database=reto_oxxo;Uid=avnadmin;Password=AVNS_2M0v78xMV-H3ZdoHrdY;SslMode=Required;";
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        // Funcion para obtener todos los usuarios
        public List<Usuarios> GetAllUsers()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios", conexion);

            Usuarios usr1;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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
        public Usuarios GetUserInfo(int id_usuario)
        {
            Usuarios user = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM usuarios WHERE id_usuario = {id_usuario}", conexion);


            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
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

        public Usuarios GetAsesor(int id_tienda)
        {
            Usuarios user = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM usuarios WHERE id_tienda = {id_tienda} AND id_rol = 1", conexion);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
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

        public List<Anuncios> GetAnuncios(int id_usuario)
        {
            List<Anuncios> ListaAnuncios = new List<Anuncios>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM anuncios WHERE id_usuario = {id_usuario}", conexion);

            Anuncios anuncio;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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

        public List<Usuarios> GetTop3()
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuarios ORDER BY experiencia DESC LIMIT 3", conexion);

            Usuarios usr1;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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
        public List<Recompensas> GetRecompensas()
        {
            List<Recompensas> ListaItems = new List<Recompensas>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM recompensas LIMIT 3", conexion);

            Recompensas item;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
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


       //Magda
        public List<Podios> GetElse()
        {
            List<Podios> PodioUsuarios = new List<Podios>();
            //lista vacía

            MySqlConnection conexion = GetConnection();
            conexion.Open();
            //conectar a base de datos


            string query = @"
                    SELECT nombre, apellido, puntos
                FROM  (
                    SELECT 
                        nombre, 
                        apellido, 
                        puntos,
                        ROW_NUMBER() OVER (ORDER BY puntos DESC) AS posicion
                        from usuarios
   
                ) AS sub WHERE posicion >= 4;";

            MySqlCommand cmd = new MySqlCommand(query, conexion);


            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
               
                    Podios usrpod = new Podios
                    {
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        puntaje = Convert.ToInt32(reader["puntos"])

                    };

                    PodioUsuarios.Add(usrpod);
               

                }
            }

            conexion.Close();

            return PodioUsuarios;
        }


        //Magda
        public Podios GetLugarMedalla(int posicion)
        {

            Podios resultado = null;

            MySqlConnection conexion = GetConnection();
            conexion.Open();
        
            string query = $@"

            SELECT nombre, apellido, puntos
                FROM  (
                    SELECT 
                        nombre, 
                        apellido, 
                        puntos,
                        ROW_NUMBER() OVER (ORDER BY puntos DESC) AS posicion
                        from usuarios
   
                ) AS sub WHERE posicion = {posicion}; ";


            
            MySqlCommand cmd = new MySqlCommand(query, conexion);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())

                    resultado = new Podios
                    {
                        nombre = reader["nombre"].ToString(),
                        apellido = reader["apellido"].ToString(),
                        puntaje = Convert.ToInt32(reader["puntos"])

                    };
            }

            conexion.Close();

            return resultado;
        }

        public Ranking GetRanking(int id_usuario_)
        {
            Ranking rank = new Ranking();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            string query = "SELECT fecha_puntaje FROM ranking WHERE id_usuario = @id";
            MySqlCommand rk = new MySqlCommand(query, conexion);
            rk.Parameters.AddWithValue("@id", id_usuario_);


            using (var reader = rk.ExecuteReader())
            {
                if (reader.Read())
                {

                    rank.fecha_puntaje = reader["fecha_puntaje"].ToString();
                }
            }

            conexion.Close();
            return rank;
        }

        public Usuarios GetUserId(int id_usuario)
        {
            Usuarios usuario = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();




            MySqlCommand cmd = new MySqlCommand($"SELECT id_usuario, nombre, apellido, monedas, experiencia, puntos FROM usuarios WHERE id_usuario = {id_usuario}", conexion);


            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.monedas = Convert.ToInt32(reader["monedas"]);
                    usuario.experiencia = Convert.ToInt32(reader["experiencia"]);
                    usuario.puntos = Convert.ToInt32(reader["puntos"]);
                }
            }

            conexion.Close();
            return usuario;
        }


//Natalia Cavazos

        public Usuarios CheckUsrId_Password(string usuario_correo, string usuario_password)
        {
            Usuarios usuario = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            string query = "SELECT * FROM usuarios WHERE correo = @correo AND contrasena = @contrasena";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@correo", usuario_correo);
            cmd.Parameters.AddWithValue("@contrasena", usuario_password);
            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario.correo = reader["correo"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
                    usuario.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usuario.nombre = reader["nombre"].ToString();
                    usuario.apellido = reader["apellido"].ToString();
                    usuario.id_tienda = Convert.ToInt32(reader["id_tienda"]);
                    usuario.id_rol = Convert.ToInt32(reader["id_rol"]);
                }
            }

            conexion.Close();
            return usuario;
        }

        // DIEGO

        public List<Reconocimientos> GetReconocimientos(string nombre, string apellido)
        {
            List<Reconocimientos> ListaReconocimientos = new List<Reconocimientos>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            string query = @"SELECT * FROM reconocimientos 
                 WHERE id_usuario = (
                     SELECT id_usuario FROM usuarios 
                     WHERE nombre = @nombre AND apellido = @apellido
                 )";

            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);


            Reconocimientos reconocimiento;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    reconocimiento = new Reconocimientos();

                    reconocimiento.id_reconocimientos = Convert.ToInt32(reader["id_reconocimientos"]);
                    reconocimiento.contenido = reader["contenido"].ToString();
                    reconocimiento.fecha_mensaje = Convert.ToDateTime(reader["fecha_mensaje"]).ToString("dd/MM/yyyy HH:mm:ss");
                    reconocimiento.transmisor = reader["transmisor"].ToString();
                    reconocimiento.id_icono = Convert.ToInt32(reader["id_icono"]);
                    reconocimiento.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    ListaReconocimientos.Add(reconocimiento);
                }
            }

            conexion.Close();
            return ListaReconocimientos;
        
        }
        
        public List<Usuarios> GetAllUsersByTienda(int id_tienda, int id_usuario)
        {
            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM usuarios WHERE id_tienda = {id_tienda} AND id_usuario != {id_usuario}", conexion);

            Usuarios usr1;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    usr1 = new Usuarios();

                    usr1.id_usuario = Convert.ToInt32(reader["id_usuario"]);
                    usr1.nombre = reader["nombre"].ToString();
                    usr1.apellido = reader["apellido"].ToString();

                    ListaUsuarios.Add(usr1);
                }
            }

            conexion.Close();
            return ListaUsuarios;
        }


        public void InsertarReconocimiento(string transmisor, string contenido, int id_icono, int receptor)
        {
            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO reconocimientos (transmisor, contenido, id_icono, id_usuario) VALUES (@transmisor, @contenido, @id_icono, @id_usuario)", conexion);
            cmd.Parameters.AddWithValue("@transmisor", transmisor);
            cmd.Parameters.AddWithValue("@contenido", contenido);
            cmd.Parameters.AddWithValue("@id_icono", id_icono); 
            cmd.Parameters.AddWithValue("@id_usuario", receptor);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }

        public void InsertarAnuncio(string contenido, int receptor)
        {
            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand("INSERT INTO anuncios (contenido, id_usuario) VALUES (@contenido, @id_usuario)", conexion);
            cmd.Parameters.AddWithValue("@contenido", contenido);
            cmd.Parameters.AddWithValue("@id_usuario", receptor);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }

        

     
                        

        public IEnumerable<Turnos> getHorarios(DateTime semana, int id_usuario)
        {
            List<Turnos> myListaTurnos = new List<Turnos>();
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getHorarios";
            cmd.Parameters.AddWithValue("@hourDate", semana); // Parametro que le pusimos en el procedure
            cmd.Parameters.AddWithValue("@userId", id_usuario);
            cmd.Connection = conexion;

            Turnos miTurno = new Turnos();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    miTurno = new Turnos();
                    miTurno.empleado = reader["empleado"].ToString();
                    miTurno.horario = reader["horario"].ToString();
                    miTurno.lunes = Convert.ToBoolean(reader["lunes"]);
                    miTurno.martes = Convert.ToBoolean(reader["martes"]);
                    miTurno.miercoles = Convert.ToBoolean(reader["miercoles"]);
                    miTurno.jueves = Convert.ToBoolean(reader["jueves"]);
                    miTurno.viernes = Convert.ToBoolean(reader["viernes"]);
                    miTurno.sabado = Convert.ToBoolean(reader["sabado"]);
                    miTurno.domingo = Convert.ToBoolean(reader["domingo"]);
                    myListaTurnos.Add(miTurno);
                }
            }
            conexion.Close();


            return myListaTurnos;
        }

        public IActionResult updateHorario(int id_usuario, string empleado, DateTime semana, Turnos upToDate)
        {
            using var conexion = GetConnection();
            conexion.Open();

            using var cmd = new MySqlCommand("updateHorarios", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };

            cmd.Parameters.AddWithValue("@userId", id_usuario);
            cmd.Parameters.AddWithValue("@empleadoAct", empleado);
            cmd.Parameters.AddWithValue("@hourDate", semana);
            cmd.Parameters.AddWithValue("@newLun", upToDate.lunes);
            cmd.Parameters.AddWithValue("@newMar", upToDate.martes);
            cmd.Parameters.AddWithValue("@newMie", upToDate.miercoles);
            cmd.Parameters.AddWithValue("@newJue", upToDate.jueves);
            cmd.Parameters.AddWithValue("@newVie", upToDate.viernes);
            cmd.Parameters.AddWithValue("@newSab", upToDate.sabado);
            cmd.Parameters.AddWithValue("@newDom", upToDate.domingo);

            int filasAfectadas = cmd.ExecuteNonQuery();

            return filasAfectadas > 0
                ? new OkResult()
                : new NotFoundObjectResult("No se actualizó ningún registro");
        }


        public List<DateTime> GetSemanasDisponibles(int id_usuario)
        {
            List<DateTime> semanas = new List<DateTime>();
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("getSemanasPorUsuario", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@userId", id_usuario);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                semanas.Add(reader.GetDateTime("semana"));
            }
            return semanas;
        }

        // Metodos Angel
        public List<Recompensas> GetAllRecompensas()
        {
            List<Recompensas> ListaItems = new List<Recompensas>();
            MySqlConnection conexion = GetConnection();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM recompensas", conexion);
            Recompensas item;
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    item = new Recompensas();
                    item.id_recompensa = Convert.ToInt32(reader["id_recompensa"]);
                    item.nombre_recompensa = reader["nombre_recompensa"].ToString();
                    item.descripcion_recompensa = reader["descripcion_recompensa"].ToString();
                    item.precio_recompensa = Convert.ToInt32(reader["precio_recompensa"]);
                    item.imagen_url = reader["imagen_url"].ToString();
                    ListaItems.Add(item);
                }
            }
            conexion.Close();
            return ListaItems;
        }

        public List<Recompensas> GetRecompensasConEstadoCompra(int id_usuario)
        {
            List<Recompensas> listaRecompensas = new List<Recompensas>();
            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();
                string query = @"
                   SELECT r.*,
                       CASE WHEN rc.id_recompensa_comprada IS NOT NULL THEN 1 ELSE 0 END AS comprado
                   FROM recompensas r
                   LEFT JOIN recompensa_comprada rc
                       ON r.id_recompensa = rc.id_recompensa_comprada
                       AND rc.id_usuario = @id_usuario";
                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaRecompensas.Add(new Recompensas
                            {
                                id_recompensa = Convert.ToInt32(reader["id_recompensa"]),
                                nombre_recompensa = reader["nombre_recompensa"].ToString(),
                                descripcion_recompensa = reader["descripcion_recompensa"].ToString(),
                                precio_recompensa = Convert.ToInt32(reader["precio_recompensa"]),
                                imagen_url = reader["imagen_url"].ToString(),
                                ya_comprado = Convert.ToInt32(reader["comprado"]) == 1
                            });
                        }
                    }
                }
            }
            return listaRecompensas;
        }
        public int GetMonedasUsuario(int idUsuario)
        {
            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();

                string query = "SELECT monedas FROM usuarios WHERE id_usuario = @idUsuario";

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    var result = cmd.ExecuteScalar();

                    return result != null ? Convert.ToInt32(result) : 0;
                }
            }
        }
       
        public bool ComprarRecompensa(int id_usuario, int id_recompensa)
        {
            using (MySqlConnection conexion = GetConnection())
            {
                conexion.Open();

                using (MySqlTransaction transaccion = conexion.BeginTransaction())
                {
                    try
                    {
                        
                        string queryPrecio = "SELECT precio_recompensa FROM recompensas WHERE id_recompensa = @id_recompensa";
                        int precio = 0;

                        using (var cmd = new MySqlCommand(queryPrecio, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                            var result = cmd.ExecuteScalar();
                            if (result == null) return false;
                            precio = Convert.ToInt32(result);
                        }

                        
                        string queryMonedas = "SELECT monedas FROM usuarios WHERE id_usuario = @id_usuario";
                        int monedas = 0;

                        using (var cmd = new MySqlCommand(queryMonedas, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                            var result = cmd.ExecuteScalar();
                            if (result == null) return false;
                            monedas = Convert.ToInt32(result);
                        }

                        
                        if (monedas < precio)
                        {
                            return false;
                        }

                        
                        string insertCompra = @"
                            INSERT INTO recompensa_comprada (id_usuario, id_recompensa_comprada)
                            VALUES (@id_usuario, @id_recompensa)";
                        using (var cmd = new MySqlCommand(insertCompra, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                            cmd.Parameters.AddWithValue("@id_recompensa", id_recompensa);
                            cmd.ExecuteNonQuery();
                        }

                        
                        string updateMonedas = "UPDATE usuarios SET monedas = monedas - @precio WHERE id_usuario = @id_usuario";
                        using (var cmd = new MySqlCommand(updateMonedas, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@id_usuario", id_usuario);
                            cmd.ExecuteNonQuery();
                        }

                        transaccion.Commit();
                        return true;
                    }
                    catch
                    {
                        transaccion.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<Instrucciones> GetInstruction(string titulo)
        {
            List<Instrucciones> listaInstrucciones = new List<Instrucciones>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            string query = "SELECT * FROM instrucciones WHERE titulo_instruccion = @titulo";
            MySqlCommand cmd = new MySqlCommand(query, conexion);
            cmd.Parameters.AddWithValue("@titulo", titulo);


            Instrucciones instruccion;

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    instruccion = new Instrucciones();

                    instruccion.id_instruccion = Convert.ToInt32(reader["id_instruccion"]);
                    instruccion.titulo_instruccion = reader["titulo_instruccion"].ToString();
                    instruccion.descripcion_instruccion = reader["descripcion_instruccion"].ToString();

                    listaInstrucciones.Add(instruccion);
                }
            }

            conexion.Close();
            return listaInstrucciones;
        }
    }
}
