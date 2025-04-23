using questao11.DTOs;

namespace questao11.Application.Interface;

public interface IPensamentoService
{
    Task<ResponseDTO<List<PensamentoDTO>>> ListarTodos();
    Task<PensamentoDTO?> ObterPorId(int id);
    Task<ResponseDTO<bool>> Inserir(CreatePensamentoDTO pensamentoDTO);
    Task<ResponseDTO<bool>> Atualizar(UpdatePensamentoDTO pensamentoDTO);
    Task<ResponseDTO<bool>> Excluir(int id);
}
