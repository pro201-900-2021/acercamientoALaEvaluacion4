using acercamientoALaEvaluacion4.bd;
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
        private readonly string[] LISTA_PRIORIDADES = new string[] { "Alta", "Media", "Baja" };
        public RequerimientoWindow(Data data)
        {
            d = data;
            InitializeComponent();
            comboBoxTipoRequerimiento.ItemsSource = d.GetTiposRequerimiento();
            comboBoxUsuario.ItemsSource = d.GetUsuarios();
            comboBoxPrioridad.ItemsSource = LISTA_PRIORIDADES;
        }
    }
}
