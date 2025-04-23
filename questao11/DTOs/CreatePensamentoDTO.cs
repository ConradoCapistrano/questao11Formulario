using System.ComponentModel.DataAnnotations;

namespace questao11.DTOs;

public class CreatePensamentoDTO
{
    [StringLength(300, ErrorMessage = "O pensamento deve ter no maximo 300 caracteres")]
    public string? PensamentoTexto { get; set; }
    [StringLength(50, ErrorMessage = "O autor deve ter no maximo 50 caracteres")]
    public string? Autor { get; set; }
    [Required(ErrorMessage = "O campo modelo é obrigatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "O modelo deve ser maior que zero")]
    public int Modelo { get; set; }
}
