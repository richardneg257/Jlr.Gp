namespace Jlr.Gp.Application.Models;
public class DocumentRuc
{
    public bool Success { get; set; }
    public DocumentRucData? Data { get; set; }
}

public class DocumentRucData
{
    public string Ruc { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
