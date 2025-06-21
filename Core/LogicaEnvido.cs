using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrucoMesaVisual.Core
{
    public enum TipoEnvido
    {
        Envido,
        RealEnvido,
        FaltaEnvido
    }

    public static class LogicaEnvido
    {
        public static int CalcularPuntosEnvido(List<TipoEnvido> cantos, int puntosJugador, int puntosOponente)
        {
            int total = 0;
            foreach (var canto in cantos)
            {
                switch (canto)
                {
                    case TipoEnvido.Envido:
                        total += 2;
                        break;
                    case TipoEnvido.RealEnvido:
                        total += 3;
                        break;
                    case TipoEnvido.FaltaEnvido:
                        total = CalcularFalta(puntosJugador, puntosOponente);
                        return total; // Falta anula los demás cantos, retorna directo
                }
            }
            return total;
        }

        public static int CalcularFalta(int puntosJugador, int puntosOponente)
        {
            int mayor = Math.Max(puntosJugador, puntosOponente);

            if (mayor < 15)
                return 15 - mayor;
            if (mayor < 30)
                return 30 - mayor;

            return 30 - mayor; //30 puntos a ganar
        }

        //limitador
        public static bool PuedeAgregarCanto(List<TipoEnvido> cantos, TipoEnvido nuevo)
        {
            if (cantos.Contains(TipoEnvido.FaltaEnvido)) return false;
            if (nuevo == TipoEnvido.FaltaEnvido) return true;
            if (nuevo == TipoEnvido.RealEnvido && cantos.Contains(TipoEnvido.RealEnvido)) return false;

            return cantos.Count(c => c == TipoEnvido.Envido) < 2;
        }

        public static TipoEnvido UltimoCanto(List<TipoEnvido> cantos)
        {
            return cantos.Count > 0 ? cantos[^1] : TipoEnvido.Envido;
        }

        public static bool EnvidoActivo(List<TipoEnvido> cantos)
        {
            return cantos.Count > 0;
        }

        public static int ObtenerPuntosEnvidoActuales(List<TipoEnvido> cantos, int puntosJugador, int puntosOponente)
        {
            return CalcularPuntosEnvido(cantos, puntosJugador, puntosOponente);
        }

        public static string ObtenerDescripcionCantos(List<TipoEnvido> cantos)
        {
            if (cantos.Count == 0) return "Sin cantos";

            return string.Join(" + ", cantos.Select(c =>
            {
                return c switch
                {
                    TipoEnvido.Envido => "Envido",
                    TipoEnvido.RealEnvido => "Real Envido",
                    TipoEnvido.FaltaEnvido => "Falta Envido",
                    _ => c.ToString()
                };
            }));
        }
    }
}
