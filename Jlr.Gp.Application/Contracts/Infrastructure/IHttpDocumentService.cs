using Jlr.Gp.Application.Models;

namespace Jlr.Gp.Application.Contracts.Infrastructure;
public interface IHttpDocumentService
{
    Task<DocumentFromSap?> GetDocumentFromSap(string documentNumber);
    Task<DocumentDniData?> GetDocumentByDni(string dni);
    Task<DocumentCarData?> GetCarByPlate(string plateNumber);
    Task<DocumentRucData?> GetDocumentByRuc(string rucNumber);
}
