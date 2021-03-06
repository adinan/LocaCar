﻿using System.Collections.Generic;

namespace LocaCar.Business.Models
{
    public class Veiculo : Entity
    {
        public string Modelo { get; set; }
        public int TipoVeiculo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public int AnoModelo { get; set; }
        public int AnoFabricacao { get; set; }

        public virtual List<Locacao> Locacoes { get; set; }

    }
}