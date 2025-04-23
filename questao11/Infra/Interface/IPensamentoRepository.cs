using questao11.Model;

namespace questao11.Infra.Interface;

public interface IPensamentoRepository
{
    Task<List<Pensamento>> ListarTodos();
    Task<Pensamento> ObterPorId(int id);
    Task<bool> Inserir(Pensamento pensamento);
    Task<bool> Atualizar(Pensamento pensamento);
    Task<bool> Excluir(int id);
}
