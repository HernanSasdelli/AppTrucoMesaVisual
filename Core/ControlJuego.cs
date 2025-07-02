using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrucoMesaVisual.Core
{

    public static class ControlJuego
    {

        //Propiedades y listas
        public static EstadoGeneral Estado { get; private set; } = EstadoGeneral.EsperandoInicio;
        public static SubEstadoJugada SubEstado { get; private set; } = SubEstadoJugada.Nada;
        public static List<TipoEnvido> CantosEnvidoActuales { get; private set; } = new();
        public static List<string> MazoActual { get; private set; } = new();
        public static List<string> ManoJugador { get; private set; } = new();
        public static List<string> ManoIA { get; private set; } = new();
        public static bool CartaYaJugada { get; set; } = false;
        public static Turno TurnoActual { get; set; } = Turno.Jugador;




        // ------------------------
        // INICIO Y CICLO GENERAL
        // ------------------------

        public static void ResetearJuego()
        {
            Estado = EstadoGeneral.EsperandoInicio;
            SubEstado = SubEstadoJugada.Nada;
        }

        public static void PrepararRonda()
        {
            MazoActual = Mazo.GenerarCartas();
            ManoJugador = Mazo.ObtenerMano(MazoActual, 0);
            ManoIA = Mazo.ObtenerMano(MazoActual, 3);
            ResetearCantosEnvido();
            CartaYaJugada = false;
        }

        public static void IniciarRonda()
        {
            PrepararRonda();
            // Determina aleatoriamente quién comienza
            bool jugadorEmpieza = new Random().Next(2) == 0;

            if (jugadorEmpieza)
            {
                Estado = EstadoGeneral.Jugando;
                SubEstado = SubEstadoJugada.EsperandoJugadaJugador;
            }
            else
            {
                Estado = EstadoGeneral.Jugando;
                SubEstado = SubEstadoJugada.EsperandoJugadaIA;              
            }
        }


        public static void FinalizarRonda()
        {
            Estado = EstadoGeneral.FinRonda;
            SubEstado = SubEstadoJugada.Nada;
        }

        public static void CancelarRonda()
        {
            Estado = EstadoGeneral.FinRonda;
            SubEstado = SubEstadoJugada.Nada;
        }

        public static void PausarJuego()
        {
            Estado = EstadoGeneral.FinRonda; // Usamos FinRonda como "no interactivo"
            SubEstado = SubEstadoJugada.Nada;
        }

        public static void ContinuarJuego()
        {
            Estado = EstadoGeneral.Jugando;
            SubEstado = SubEstadoJugada.EsperandoJugadaJugador;
        }


        // -----------
        // TURNOS
        // -----------

        public static void ComenzarTurnoJugador()
        {
            Estado = EstadoGeneral.Jugando;
            SubEstado = SubEstadoJugada.EsperandoJugadaJugador;
        }

        public static void ComenzarTurnoIA()
        {
            Estado = EstadoGeneral.Jugando;
            SubEstado = SubEstadoJugada.EsperandoJugadaIA;
        }

        public static bool EsTurnoDelJugador()
        {
            return Estado == EstadoGeneral.Jugando && SubEstado == SubEstadoJugada.EsperandoJugadaJugador;
        }

        public static bool EsTurnoDeIA()
        {
            return Estado == EstadoGeneral.Jugando && SubEstado == SubEstadoJugada.EsperandoJugadaIA;
        }


        // ----------------------
        // ESTADO DE ACCIONES
        // ----------------------

        public static bool PuedeRepartir()
        {
            return Estado == EstadoGeneral.EsperandoInicio || Estado == EstadoGeneral.FinRonda;
        }

        public static bool PuedeTirarCarta()
        {
            return Estado == EstadoGeneral.Jugando && SubEstado == SubEstadoJugada.EsperandoJugadaJugador;
        }

        public static bool PuedeCantarEnvido()
        {
            return Estado == EstadoGeneral.Jugando && SubEstado == SubEstadoJugada.EsperandoJugadaJugador;
        }

        public static bool PuedeCantarTruco()
        {
            return Estado == EstadoGeneral.Jugando && SubEstado == SubEstadoJugada.EsperandoJugadaJugador;
        }

        public static bool EstaEsperandoRespuesta()
        {
            return Estado == EstadoGeneral.EsperandoRespuestaCanto;
        }

        public static bool EstaJugando()
        {
            return Estado == EstadoGeneral.Jugando;
        }

        // ---------------------------
        // CANTOS
        // ---------------------------
        public static void AgregarCantoEnvido(TipoEnvido nuevoCanto)
        {
            if (LogicaEnvido.PuedeAgregarCanto(CantosEnvidoActuales, nuevoCanto))
                CantosEnvidoActuales.Add(nuevoCanto);
        }

        public static void ResetearCantosEnvido()
        {
            CantosEnvidoActuales.Clear();
        }



        // ---------------------------
        // RESPUESTAS A CANTOS
        // ---------------------------

        public static void EsperarRespuestaEnvido()
        {
            Estado = EstadoGeneral.EsperandoRespuestaCanto;
            SubEstado = SubEstadoJugada.EsperandoRespuestaAEnvido;
        }

        public static void EsperarRespuestaTruco()
        {
            Estado = EstadoGeneral.EsperandoRespuestaCanto;
            SubEstado = SubEstadoJugada.EsperandoRespuestaATruco;
        }

        public static void EsperarRespuestaFaltaEnvido()
        {
            Estado = EstadoGeneral.EsperandoRespuestaCanto;
            SubEstado = SubEstadoJugada.EsperandoRespuestaAFalta;
        }

        public static void ResolverRespuestaCanto(bool aceptado)
        {
            if (aceptado)
            {
                Estado = EstadoGeneral.Jugando;
                SubEstado = SubEstadoJugada.EsperandoJugadaIA;
            }
            else
            {
                FinalizarRonda();
            }
        }







    }




}

