using System;

namespace LocaCar.Business.Models
{
    public class Locacao : Entity
    {
        public Guid ClienteId { get; set; }
        public Guid VeiculoId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }


        /* EF Relation */
        public Cliente Cliente { get; set; }
        public Veiculo Veiculo { get; set; }

    }
}