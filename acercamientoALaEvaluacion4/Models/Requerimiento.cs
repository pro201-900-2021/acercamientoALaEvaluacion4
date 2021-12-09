using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEvaluacion4.Models
{
    class Requerimiento
    {
        private int id;
        private string descripcion;
        private int idTipo;
        private int responsable;

        public Requerimiento(int id, string descripcion, int idTipo, int responsable)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.idTipo = idTipo;
            this.responsable = responsable;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public int Responsable { get => responsable; set => responsable = value; }
    }
}