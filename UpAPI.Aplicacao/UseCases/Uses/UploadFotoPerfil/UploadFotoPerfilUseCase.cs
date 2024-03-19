using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;

namespace UpAPI.Aplicacao.UseCases.Uses.UploadFotoPerfil;

public class UploadFotoPerfilUseCase
{
    public void Execucao(IFormFile arquivo)
    {
        var streamArquivo = arquivo.OpenReadStream();

        var isImagem = streamArquivo.Is<JointPhotographicExpertsGroup>();

        if (!isImagem)
            throw new Exception("O arquivo não é uma imagem!");

    }
}
