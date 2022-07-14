using Microsoft.AspNetCore.Mvc;
using SistemasCorporativos.Entities;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/accounting")]
public class AccountingController : ControllerBase
{
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<GenericApiResponse<string>>> Create()
    {
        GenericApiResponse<string> genericApiResponse = new("Oi", true, "Obtido com sucesso!");
        
        return Ok(genericApiResponse);
    }
}
