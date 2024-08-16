namespace Backend.Models;

public class Response
{
    public string? Translation { get; set; }
    public string? Error { get; set; }

    public Response(string? translation, string? error)
    {
        Translation = translation;
        Error = error;
    }
}
