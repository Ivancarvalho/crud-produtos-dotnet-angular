using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProdutos.Models;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace ApiProdutos.Services
{
    public class ProdutoService
    {
        private readonly string _connectionString;

        public ProdutoService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Produto>> GetProdutosAsync()
        {
            using var conn = new NpgsqlConnection(_connectionString);
            return await conn.QueryAsync<Produto>(
                "SELECT * FROM produto WHERE excluido = false ORDER BY descricao"
            );
        }

        public async Task<Produto> GetProdutoByIdAsync(Guid id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            return await conn.QueryFirstOrDefaultAsync<Produto>(
                "SELECT * FROM produto WHERE id = @id AND excluido = false", new { id }
            );
        }

        public async Task<int> AddProdutoAsync(Produto produto)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            produto.Id = Guid.NewGuid();
            return await conn.ExecuteAsync(
                @"INSERT INTO produto (id, codigo, descricao, departamento_codigo, preco, ativo, excluido)
                  VALUES (@Id, @Codigo, @Descricao, @DepartamentoCodigo, @Preco, @Ativo, false)", produto
            );
        }

        public async Task<int> UpdateProdutoAsync(Produto produto)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            return await conn.ExecuteAsync(
                @"UPDATE produto SET codigo=@Codigo, descricao=@Descricao, departamento_codigo=@DepartamentoCodigo, preco=@Preco, ativo=@Ativo
                  WHERE id=@Id", produto
            );
        }

        public async Task<int> ExcluirProdutoAsync(Guid id)
        {
            using var conn = new NpgsqlConnection(_connectionString);
            return await conn.ExecuteAsync(
                "UPDATE produto SET excluido = true WHERE id=@id", new { id }
            );
        }

        public IEnumerable<Departamento> GetDepartamentos()
        {
            return new List<Departamento>
            {
                new Departamento { Codigo = "010", Descricao = "BEBIDAS" },
                new Departamento { Codigo = "020", Descricao = "CONGELADOS" },
                new Departamento { Codigo = "030", Descricao = "LATICINIOS" },
                new Departamento { Codigo = "040", Descricao = "VEGETAIS" }
            };
        }
    }
}
