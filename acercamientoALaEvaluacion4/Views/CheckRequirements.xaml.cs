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
    /// Lógica de interacción para CheckRequirements.xaml
    /// </summary>
    public partial class CheckRequirements : Window
    {
        
        private Data d;
        //private readonly string[] LISTA_PRIORIDADES = new string[] { "Alta", "Media", "Baja" };

        public CheckRequirements(Data _d)
        {
            d = _d;
            InitializeComponent();

            //d = new Database.Data("DESKTOP-644QAJI", "Evaluacion4", "sa", "casita123");
            RequirementType.ItemsSource = d.GetTiposRequerimiento();
            RequirementPriority.ItemsSource = d.GetPrioridades();
        }



        private void SearchRequirements_Click(object sender, RoutedEventArgs e)
        {

            //RequirementsList.ItemsSource = d.GetRequerimientos();
        }

        private void RequirementType_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }
    }
}
