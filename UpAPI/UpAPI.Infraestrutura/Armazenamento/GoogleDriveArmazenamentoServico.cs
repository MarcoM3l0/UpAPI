using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Drive.v3;
using Microsoft.AspNetCore.Http;
using UpAPI.Dominio.Armazenamento;
using UpAPI.Dominio.Entidades;

namespace UpAPI.Infraestrutura.Armazenamento;
public class GoogleDriveArmazenamentoServico : IArmazenamentoServico
{
    private readonly GoogleAuthorizationCodeFlow _authorization;

    public GoogleDriveArmazenamentoServico(GoogleAuthorizationCodeFlow authorization)
    {
        _authorization = authorization;
    }

    public string Upload(IFormFile arquivo, User user)
    {

        var credencial = new UserCredential(_authorization, user.Email, new TokenResponse
        {
            AccessToken = user.AccessToken,
            RefreshToken = user.RefreshToken
        });

        var servico = new DriveService(new Google.Apis.Services.BaseClientService.Initializer
        {
            ApplicationName = "UpAPI",
            HttpClientInitializer = credencial
        }); ;

        var driveArquivo = new Google.Apis.Drive.v3.Data.File
        {
            Name = arquivo.Name,
            MimeType = arquivo.ContentType
        };

        var cmd = servico.Files.Create(driveArquivo, arquivo.OpenReadStream(), arquivo.ContentType);
        cmd.Fields = "id";
        
        var resposta = cmd.Upload();

        if (resposta.Status is not Google.Apis.Upload.UploadStatus.Completed)
            throw resposta.Exception;

        return cmd.ResponseBody.Id;
    }
}
