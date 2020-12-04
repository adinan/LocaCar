﻿using System.Collections.Generic;

namespace LocaCar.Business.Models
{
    public class Cliente : Entity
    {
        public string Cpf { get; set; }

        //public Cliente(string cpf)
        //{
        //    Cpf = cpf;
        //}


        /* EF Relation */
        public virtual List<Locacao> Locacoes { get; set; }

    }
}