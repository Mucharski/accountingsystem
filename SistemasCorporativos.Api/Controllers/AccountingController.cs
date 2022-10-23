using Accounting.Domain.Commands;
using Accounting.Domain.Handlers.Interfaces;
using Global.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace SistemasCorporativos.Controllers;

[ApiController]
[Route("api/accounting")]
public class AccountingController : ControllerBase
{
    [HttpGet]
    [Route("status")]
    public ActionResult<GenericApiResponse<string>> Status()
    {
        GenericApiResponse<string> genericApiResponse =
            new("------ACCOUNTING API------", true, "Api online!");

        return Ok(genericApiResponse);
    }

    [HttpPost]
    [Route("account/createType")]
    public async Task<ActionResult<GenericApiResponse<string>>> Teste([FromServices] IAccountingHandler handler,
        [FromBody] CreateAccountTypeCommand cmd)
    {
        GenericApiResponse<string> genericApiResponse = await handler.Handle(cmd);

        return Ok(genericApiResponse);
    }
}