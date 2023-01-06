using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Model;
using MinhaAPI.Repository;

namespace MinhaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly PessoaRepositorio _pessoaRepositorio;

        public ValuesController()
        {
            _pessoaRepositorio= new PessoaRepositorio();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            return _pessoaRepositorio.GetPessoas;
        }

        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            _pessoaRepositorio.InserirPessoa(pessoa);
        }

    }
}