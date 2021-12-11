using acercamientoALaEvaluacion4.bd;
using acercamientoALaEvaluacion4.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace acercamientoALaEvaluacion4.Views
{
    /// <summary>
    /// Lógica de interacción para CheckRequirements.xaml
    /// </summary>
    public partial class CheckRequirements : Window
    {
        
        private Data d;
        private Usuario usuarioActual;
        //private readonly string[] LISTA_PRIORIDADES = new string[] { "Alta", "Media", "Baja" };

        public CheckRequirements(Data _d, Usuario sesion)
        {
            d = _d;
            usuarioActual = sesion;
            InitializeComponent();
            this.Title = usuarioActual.Nombre + " " + usuarioActual.Apellido;
            //d = new Database.Data("DESKTOP-644QAJI", "Evaluacion4", "sa", "casita123");
            RequirementType.ItemsSource = d.GetTiposRequerimiento();
            RequirementPriority.ItemsSource = d.GetPrioridades();

            actualizarTabla();

            
            
        }



        private void SearchRequirements_Click(object sender, RoutedEventArgs e)
        {

            //RequirementsList.ItemsSource = d.GetRequerimientos();
        }

        private void RequirementType_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void buttonResolve_Click(object sender, RoutedEventArgs e)
        {
            Requerimiento requerimientoSeleccionado = RequirementsList.SelectedItem as Requerimiento;
            requerimientoSeleccionado.Estado = "Resuelto";
            int filas = d.updateRequerimiento(requerimientoSeleccionado);
            if(filas == 1)
            {
                MessageBox.Show(
                    "Marcado como resuelto correctamente",
                    "Actualizado!",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                actualizarTabla();
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            Requerimiento requerimientoSeleccionado = RequirementsList.SelectedItem as Requerimiento;

            MessageBoxResult respuesta = MessageBox.Show("¿Realmente desea borrar el registro " + requerimientoSeleccionado.Id + "?", "Eliminando registro", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if(respuesta == MessageBoxResult.Yes)
            {
                int filas = d.deleteRequerimiento(requerimientoSeleccionado);
                if (filas == 1)
                {
                    MessageBox.Show(
                        "Eliminado correctamente",
                        "Registro Borrado!",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    actualizarTabla();
                }
            }else if(respuesta == MessageBoxResult.No)
            {
                Debug.WriteLine("No eliminado");
            }


        }

        private void RequirementSearch_Click(object sender, RoutedEventArgs e)
        {
            /*
             TipoRequerimiento tipoRequerimiento = RequirementType.SelectedItem as TipoRequerimiento;
            Prioridad prioridad = RequirementPriority.SelectedItem as Prioridad;

            bool pendientes = (bool)checkBoxPendientes.IsChecked;
            bool resueltos = (bool)checkBoxResueltos.IsChecked;

            List<Requerimiento> lista = d.GetRequerimientos();
            List<Requerimiento> nuevaLista = new List<Requerimiento>();

            if(tipoRequerimiento != null)
            {
                foreach (Requerimiento r in lista)
                {
                    if (r.IdTipo == tipoRequerimiento.Id)
                    {
                        nuevaLista.Add(r);
                    }
                }
            }
             * */



        }

        private void actualizarTabla()
        {
            List<Rol> listaRoles = d.GetRoles();
            Rol admin = listaRoles.Find(rol => rol.Nombre == "Administrador");

            if (usuarioActual.IdRol == admin.Id)
            {
                RequirementsList.ItemsSource = d.GetRequerimientos();
            }
            else
            {
                RequirementsList.ItemsSource = d.GetRequerimientos(usuarioActual);
            }
        }
    }
}
