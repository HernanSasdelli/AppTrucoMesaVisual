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


namespace AppTrucoMesaVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void BtnRepartir_Click(object sender, RoutedEventArgs e)
        {
            var cartasJugador = new[] { CartaAnimada1, CartaAnimada2, CartaAnimada3 };
            var cartasIA = new[] { CartaOponente1, CartaOponente2, CartaOponente3 };
            var destinosJugadorX = new[] { 524.0, 658.0, 788.0 };
            var destinosIAX = new[] { 524.0, 658.0, 788.0 };
            double destinoYJugador = 375;
            double destinoYIA = 50;

            bool picar = ChkPicar.IsChecked == true;

            string[] carasJugador = {
                "pack://application:,,,/Recursos/1_espada.png",
                "pack://application:,,,/Recursos/2_espada.png",
                "pack://application:,,,/Recursos/3_espada.png"
            };

                    string[] carasIA = {
                "pack://application:,,,/Recursos/dorso.png",
                "pack://application:,,,/Recursos/dorso.png",
                "pack://application:,,,/Recursos/dorso.png"
            };

            if (picar)
            {
                var delaysJugador = Enumerable.Range(0, 3).Select(i => i * 400).ToArray();
                var delaysIA = Enumerable.Range(0, 3).Select(i => (i + 3) * 400).ToArray();


                Animaciones.RepartirSecuencia(cartasJugador, Mazo, carasJugador, destinosJugadorX, destinoYJugador, delaysJugador);
                Animaciones.RepartirSecuencia(cartasIA, Mazo, carasIA, destinosIAX, destinoYIA, delaysIA);

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    int index = i;
                    Animaciones.RepartirSecuencia(
                        new[] { cartasJugador[index] }, Mazo,
                        new[] { carasJugador[index] },
                        new[] { destinosJugadorX[index] },
                        destinoYJugador,
                        new[] { index * 800 }

                    );

                    Animaciones.RepartirSecuencia(
                        new[] { cartasIA[index] }, Mazo,
                        new[] { carasIA[index] },
                        new[] { destinosIAX[index] },
                        destinoYIA,
                        new[] { index * 800 + 400 }

                    );
                }
            }
        }



    }
}
