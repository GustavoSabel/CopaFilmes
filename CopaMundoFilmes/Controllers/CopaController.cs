using CopaMundoFilmes.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CopaMundoFilmes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CopaController : ControllerBase
    {
        [HttpPost("Disputar")]
        public Vencedores Executar([FromBody] List<Filme> filmesDaCopa)
        {
            var copa = new Copa(8);
            foreach (var filme in filmesDaCopa)
            {
                copa.AddFilme(filme);
            }
            return copa.ExecutarDisputas();
        }
    }
}
