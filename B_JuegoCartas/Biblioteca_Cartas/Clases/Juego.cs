using System.Collections.Generic;
using System.Linq;
using System;
using Biblioteca_Cartas.Servicios;

namespace Biblioteca_Cartas.Clases
{
    public class Juego
    {
        private readonly IApuestaService apuestaServicio;
        private readonly ICartaService cartasServicio;
        private readonly IPartidaService partidaServicio;
        private readonly IASControlService controlAsServicio;
        private readonly IComodinService comodinServicio;
        private readonly IInicializacionJuegoServicio inicializacionJuegoServicio;

        private List<Premio> cartasPremio;
        private List<Castigo> cartasCastigo;
        private List<Baraja> cartasBaraja;
        private Resto resto;
        private Jugador jugador;
        private Jugador maquina;
        private int saldo;

        public Juego(
            int saldoInicial,
            string apodoJugador,
            IApuestaService apuestaServicio,
            ICartaService cartasServicio,
            IPartidaService partidaServicio,
            IASControlService controlAsServicio,
            IComodinService comodinServicio,
            IInicializacionJuegoServicio inicializacionJuegoServicio)
        {
            this.apuestaServicio = apuestaServicio;
            this.cartasServicio = cartasServicio;
            this.partidaServicio = partidaServicio;
            this.controlAsServicio = controlAsServicio;
            this.comodinServicio = comodinServicio;
            this.inicializacionJuegoServicio = inicializacionJuegoServicio;
            saldo = saldoInicial;

            InicializarJuego(apodoJugador);
        }

        private void InicializarJuego(string apodoJugador) =>
            (cartasBaraja, cartasCastigo, cartasPremio, resto, jugador, maquina) = inicializacionJuegoServicio.Inicializar(apodoJugador);

        public string Apostar(int cantidadApostada) =>
            apuestaServicio.Apostar(saldo, cantidadApostada, out saldo);

        public int ObtenerSaldo() => saldo;

        public void EntregarCartaAJugador(bool esJugador) =>
            cartasServicio.EntregarCarta(esJugador ? jugador : maquina, resto);

        public void PedirCartasMaquina() =>
            Enumerable.Range(0, 2)
                .Where(_ => maquina.cartas_jugador.Sum(c => c.Punto_carta) <= 15)
                .ToList()
                .ForEach(_ =>
                {
                    cartasServicio.EntregarCarta(maquina, resto);
                    controlAsServicio.ControlAS(maquina.cartas_jugador);
                    comodinServicio.ComodinMaquina(maquina.cartas_jugador, resto);
                });

        public void Jugar(bool plantarse, int cantidadApostada) =>
            plantarse
                ? saldo += (partidaServicio.CalcularResultado(jugador.cartas_jugador, maquina.cartas_jugador) == 1
                    ? cantidadApostada * 2
                    : partidaServicio.CalcularResultado(jugador.cartas_jugador, maquina.cartas_jugador) == 0
                        ? cantidadApostada
                        : 0)
                : cartasServicio.EntregarCarta(jugador, resto);
    }
}