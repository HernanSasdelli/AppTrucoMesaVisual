using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using AppTrucoMesaVisual.UI;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AppTrucoMesaVisual.Core;


namespace AppTrucoMesaVisual
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // ========================
        // BOTÓN REPARTIR
        // ========================
        private void BtnRepartir_Click(object sender, RoutedEventArgs e)
        {
            // Acá iría la lógica nueva de ControlJuego.IniciarRonda() y repartir animado con tus cartas reales
            // Por ahora solo marcamos el evento
        }
        

        // ======= BOTONES DEL JUGADOR =======

        private void BtnJ_Envido_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_RealEnvido_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_FaltaEnvido_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_Truco_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_Retruco_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_ValeCuatro_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_Quiero_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_NoQuiero_Click(object sender, RoutedEventArgs e) { }
        private void BtnJ_Flor_Click(object sender, RoutedEventArgs e) { }

        // ======= BOTONES DE LA IA (simulados) =======

        private void BtnIA_Envido_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_RealEnvido_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_FaltaEnvido_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_Truco_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_Retruco_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_ValeCuatro_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_Quiero_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_NoQuiero_Click(object sender, RoutedEventArgs e) { }
        private void BtnIA_Flor_Click(object sender, RoutedEventArgs e) { }

        // ======= CARTAS JUGADOR (click en imagen) =======

        private void CartaJ1_MouseDown(object sender, MouseButtonEventArgs e) { }
        private void CartaJ2_MouseDown(object sender, MouseButtonEventArgs e) { }
        private void CartaJ3_MouseDown(object sender, MouseButtonEventArgs e) { }







    }
}
