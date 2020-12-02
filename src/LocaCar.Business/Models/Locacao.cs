using System;

namespace LocaCar.Business.Models
{
    public class Locacao : Entity
    {
        public int ClienteId { get; set; }
        public int VeiculoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }


        /* EF Relation */
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}