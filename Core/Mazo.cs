using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrucoMesaVisual.Core
{
    public static class Mazo
    {
        private static Random rng = new();

        public static List<string> GenerarCartas()
        {
            var cartas = new List<string>();

            for (int i = 1; i <= 12; i++)
            {
                if (i == 8 || i == 9) continue; // opcional si usás mazo español clásico
                cartas.Add($"{i}_espada");
                cartas.Add($"{i}_basto");
                cartas.Add($"{i}_oro");
                cartas.Add($"{i}_copa");
               

            }

            return cartas.OrderBy(x => rng.Next()).ToList(); // baraja
        }

        public static List<string> ObtenerMano(List<string> mazo, int inicio)
        {
            return mazo.Skip(inicio).Take(3).ToList();
        }

    }

}
