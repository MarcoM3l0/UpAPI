using Microsoft.AspNetCore.Http;
using UpAPI.Dominio.Entidades;

namespace UpAPI.Dominio.Armazenamento;

public interface IArmazenamentoServico
{
    string Upload(IFormFile arquivo, User user);
}
