﻿
namespace Domain.entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int ClienteId { get; set; }
        //public virtual ClienteDominioDomain Cliente { get; set; }
    }
}
