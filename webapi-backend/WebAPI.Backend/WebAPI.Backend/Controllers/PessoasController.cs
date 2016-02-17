using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Core.Application.Servicies;

namespace WebAPI.Backend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", SupportsCredentials = true)]
    [RoutePrefix("api/v1/Pessoas")]
    public class PessoasController : ApiController
    {
        private readonly IServicoDePessoas _servico;

        public PessoasController(IServicoDePessoas servico)
        {
            _servico = servico;
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<PessoaDto> Todos()
        {
            return _servico.ListarPessoas();
        }


    }
}
