using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.Entities
{
    public class Jogo:IntId
    {
        public string Titulo { get; set; }

        public double? ValorPago { get; set; }

        public DateTime? DataCompra { get; set; }

        public int IdGenero { get; set; }

        public Genero Genero { get; set; }

        public int IdEditor { get; set; }

        public Editor Editor { get; set; }

        public string Imagem { get; set; }

    }
}
