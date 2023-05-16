namespace Jlr.Gp.Application.Features.Queries.GetDocumentByDni;
public class DocumentDniDto
{
    public bool Success { get; set; }
    public DocumentDniData? Data { get; set; }
}

public class DocumentDniData
{
    public string Dni { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Fathers_LastName { get; set; } = string.Empty;
    public string Mothers_LastName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
}
