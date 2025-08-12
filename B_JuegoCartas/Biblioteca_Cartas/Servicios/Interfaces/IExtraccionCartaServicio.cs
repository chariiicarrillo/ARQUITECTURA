namespace Biblioteca_Cartas.Servicios
{
    public interface IExtraccionCartaServicio
    {
        Biblioteca_Cartas.Clases.Carta SacarCarta(System.Collections.Generic.List<Biblioteca_Cartas.Clases.Carta> cartas_restantes);
    }
}
