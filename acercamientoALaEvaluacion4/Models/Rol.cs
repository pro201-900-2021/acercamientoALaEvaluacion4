using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEvaluacion4.Models
{
    public class Rol
    {
        private int id;
        private string nombre;//Usuario, Administrador"

        public Rol(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
