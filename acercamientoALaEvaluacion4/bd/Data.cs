﻿using System;
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
    }
}