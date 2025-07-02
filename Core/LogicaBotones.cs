using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppTrucoMesaVisual.Core
{
    public static class LogicaBotones
    {
        public static List<string> ObtenerOpcionesDisponibles(bool paraIA = false)
        {
            if (ControlJuego.Estado == EstadoGeneral.EsperandoRespuestaCanto &&
                ControlJuego.SubEstado == SubEstadoJugada.EsperandoRespuestaAEnvido)
                return ObtenerOpcionesRespuestaEnvido(paraIA);

            if (ControlJuego.Estado == EstadoGeneral.Jugando &&
                ((paraIA && ControlJuego.SubEstado == SubEstadoJugada.EsperandoJugadaIA) ||
                 (!paraIA && ControlJuego.SubEstado == SubEstadoJugada.EsperandoJugadaJugador)) &&
                !LogicaEnvido.EnvidoActivo(ControlJuego.CantosEnvidoActuales) &&
                !ControlJuego.CartaYaJugada)
                return ObtenerOpcionesEnvido();

            return new List<string>();
        }

        private static List<string> ObtenerOpcionesEnvido()
        {
            var opciones = new List<string>();

            if (LogicaEnvido.PuedeAgregarCanto(ControlJuego.CantosEnvidoActuales, TipoEnvido.Envido))
                opciones.Add("Envido");

            if (LogicaEnvido.PuedeAgregarCanto(ControlJuego.CantosEnvidoActuales, TipoEnvido.RealEnvido))
                opciones.Add("Real Envido");

            if (LogicaEnvido.PuedeAgregarCanto(ControlJuego.CantosEnvidoActuales, TipoEnvido.FaltaEnvido))
                opciones.Add("Falta Envido");

            return opciones;
        }

        private static List<string> ObtenerOpcionesRespuestaEnvido(bool paraIA)
        {
            if (ControlJuego.SubEstado == SubEstadoJugada.EsperandoRespuestaAEnvido &&
                ((paraIA && ControlJuego.TurnoActual == Turno.IA) ||
                 (!paraIA && ControlJuego.TurnoActual == Turno.Jugador)))
            {
                return new List<string> { "Quiero", "No Quiero" };
            }

            return new List<string>();
        }
    }
}
