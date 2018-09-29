using OProjeto.Services;
using OProjeto.ViewModels;
using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OProjeto.Controllers
{
    /// <summary>
    /// Classe responsável por atender as requisições http para fins de autenticação
    /// </summary>
    [Route("authenticate")] //Configura a rota da solicitação ([protocolo]://[dominio]/authenticate)
    [EnableCors(origins: "*", headers: "*", methods: "*")] //Configura o serviço para aceitar solicitações de outros domínios
    public class AuthenticationController : ApiController
    {
        private readonly StudentServices studentServices;

        public AuthenticationController(StudentServices studentServices)
        {
            this.studentServices = studentServices;
        }

        /// <summary>
        /// Recebe requisições utilizando o verbo http POST
        /// </summary>
        /// <param name="body">Instância contendo os dados de autenticação</param>
        /// <returns>Resultado da solicitação</returns>
        public IHttpActionResult Post(LoginViewModel body)
        {
            if (!ModelState.IsValid)
                return BadRequest("Solicitação inválida");

            try
            {
                //Encaminha os dados ao serviço de autenticação
                var student = studentServices.Authenticate(body.Email, body.Password);

                //Se o aluno foi encontrado, a autenticação foi realizada com sucesso
                return Ok(new { success = student != null, code = HttpStatusCode.OK.ToString(), message = student != null ? "Autenticação realizada com sucesso!" : "Usuário e/ou senha inválidos!" });
            }
            catch(Exception)
            {
                return BadRequest("Houve um erro técnico ao processar a solicitação. Por favor, entre em contato com o suporte/administrador da aplicação e reporte o ocorrido.");
            }
        }

        /// <summary>
        /// Método disparado pelo runtime para livrar recursos da aplicação de maneira otimizada
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            studentServices.Dispose();

            base.Dispose(disposing);
        }
    }
}