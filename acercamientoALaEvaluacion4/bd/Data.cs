using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;//<---
using acercamientoALaEvaluacion4.Models;

namespace acercamientoALaEvaluacion4.bd
{
    public class Data
    {
        private SqlConnectionStringBuilder cadenaConexion;//Crear la cadena conexión

        private SqlConnection sqlConnection;//Creamos la conexión a la base de datos
        private SqlCommand sqlCommand;//Le damos forma al comando/consulta
        private SqlDataReader response;//almacena el resultado devuelto por la consulta

        private string consulta;

        public Data(string servidor, string bd, string user, string pass)
        {
            cadenaConexion = new SqlConnectionStringBuilder();

            cadenaConexion.DataSource = servidor;
            cadenaConexion.InitialCatalog = bd;
            cadenaConexion.UserID = user;
            cadenaConexion.Password = pass;

            sqlConnection = new SqlConnection(cadenaConexion.ConnectionString);
        }

        public List<Rol> GetRoles()
        {
            List<Rol> listaRoles = new List<Rol>();

            consulta = "SELECT * FROM rol;";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string nombreActual = response.GetString(1);
                listaRoles.Add(new Rol(idActual, nombreActual));
            }
            sqlConnection.Close();
            return listaRoles;
        }

        public List<TipoRequerimiento> GetTiposRequerimiento()
        {
            List<TipoRequerimiento> listaTipos = new List<TipoRequerimiento>();

            consulta = "SELECT * FROM tipo_requerimiento;";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string nombreActual = response.GetString(1);
                listaTipos.Add(new TipoRequerimiento(idActual, nombreActual));
            }
            sqlConnection.Close();
            return listaTipos;
        }

        public List<Prioridad> GetPrioridades()
        {
            List<Prioridad> listaPrioridad = new List<Prioridad>();

            consulta = "SELECT * FROM prioridad;";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string nombreActual = response.GetString(1);
                int diaActual = response.GetInt32(2);
                listaPrioridad.Add(new Prioridad(idActual, nombreActual, diaActual));
            }
            sqlConnection.Close();
            return listaPrioridad;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            consulta = "SELECT * FROM usuario;";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string nombreUsuarioActual = response.GetString(1);
                string passwordActual = response.GetString(2);
                string nombreActual = response.GetString(3);
                string apellidoActual = response.GetString(4);
                int rolActual = response.GetInt32(5);
                listaUsuarios.Add(new Usuario(idActual, nombreUsuarioActual, passwordActual, nombreActual, apellidoActual, rolActual));
            }
            sqlConnection.Close();
            return listaUsuarios;
        }

        public List<Requerimiento> GetRequerimientos()
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();

            consulta = "SELECT * FROM requerimiento;";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string descripcionActual = response.GetString(1);
                int idTipoActual = response.GetInt32(2);
                int idUsuarioActual = response.GetInt32(3);
                int idPrioridadActual = response.GetInt32(4);
                string estadoActual = response.GetString(5);
                listaRequerimientos.Add(new Requerimiento(idActual, descripcionActual, idTipoActual, idUsuarioActual, idPrioridadActual, estadoActual));
            }
            sqlConnection.Close();
            return listaRequerimientos;
        }

        public List<Requerimiento> GetRequerimientos(Usuario usuario)
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();

            consulta = "SELECT * FROM requerimiento where responsable = "+usuario.Id+";";

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string descripcionActual = response.GetString(1);
                int idTipoActual = response.GetInt32(2);
                int idUsuarioActual = response.GetInt32(3);
                int idPrioridadActual = response.GetInt32(4);
                string estadoActual = response.GetString(5);
                listaRequerimientos.Add(new Requerimiento(idActual, descripcionActual, idTipoActual, idUsuarioActual, idPrioridadActual, estadoActual));
            }
            sqlConnection.Close();
            return listaRequerimientos;
        }

        public List<Requerimiento> GetRequerimientos(string consultaCustom)
        {
            List<Requerimiento> listaRequerimientos = new List<Requerimiento>();

            consulta = consultaCustom;

            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            while (response.Read())
            {
                int idActual = response.GetInt32(0);
                string descripcionActual = response.GetString(1);
                int idTipoActual = response.GetInt32(2);
                int idUsuarioActual = response.GetInt32(3);
                int idPrioridadActual = response.GetInt32(4);
                string estadoActual = response.GetString(5);
                listaRequerimientos.Add(new Requerimiento(idActual, descripcionActual, idTipoActual, idUsuarioActual, idPrioridadActual, estadoActual));
            }
            sqlConnection.Close();
            return listaRequerimientos;
        }

        public Usuario Autentificacion(string nombreUsuario, string password)
        {
            Usuario u = null;

            consulta = "SELECT * FROM usuario WHERE nombreUsuario = '"+nombreUsuario+"' AND passw = '"+password+"';";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            response = sqlCommand.ExecuteReader();

            if (response.Read())
            {
                int idActual = response.GetInt32(0);
                string nUsuarioActual = response.GetString(1);
                string passActual = response.GetString(2);
                string nombreActual = response.GetString(3);
                string apellidoActual = response.GetString(4);
                int rolActual = response.GetInt32(5);
                u = new Usuario(idActual, nUsuarioActual, passActual, nombreActual, apellidoActual, rolActual);
            }
            sqlConnection.Close();

            //Schrodinger -> u = Usuario || u = null 

            return u;
        }

        public int addRequerimiento(Requerimiento requerimiento)
        {
            consulta = "insert into requerimiento values('"+requerimiento.Descripcion+"', "+requerimiento.IdTipo+", "+requerimiento.Responsable+", "+requerimiento.Prioridad+", '"+requerimiento.Estado+"');";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return filasAfectadas;
        }

        public int updateRequerimiento(Requerimiento requerimiento)
        {
            consulta = "UPDATE requerimiento SET descripcion = '"+requerimiento.Descripcion+"', idTipo = "+requerimiento.IdTipo+", responsable = "+requerimiento.Responsable+", idPrioridad = "+requerimiento.Prioridad+", estado = '"+requerimiento.Estado+"' WHERE id = "+requerimiento.Id+";";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return filasAfectadas;
        }

        public int deleteRequerimiento(Requerimiento requerimiento)
        {
            consulta = "DELETE FROM requerimiento WHERE id = "+requerimiento.Id+";";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return filasAfectadas;
        }

        public int deleteRequerimiento(int idRequerimiento)
        {
            consulta = "DELETE FROM requerimiento WHERE id = " + idRequerimiento + ";";
            sqlConnection.Open();
            sqlCommand = new SqlCommand(consulta, sqlConnection);
            int filasAfectadas = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            return filasAfectadas;
        }
    }
}
