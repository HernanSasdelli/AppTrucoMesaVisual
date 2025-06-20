using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace AppTrucoMesaVisual.UI
{
    public static class Animaciones
    {
        public static void RepartirCarta(Image carta, Image destino, string dorsoPath, string caraPath, double destinoX, double destinoY)
        {
            // Posición inicial desde donde se mueve la carta
            Canvas.SetLeft(carta, Canvas.GetLeft(destino));
            Canvas.SetTop(carta, Canvas.GetTop(destino));

            carta.Source = new BitmapImage(new Uri(dorsoPath));
            carta.Visibility = Visibility.Visible;

            var animX = new DoubleAnimation
            {
                From = Canvas.GetLeft(destino),
                To = destinoX,
                Duration = TimeSpan.FromSeconds(1)
            };

            var animY = new DoubleAnimation
            {
                From = Canvas.GetTop(destino),
                To = destinoY,
                Duration = TimeSpan.FromSeconds(1)
            };

            animX.Completed += (s, _) =>
            {
                // Se da vuelta la carta al llegar
                carta.Dispatcher.Invoke(() =>
                {
                    carta.Source = new BitmapImage(new Uri(caraPath));
                });

            };

            carta.BeginAnimation(Canvas.LeftProperty, animX);
            carta.BeginAnimation(Canvas.TopProperty, animY);
        }

        public static void RepartirSecuencia(Image[] cartas,Image mazo,string[] caras,double[] destinosX,double destinoY, int[] delays )
         {
            for (int i = 0; i < cartas.Length; i++)
            {
                int index = i;
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(delays[index]);
                timer.Tick += (s, _) =>
                {
                    timer.Stop();
                    RepartirCarta(
                        carta: cartas[index],
                        destino: mazo,
                        dorsoPath: "pack://application:,,,/Recursos/dorso.png",
                        caraPath: caras[index],
                        destinoX: destinosX[index],
                        destinoY: destinoY
                    );
                };
                timer.Start();
            }
        }

    }
}
