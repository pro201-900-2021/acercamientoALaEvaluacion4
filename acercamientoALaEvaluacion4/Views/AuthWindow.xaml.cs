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
    /// Lógica de interacción para AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        private Data d;
        public AuthWindow()
        {
            d = new Data("LAPTOP-PC8SL5H1", "EVA4", "sa", "123456");
            InitializeComponent();
        }

        private void buttonIngresar_Click(object sender, RoutedEventArgs e)
        {
            string nombreDeUsuario = textBoxUserName.Text;
            string contrasenia = passwordBoxPass.Password;

            Usuario sesion = d.Autentificacion(nombreDeUsuario, contrasenia);

            if(sesion == null)
            {
                //No coincide o el nombre o la contraseña
                MessageBox.Show("El usuario o la contraseña no coinciden", "Error Logueo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                //Como la consulta coincidió con un registro, viene el usuario, por lo tanto logueamos.
                RequerimientoWindow _rw = new RequerimientoWindow(d, sesion);
                _rw.Show();
                this.Close();
                
            }


        }
    }
}
