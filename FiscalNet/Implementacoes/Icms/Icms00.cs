﻿using FiscalNet.Implementacoes.IcmsExceptions;
using FiscalNET.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalNet.Implementacoes.Icms
{
    class Icms00 : IIcms
    {
        private decimal AliqIcms { get; set; }
        private decimal ValorIpi { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorProduto { get; set; }
        private decimal ValorSeguro { get; set; }

        public bool PossuiIcmsProprio
        {
            get
            {
                return true;
            }
        }

        public bool PossuiIcmsST
        {
            get
            {
                return false;
            }
        }

        public bool PossuiRedBCIcmsProprio
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool PossuiRedBCIcmsST
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Icms00(decimal aliqIcms,
            decimal valorIpi, decimal despesasAcessorias,
            decimal valorFrete, decimal valorProduto,
            decimal valorSeguro)
        {
            this.AliqIcms = aliqIcms;
            this.ValorIpi = valorIpi;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorFrete = valorFrete;
            this.ValorProduto = valorProduto;
            this.ValorSeguro = valorSeguro;
        }

        public decimal BaseIcms()
        {
            /*
            * Base do ICMS Inter = (Valor do produto +
            *  Frete +
            *   Seguro + 
            *   Outras Despesas Acessórias – Descontos)
            * */

            decimal resultado = (ValorProduto +
                ValorFrete +
                ValorSeguro +
                DespesasAcessorias);
            return resultado;
        }        

        public decimal ValorIcms()
        {
            decimal baseIcmsProprio = BaseIcms();
            decimal resultado = (AliqIcms / 100 * baseIcmsProprio);
            return resultado;
        }

        public decimal BaseIcmsST()
        {
            throw new SemSTException();
        }

        public decimal ValorIcmsST()
        {
            throw new SemSTException();
        }

        public decimal PercRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal ValorRedBaseIcms()
        {
            throw new NotImplementedException();
        }

        public decimal PercRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }

        public decimal ValorRedBaseIcmsST()
        {
            throw new NotImplementedException();
        }
    }
}