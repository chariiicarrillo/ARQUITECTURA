namespace Biblioteca_Cartas.Servicios
{
    public interface ICartaServicio
    {
        void EntregarCartas(Biblioteca_Cartas.Clases.Jugador jugador, Biblioteca_Cartas.Clases.Resto resto, int cantidad);
        void EntregarCarta(Biblioteca_Cartas.Clases.Jugador jugador, Biblioteca_Cartas.Clases.Resto resto);
    }
}
