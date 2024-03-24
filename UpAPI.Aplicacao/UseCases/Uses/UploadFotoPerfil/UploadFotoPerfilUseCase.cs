using FileTypeChecker.Extensions;
using FileTypeChecker.Types;
using Microsoft.AspNetCore.Http;
using UpAPI.Dominio.Armazenamento;
using UpAPI.Dominio.Entidades;

namespace UpAPI.Aplicacao.UseCases.Uses.UploadFotoPerfil;

public class UploadFotoPerfilUseCase : IUploadFotoPerfilUseCase
{
    private readonly IArmazenamentoServico _armazenamentoServico;
    public UploadFotoPerfilUseCase(IArmazenamentoServico armazenamentoServico)
    {
        _armazenamentoServico = armazenamentoServico;
    }


    public void Execucao(IFormFile arquivo)
    {
        var streamArquivo = arquivo.OpenReadStream();

        var isImagem = streamArquivo.Is<JointPhotographicExpertsGroup>();

        if (!isImagem)
            throw new Exception("O arquivo não é uma imagem!");

        var usuario = GetFromDataBase();

        _armazenamentoServico.Upload(arquivo, usuario);

    }

    //Simulação de requisição de banco de dados.
    private User GetFromDataBase()
    {
        return new User
        {
            Id = 1,
            Name = "Marco",
            Email = "josemarcomelonascimento@gmail.com",
            AccessToken = "seu token",
            RefreshToken = "seu token"
        };
    }
}
