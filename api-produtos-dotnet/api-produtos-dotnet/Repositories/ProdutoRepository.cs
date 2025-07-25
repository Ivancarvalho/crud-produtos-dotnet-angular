// Caminho: api-produtos-dotnet/Repositories/ProdutoRepository.cs

using api_produtos_dotnet.Models;
using Npgsql;
using Dapper;
using System.Collections.Generic;

namespace api_produtos_dotnet.Repositories
{
    public class ProdutoRepository
    {
        private readonly string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Produto> GetAll()
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return connection.Query<Produto>("SELECT * FROM produto WHERE excluido = FALSE ORDER BY descricao");
        }

        public Produto GetById(Guid id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            return connection.QueryFirstOrDefault<Produto>("SELECT * FROM produto WHERE id = @Id AND excluido = FALSE", new { Id = id });
        }

        public void Add(Produto produto)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            produto.Id = Guid.NewGuid();
            connection.Execute(@"INSERT INTO produto (id, codigo, descricao, departamento_codigo, preco, ativo, excluido)
                VALUES (@Id, @Codigo, @Descricao, @DepartamentoCodigo, @Preco, @Ativo, FALSE)", produto);
        }

        public void Update(Produto produto)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Execute(@"UPDATE produto SET codigo=@Codigo, descricao=@Descricao, departamento_codigo=@DepartamentoCodigo, preco=@Preco, ativo=@Ativo
                WHERE id=@Id AND excluido = FALSE", produto);
        }

        public void Excluir(Guid id)
        {
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Execute("UPDATE produto SET excluido=TRUE WHERE id=@Id", new { Id = id });
        }
    }
}
