using Biblioteca_Cartas.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Cartas.Servicios
{
    public interface IInicializacionJuegoServicio
    {
        (List<Baraja> baraja, List<Castigo> castigos, List<Premio> premios, Resto resto, Jugador jugador, Jugador maquina) Inicializar(string apodoJugador);
    }
}

