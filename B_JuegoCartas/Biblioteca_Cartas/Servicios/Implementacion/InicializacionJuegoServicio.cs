using Biblioteca_Cartas.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca_Cartas.Servicios
{
    public class InicializacionJuegoServicio : IinicializacionJuegoServicio
    {
        private readonly ICreacionCartasServicio creacionCartasServicio;
        private readonly IMezclaCartasServicio mezclaCartasServicio;
        private readonly IExtraccionCartaServicio extraccionCartaServicio;
        private readonly ICartaServicio cartaServicio;
        private readonly IASControlServicio controlAsServicio;
        private readonly IComodinServicio comodinServicio;

        public InicializacionJuegoServicio(
            ICreacionCartasServicio creacionCartasServicio,
            IMezclaCartasServicio mezclaCartasServicio,
            IExtraccionCartaServicio extraccionCartaServicio,
            ICartaServicio cartaServicio,
            IASControlServicio controlAsServicio,
            IComodinServicio comodinServicio)

        {
            this.creacionCartasServicio = creacionCartasServicio;
            this.mezclaCartasServicio = mezclaCartasServicio;
            this.extraccionCartaServicio = extraccionCartaServicio;
            this.cartaServicio = cartaServicio;
            this.controlAsServicio = controlAsServicio;
            this.comodinServicio = comodinServicio;
        }

        public (List<Baraja>, List<Castigo>, List<Premio>, Resto, Jugador, Jugador) Inicializar(string apodoJugador)
        {
            var cartasBaraja = new List<Baraja>();
            var cartasCastigo = new List<Castigo>();
            var cartasPremio = new List<Premio>();

            creacionCartasServicio.CreacionCartas(cartasBaraja, cartasCastigo, cartasPremio);

            var resto = new Resto(cartasBaraja, cartasPremio, cartasCastigo, mezclaCartasServicio, extraccionCartaServicio);

            var jugador = new Jugador(apodoJugador);
            var maquina = new Jugador("Maquina");

            cartaServicio.EntregarCartas(jugador, resto, 2);
            cartaServicio.EntregarCartas(maquina, resto, 2);

            controlAsServicio.ControlAS(jugador.cartas_jugador);
            controlAsServicio.ControlAS(maquina.cartas_jugador);
            comodinServicio.ComodinMaquina(maquina.cartas_jugador, resto);

            return (cartasBaraja, cartasCastigo, cartasPremio, resto, jugador, maquina);
        }
    }

}
