using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEvaluacion4.Models
{
    public class Usuario
    {
        private int id;
        private string nombreUsuario;
        private string password;

        private string nombre;
        private string apellido;

        private int idRol;

        public Usuario(int id, string nombreUsuario, string password, string nombre, string apellido, int idRol)
        {
            this.id = id;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.nombre = nombre;
            this.apellido = apellido;
            this.idRol = idRol;
        }

        public int Id { get => id; set => id = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int IdRol { get => idRol; set => idRol = value; }

        public override string ToString()
        {
            return nombre + " " + apellido + " ("+nombreUsuario+")";
        }
    }
}
