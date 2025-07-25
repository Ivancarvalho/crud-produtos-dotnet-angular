// Caminho: api-produtos-dotnet/Models/Produto.cs
using System;

namespace ApiProdutos.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string DepartamentoCodigo { get; set; }
        public decimal Preco { get; set; }
        public bool Ativo { get; set; }
        public bool Excluido { get; set; }
    }
   
}
