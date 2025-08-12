namespace Biblioteca_Cartas.Servicios
{
    public interface IPartidaServicio
    {
        int CalcularResultado(System.Collections.Generic.List<Biblioteca_Cartas.Clases.Carta> cartasJugador, System.Collections.Generic.List<Biblioteca_Cartas.Clases.Carta> cartasMaquina);
    }
}
