namespace Biblioteca_Cartas.Servicios
{
    public interface IApuestaServicio
    {
        string Apostar(int saldoActual, int cantidadApostada, out int saldoFinal);
    }
}
