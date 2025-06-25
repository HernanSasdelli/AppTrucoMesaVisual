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
            ControlJuego.IniciarRonda();
            if (ControlJuego.ManoJugador.Count < 3 || ControlJuego.ManoIA.Count < 3)
            {
                MessageBox.Show("Error: no se repartieron 3 cartas. Jugador: "
                    + ControlJuego.ManoJugador.Count + " - IA: "
                    + ControlJuego.ManoIA.Count);
                return;
            }

            var cartasJugador = new[] { CartaAnimada1, CartaAnimada2, CartaAnimada3 };
            var cartasIA = new[] { CartaOponente1, CartaOponente2, CartaOponente3 };
            var destinosJugadorX = new[] { 524.0, 658.0, 788.0 };
            var destinosIAX = new[] { 524.0, 658.0, 788.0 };
            double destinoYJugador = 375;
            double destinoYIA = 50;

            bool picar = ChkPicar.IsChecked == true;

            string[] carasJugador = ControlJuego.ManoJugador
                .Select(nombre => $"pack://application:,,,/AppTrucoMesaVisual;component/Recursos/{nombre}.png")
                .ToArray();


            string[] carasIA = ControlJuego.ManoIA
                .Select(nombre => $"pack://application:,,,/AppTrucoMesaVisual;component/Recursos/{nombre}.png")
                .ToArray();



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

        // ---------------------------
        // Botones de envido
        // ---------------------------
        private void BtnEnvido_Click(object sender, RoutedEventArgs e)
        {
            ControlJuego.AgregarCantoEnvido(TipoEnvido.Envido);
            Console.WriteLine(LogicaEnvido.ObtenerDescripcionCantos(ControlJuego.CantosEnvidoActuales));
        }

        private void BtnRealEnvido_Click(object sender, RoutedEventArgs e)
        {
            ControlJuego.AgregarCantoEnvido(TipoEnvido.RealEnvido);
            Console.WriteLine(LogicaEnvido.ObtenerDescripcionCantos(ControlJuego.CantosEnvidoActuales));
        }

        private void BtnFaltaEnvido_Click(object sender, RoutedEventArgs e)
        {
            ControlJuego.AgregarCantoEnvido(TipoEnvido.FaltaEnvido);
            Console.WriteLine(LogicaEnvido.ObtenerDescripcionCantos(ControlJuego.CantosEnvidoActuales));
        }




    }
}
