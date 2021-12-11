using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acercamientoALaEvaluacion4.Models
{
    public class Requerimiento
    {
        private int id;
        private string descripcion;
        private int idTipo; //id del tipo de requerimiento
        private int responsable; // id del usuario
        private int prioridad;
        private string estado;

        public Requerimiento(int id, string descripcion, int idTipo, int responsable, int prioridad, string estado)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.idTipo = idTipo;
            this.responsable = responsable;
            this.prioridad = prioridad;
            this.estado = estado;
        }

        public Requerimiento(string descripcion, int idTipo, int responsable, int prioridad, string estado)
        {
            this.descripcion = descripcion;
            this.idTipo = idTipo;
            this.responsable = responsable;
            this.prioridad = prioridad;
            this.estado = estado;
        }

        public int Id { get => id; set => id = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int IdTipo { get => idTipo; set => idTipo = value; }
        public int Responsable { get => responsable; set => responsable = value; }
        public int Prioridad { get => prioridad; set => prioridad = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}