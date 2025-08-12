using System;
using System.Collections.Generic;
using System.Linq;
using Biblioteca_Cartas.Servicios;

namespace Biblioteca_Cartas.Clases
{
    public class Baraja : Carta
    {
        public List<Baraja> BarajaJuego { get; } = new();

        public Baraja(string descripcion, IValorCartaService valorCartaService)
            : base(0, 0, descripcion ?? throw new ArgumentNullException(nameof(descripcion), "La carta no tiene ningún valor."))
        {
            Punto_carta = valorCartaService.DarValorCarta(descripcion);
        }

        public Action<Baraja> AgregarCarta => carta => BarajaJuego.Add(carta);

        public Action<string> EliminarCartaPorDescripcion => desc => BarajaJuego.RemoveAll(c => c.Descripcion == desc);

        public Func<string, Baraja?> BuscarCartaPorDescripcion => desc => BarajaJuego.FirstOrDefault(c => c.Descripcion == desc);

        public Func<int, IEnumerable<Baraja>> ObtenerCartasPorValor => valor => BarajaJuego.Where(c => c.Punto_carta > valor);

        public Func<int> ContarCartas => () => BarajaJuego.Count;
    }
}

