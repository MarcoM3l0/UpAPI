using Microsoft.AspNetCore.Http;
using UpAPI.Dominio.Armazenamento;
using UpAPI.Dominio.Entidades;

namespace UpAPI.Infraestrutura.Armazenamento;
internal class GoogleDriveArmazenamentoServico : IArmazenamentoServico
{
    public string Upload(IFormFile arquivo, User user)
    {
        throw new NotImplementedException();
    }
}
