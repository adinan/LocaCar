using System;

namespace LocaCar.Api.Extensions
{
    public class Enums
    {
        public enum TipoVeiculo
        {
            Carro = 1,
            Caminhao = 2,
            Moto = 3
        }

        public static string GetDescription(TipoVeiculo tipoVeiculo)
        {
            return Enum.GetName(typeof(TipoVeiculo), tipoVeiculo);
        }
    }
}
