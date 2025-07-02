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
            ActualizarOpcionesCanto(LogicaBotones.ObtenerOpcionesDisponibles());

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
        private void ActualizarOpcionesCanto(List<string> opciones)
        {
            // Oculta todos los botones por defecto
            BtnOpcion1.Visibility = Visibility.Collapsed;
            BtnOpcion2.Visibility = Visibility.Collapsed;
            BtnOpcion3.Visibility = Visibility.Collapsed;

            if (opciones.Count > 0)
            {
                BtnOpcion1.Content = opciones[0];
                BtnOpcion1.Visibility = Visibility.Visible;
            }
            if (opciones.Count > 1)
            {
                BtnOpcion2.Content = opciones[1];
                BtnOpcion2.Visibility = Visibility.Visible;
            }
            if (opciones.Count > 2)
            {
                BtnOpcion3.Content = opciones[2];
                BtnOpcion3.Visibility = Visibility.Visible;
            }
        }
        private void BtnOpcion1_Click(object sender, RoutedEventArgs e)
        {
            if (BtnOpcion1.Content is string texto1)
                EjecutarOpcion(texto1);

        }

        private void BtnOpcion2_Click(object sender, RoutedEventArgs e)
        {           
            if (BtnOpcion2.Content is string texto2)
                EjecutarOpcion(texto2);
        }

        private void BtnOpcion3_Click(object sender, RoutedEventArgs e)
        {          
            if (BtnOpcion3.Content is string texto3)
                EjecutarOpcion(texto3);
        }

        private void EjecutarOpcion(string opcion)
        {
            switch (opcion)
            {
                case "Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.Envido);
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "Jugador canta Envido.";
                    break;

                case "Real Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.RealEnvido);
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "Jugador canta Real Envido.";
                    break;

                case "Falta Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.FaltaEnvido);
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "Jugador canta Falta Envido.";
                    break;

                case "Quiero":
                    TxtMensajes.Text = "Jugador acepta el Envido.";
                    ControlJuego.ResolverRespuestaCanto(true);
                    break;

                case "No Quiero":
                    TxtMensajes.Text = "Jugador no acepta el Envido.";
                    ControlJuego.ResolverRespuestaCanto(false);
                    break;
            }

            // Refrescar las opciones visibles tras la jugada
            ActualizarOpcionesCanto(LogicaBotones.ObtenerOpcionesDisponibles());
            ActualizarOpcionesCantoIA(LogicaBotones.ObtenerOpcionesDisponibles(true));
        }

        private void EjecutarOpcionIA(string opcion)
        {
            switch (opcion)
            {
                case "Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.Envido);
                    ControlJuego.TurnoActual = Turno.Jugador;
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "IA canta Envido.";
                    break;

                case "Real Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.RealEnvido);
                    ControlJuego.TurnoActual = Turno.Jugador;
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "IA canta Real Envido.";
                    break;

                case "Falta Envido":
                    ControlJuego.AgregarCantoEnvido(TipoEnvido.FaltaEnvido);
                    ControlJuego.TurnoActual = Turno.Jugador;
                    ControlJuego.EsperarRespuestaEnvido();
                    TxtMensajes.Text = "IA canta Falta Envido.";
                    break;

                case "Quiero":
                    TxtMensajes.Text = "IA acepta el Envido.";
                    ControlJuego.ResolverRespuestaCanto(true);
                    break;

                case "No Quiero":
                    TxtMensajes.Text = "IA no acepta el Envido.";
                    ControlJuego.ResolverRespuestaCanto(false);
                    break;
            }

            // Actualizamos ambos lados
            ActualizarOpcionesCanto(LogicaBotones.ObtenerOpcionesDisponibles());
            ActualizarOpcionesCantoIA(LogicaBotones.ObtenerOpcionesDisponibles(true));
        }


        private void BtnIA1_Click(object sender, RoutedEventArgs e)
        {
            if (BtnIA1.Content is string texto)
                EjecutarOpcionIA(texto);
        }

        private void BtnIA2_Click(object sender, RoutedEventArgs e)
        {
            if (BtnIA2.Content is string texto)
                EjecutarOpcionIA(texto);
        }

        private void BtnIA3_Click(object sender, RoutedEventArgs e)
        {
            if (BtnIA3.Content is string texto)
                EjecutarOpcionIA(texto);
        }

        private void ActualizarOpcionesCantoIA(List<string> opciones)
        {
            BtnIA1.Visibility = Visibility.Visible;
            BtnIA2.Visibility = Visibility.Visible;
            BtnIA3.Visibility = Visibility.Visible;


            if (opciones.Count > 0)
            {
                BtnIA1.Content = opciones[0];
                BtnIA1.Visibility = Visibility.Visible;
            }
            if (opciones.Count > 1)
            {
                BtnIA2.Content = opciones[1];
                BtnIA2.Visibility = Visibility.Visible;
            }
            if (opciones.Count > 2)
            {
                BtnIA3.Content = opciones[2];
                BtnIA3.Visibility = Visibility.Visible;
            }
        }





    }
}
