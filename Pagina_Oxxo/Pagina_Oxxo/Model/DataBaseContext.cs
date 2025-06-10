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
            // DB local Bruno

            ConnectionString = "Server=127.0.0.1;Port=3306;Database=reto_oxxo;Uid=root;";
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

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS", conexion);

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
        public Usuarios GetUserInfo(string nombre, string apellido)
        {
            Usuarios user = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE nombre = \"{nombre}\" AND apellido = \"{apellido}\"", conexion);


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

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE id_tienda = {id_tienda} AND id_rol = 1", conexion);

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

        public List<Anuncios> GetAnuncios(string nombre, string apellido)
        {
            List<Anuncios> ListaAnuncios = new List<Anuncios>();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM ANUNCIOS WHERE id_usuario = (SELECT id_usuario FROM USUARIOS WHERE nombre = \"{nombre}\" AND apellido = \"{apellido}\")", conexion);

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

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM USUARIOS ORDER BY experiencia DESC LIMIT 3", conexion);

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

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM RECOMPENSAS LIMIT 3", conexion);

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


        //Obtener una lista para obtener los lugares del 4to en adelante
        public List<Podios> GetElse()
        {
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
        public Podios GetLugarMedalla(int posicion)
        {

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

        public Ranking GetRanking(int id_usuario_)
        {
            Ranking rank = new Ranking();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand rk = new MySqlCommand($"SELECT fecha_puntaje FROM Ranking where id_usuario = {id_usuario_}", conexion);

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




            MySqlCommand cmd = new MySqlCommand($"SELECT id_usuario, nombre, apellido, monedas, experiencia, puntos FROM USUARIOS WHERE id_usuario = {id_usuario}", conexion);


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

        public Usuarios CheckUsrId_Password(string usuario_correo, string usuario_password)
        {
            Usuarios usuario = new Usuarios();

            MySqlConnection conexion = GetConnection();
            conexion.Open();

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM USUARIOS WHERE correo = \"{usuario_correo}\" AND contrasena = \"{usuario_password}\"", conexion);

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    usuario.correo = reader["correo"].ToString();
                    usuario.contrasena = reader["contrasena"].ToString();
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
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM RECOMPENSAS", conexion);
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

            MySqlCommand cmd = new MySqlCommand($"SELECT * FROM INSTRUCCIONES WHERE titulo_instruccion = \"{titulo}\"", conexion);

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
