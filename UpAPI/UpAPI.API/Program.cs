using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using UpAPI.Aplicacao.UseCases.Uses.UploadFotoPerfil;
using UpAPI.Dominio.Armazenamento;
using UpAPI.Infraestrutura.Armazenamento;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUploadFotoPerfilUseCase, UploadFotoPerfilUseCase>();
builder.Services.AddScoped<IArmazenamentoServico>(options =>
{
    var clientId = builder.Configuration.GetValue<string>("CloudStorage:clientId");
    var clientSecret = builder.Configuration.GetValue<string>("CloudStorage:ClientSecret");

    var apiCodeFlow = new GoogleAuthorizationCodeFlow( new GoogleAuthorizationCodeFlow.Initializer
    {
        ClientSecrets = new ClientSecrets
        {
            ClientId =  clientId,
            ClientSecret = clientSecret
        },
        Scopes = [Google.Apis.Drive.v3.DriveService.Scope.Drive],
        DataStore = new FileDataStore("UpAPI")
    } );
    

    return new GoogleDriveArmazenamentoServico(apiCodeFlow);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
