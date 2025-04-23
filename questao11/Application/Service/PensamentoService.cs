using questao11.Application.Interface;
using questao11.DTOs;
using questao11.Infra.Interface;
using questao11.Model;

namespace questao11.Application.Service;

public class PensamentoService : IPensamentoService
{
    private readonly IPensamentoRepository _repository;

    public PensamentoService(IPensamentoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResponseDTO<bool>> Atualizar(UpdatePensamentoDTO pensamentoDTO)
    {
        try
        {
            var pensamentoExistente = await _repository.ObterPorId(pensamentoDTO.Id);
            if (pensamentoExistente == null)
            {
                return new ResponseDTO<bool>
                {
                    Sucess = false,
                    Error = "Pensamento não encontrado",
                    Data = false
                };
            }

            var pensamento = new Pensamento
            {
                Id = pensamentoDTO.Id,
                PensamentoTexto = pensamentoDTO.PensamentoTexto ?? pensamentoExistente.PensamentoTexto,
                Autor = pensamentoDTO.Autor ?? pensamentoExistente.Autor,
                Modelo = pensamentoDTO.Modelo
            };

            var resultado = await _repository.Atualizar(pensamento);
            return new ResponseDTO<bool>
            {
                Sucess = resultado,
                Data = resultado
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ResponseDTO<bool>> Excluir(int id)
    {
        try
        {
            var pensamentoExistente = await _repository.ObterPorId(id);
            if (pensamentoExistente == null)
            {
                return new ResponseDTO<bool>
                {
                    Sucess = false,
                    Error = "Pensamento não encontrado",
                    Data = false
                };
            }

            var resultado = await _repository.Excluir(id);
            return new ResponseDTO<bool>
            {
                Sucess = resultado,
                Data = resultado
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ResponseDTO<bool>> Inserir(CreatePensamentoDTO pensamentoDTO)
    {
        try
        {
            var pensamento = new Pensamento
            {
                PensamentoTexto = pensamentoDTO.PensamentoTexto,
                Autor = pensamentoDTO.Autor,
                Modelo = pensamentoDTO.Modelo
            };

            var resultado = await _repository.Inserir(pensamento);
            return new ResponseDTO<bool>
            {
                Sucess = resultado,
                Data = resultado
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<ResponseDTO<List<PensamentoDTO>>> ListarTodos()
    {
        try
        {
            var pensamentos = await _repository.ListarTodos();

            var pensamentoDTO = pensamentos.Select(p => new PensamentoDTO
            {

                Id = p.Id,
                PensamentoTexto = p.PensamentoTexto,
                Autor = p.Autor,
                Modelo = p.Modelo

            }).ToList();

            return new ResponseDTO<List<PensamentoDTO>>
            {
                Sucess = true,
                Data = pensamentoDTO
            };
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<PensamentoDTO?> ObterPorId(int id)
    {
        try
        {
            var pensamento = await _repository.ObterPorId(id);
            if (pensamento == null)
            {

            }

            var pensamentoDTO = new PensamentoDTO
            {
                Id = pensamento.Id,
                PensamentoTexto = pensamento.PensamentoTexto,
                Autor = pensamento.Autor,
                Modelo = pensamento.Modelo
            };

            return pensamentoDTO;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
