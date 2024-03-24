using Microsoft.AspNetCore.Http;

namespace UpAPI.Aplicacao.UseCases.Uses.UploadFotoPerfil;
public interface IUploadFotoPerfilUseCase
{
    public void Execucao(IFormFile arquivo);
}
