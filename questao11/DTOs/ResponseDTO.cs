namespace questao11.DTOs;

public class ResponseDTO<T>
{
    public bool Sucess { get; set; }
    public T? Data { get; set; }
    public string? Error { get; set; }
}
