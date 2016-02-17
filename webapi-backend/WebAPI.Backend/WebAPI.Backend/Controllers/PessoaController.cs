using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Core.Application.Servicies;

namespace WebAPI.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/v1/Pessoa")]
    public class PessoaController : ApiController
    {
        private readonly IServicoDePessoas _servico;

        public PessoaController(IServicoDePessoas servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("{id:int}")]
        public PessoaDto Pessoa(int id)
        {
            return _servico.PessoaPor(id);
        }

        [HttpPost]
        [Route("")]
        public HttpResponseMessage Cadastrar(DadosDePessoa dados)
        {
            if (ModelState.IsValid)
            {
                _servico.Cadastrar(dados);
                return Request.CreateResponse(HttpStatusCode.Created);
            }

            ModelState.AddModelError("naopodecadastrar", "Não pode cadastrar");
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpPut]
        [Route("")]
        public HttpResponseMessage Atualizar(DadosAtualizadosDePessoa dados)
        {
            if (ModelState.IsValid)
            {
                _servico.Atualizar(dados);
                return Request.CreateResponse(HttpStatusCode.OK);
            }

            ModelState.AddModelError("naopodeatualizar", "Não pode atualizar");
            return Request.CreateErrorResponse(HttpStatusCode.OK, ModelState);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            _servico.RemoverPor(id);
            return Request.CreateResponse(HttpStatusCode.Accepted);
        }
    }
}
