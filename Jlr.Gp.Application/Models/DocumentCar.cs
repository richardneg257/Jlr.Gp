namespace Jlr.Gp.Application.Models;
public class DocumentCar
{
    public bool Success { get; set; }
    public DocumentCarData? Data { get; set; }
}

public class DocumentCarData
{
    public string Plate { get; set; } = string.Empty;
    public string Serial_Number { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public string Motor { get; set; } = string.Empty;
}
