
namespace AppTrucoMesaVisual.Core
{
    public enum EstadoGeneral
    {
        EsperandoInicio,
        Repartiendo,
        Jugando,
        EsperandoRespuestaCanto,
        FinRonda
    }

    public enum SubEstadoJugada
    {
        Nada,
        EsperandoJugadaJugador,
        EsperandoJugadaIA,
        EsperandoRespuestaAEnvido,
        EsperandoRespuestaATruco,
        EsperandoRespuestaAFalta
    }
}
