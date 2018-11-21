using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using SiriusApp.Api.Models;
using AutoMapper;
using Domain.entities;
using Services;

namespace SiriusApp.Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [Route("v1/valida_login")]
        [HttpPost]
        public HttpResponseMessage GetTokenLogin(UsuarioModel user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            try
            {
                var usuario = Mapper.Map<UsuarioModel, UsuarioDomain>(user);
                var usuariologado = new UsuarioServices().ValidaAcessoServices(usuario);
                if(usuariologado == null)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized, "Usuário ou senha inválidos!");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, usuariologado);
                }
                
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "ERRO " + ex.Message);
            }
        }
    }
}
