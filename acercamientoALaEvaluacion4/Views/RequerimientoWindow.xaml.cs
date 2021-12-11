using acercamientoALaEvaluacion4.bd;
using acercamientoALaEvaluacion4.Models;
using System;
using System.Collections.Generic;
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
    /// Lógica de interacción para RequerimientoWindow.xaml
    /// </summary>
    public partial class RequerimientoWindow : Window
    {
        private Data d;
        private Usuario usuarioActual;
        private readonly string[] LISTA_PRIORIDADES = new string[] { "Alta", "Media", "Baja" };
        public RequerimientoWindow(Data data, Usuario sesion)
        {
            d = data;
            usuarioActual = sesion;
            InitializeComponent();
            comboBoxTipoRequerimiento.ItemsSource = d.GetTiposRequerimiento();
            comboBoxUsuario.ItemsSource = d.GetUsuarios();
            comboBoxPrioridad.ItemsSource = d.GetPrioridades();
        }

        private void buttonGuardar_Click(object sender, RoutedEventArgs e)
        {
            TipoRequerimiento tipoRequerimiento = comboBoxTipoRequerimiento.SelectedItem as TipoRequerimiento;
            //Requerimiento requerimiento = (Requerimiento)comboBoxTipoRequerimiento.SelectedItem;
            Usuario usuario = comboBoxUsuario.SelectedItem as Usuario;
            string descripcion = textBoxDescripcion.Text;
            Prioridad prioridad = comboBoxPrioridad.SelectedItem as Prioridad;
            int filas = d.addRequerimiento(new Requerimiento(descripcion, tipoRequerimiento.Id, usuario.Id, prioridad.Id, "Pendiente"));

            if (filas == 1)
            {
                MessageBox.Show("Registrado, hay "+prioridad.Dias+" días para terminarlo", "Registrado!", MessageBoxButton.OK, MessageBoxImage.Information);
                limpiarFormulario();
            }
            else
            {
                MessageBox.Show("Algo resultó muy mal", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            limpiarFormulario();
        }

        private void limpiarFormulario()
        {
            comboBoxTipoRequerimiento.SelectedIndex = -1;
            comboBoxUsuario.SelectedIndex = -1;
            comboBoxPrioridad.SelectedIndex = -1;
            textBoxDescripcion.Text = "";
        }

        private void buttonRequerimientos_Click(object sender, RoutedEventArgs e)
        {
            CheckRequirements window = new CheckRequirements(d, usuarioActual);
            window.Show();
        }
    }
}
