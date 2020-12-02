﻿using LocaCar.Business.Models;
using System;
using System.Threading.Tasks;

namespace LocaCar.Business.Intefaces
{
    public interface IClienteService : IDisposable
    {
        Task<bool> EfetuarLocacao(int veiculoId);
    }
}