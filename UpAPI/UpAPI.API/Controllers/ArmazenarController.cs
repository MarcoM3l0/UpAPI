using Microsoft.AspNetCore.Mvc;
using UpAPI.Aplicacao.UseCases.Uses.UploadFotoPerfil;

namespace UpAPI.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArmazenarController : ControllerBase
{
    [HttpPost]
    public IActionResult UploadImagem(IFormFile arquivo)
    {
        var useCase = new UploadFotoPerfilUseCase();

        useCase.Execucao(arquivo);

        return Created();
    }
}
