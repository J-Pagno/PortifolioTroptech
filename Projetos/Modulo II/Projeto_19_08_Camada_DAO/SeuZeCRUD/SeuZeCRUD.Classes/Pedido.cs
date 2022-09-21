using System;
using System.Collections;
using System.Collections.Generic;

namespace SeuZeCRUD.Classes
{
    public class Pedido
    {
        private int _id;

        private DateTime _dataCriacao;

        private int _idProduto;

        private int _quantidade;

        private decimal _valorTotal;

        private string _cpfCliente;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime DataCriacao
        {
            get => _dataCriacao;
            set => _dataCriacao = value;
        }

        public int IdProduto
        {
            get => _idProduto;
            set => _idProduto = value;
        }

        public int Quantidade
        {
            get => _quantidade;
            set => _quantidade = value;
        }

        public decimal ValorTotal
        {
            get => _valorTotal;
            set => _valorTotal = value;
        }

        public string CpfCliente
        {
            get => _cpfCliente;
            set => _cpfCliente = value;
        }
    }
}
