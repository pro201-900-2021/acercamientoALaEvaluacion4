using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEvaluacion4.Models
{
    public class Prioridad
    {
        private int id;
        private string nombre;
        private int dias;

        public Prioridad(int id, string nombre, int dias)
        {
            this.id = id;
            this.nombre = nombre;
            this.dias = dias;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Dias { get => dias; set => dias = value; }

        public override string ToString()
        {
            return nombre;
        }
    }
}
