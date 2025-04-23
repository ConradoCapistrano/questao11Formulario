using System.Data;
using Dapper;
using questao11.Infra.Interface;
using questao11.Model;

namespace questao11.Infra.Repository;

public class PensamentoRepository : IPensamentoRepository
{
    private readonly IDbConnection _conn;

    public PensamentoRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public async Task<bool> Inserir(Pensamento pensamento)
    {
        try
        {
            string sql = @"
                INSERT INTO Pensamentos (Pensamento, Autor, Modelo) 
                VALUES (@PensamentoTexto, @Autor, @Modelo)";

            var parametros = new
            {
                PensamentoTexto = pensamento.PensamentoTexto,
                Autor = pensamento.Autor,
                Modelo = pensamento.Modelo
            };

            var linhasAfetadas = await _conn.ExecuteAsync(sql, parametros);
            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Atualizar(Pensamento pensamento)
    {
        try
        {
            const string sql = @"
                UPDATE Pensamentos
                SET Pensamento = @PensamentoTexto,
                    Autor = @Autor,
                    Modelo = @Modelo
                WHERE Id = @Id";

            var resultado = await _conn.ExecuteAsync(sql, new
            {
                pensamento.Id,
                PensamentoTexto = pensamento.PensamentoTexto,
                pensamento.Autor,
                pensamento.Modelo
            });

            return resultado > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> Excluir(int id)
    {
        try
        {
            string sql = "DELETE FROM Pensamentos WHERE Id = @Id";
            var parametros = new { Id = id };
            var linhasAfetadas = await _conn.ExecuteAsync(sql, parametros);
            return linhasAfetadas > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Pensamento>> ListarTodos()
    {
        try
        {
            const string sql = "SELECT Id, Pensamento AS PensamentoTexto, Autor, Modelo FROM Pensamentos";

            var pensamentos = await _conn.QueryAsync<Pensamento>(sql);
            return pensamentos.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Pensamento> ObterPorId(int id)
    {
        try
        {
            const string sql = "SELECT Id, Pensamento AS PensamentoTexto, Autor, Modelo FROM Pensamentos WHERE Id = @Id";

            return await _conn.QueryFirstOrDefaultAsync<Pensamento>(sql, new { Id = id });
        }
        catch (Exception)
        {
            throw;
        }
    }
}
