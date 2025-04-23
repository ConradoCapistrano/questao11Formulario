using System.ComponentModel.DataAnnotations;

namespace questao11.DTOs;

public class UpdatePensamentoDTO
{
    public int Id { get; set; }
    [StringLength(300, ErrorMessage = "O pensamento deve ter no máximo 300 caracteres.")]
    public string? PensamentoTexto { get; set; }
    [StringLength(50, ErrorMessage = "O autor deve ter no máximo 50 caracteres.")]
    public string? Autor { get; set; }
    [Range(1, int.MaxValue, ErrorMessage = "O Modelo deve ser maior que zero.")]
    public int Modelo { get; set; }
}
