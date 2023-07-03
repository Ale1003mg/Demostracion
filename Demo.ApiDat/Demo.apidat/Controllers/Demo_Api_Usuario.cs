using Demo.apidat.dao.dao;
using Demo.apidat.dto.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace Demo.apidat.Controllers
{
    [SwaggerTag("Web api de usuarios")]

    [Route("api/Usuarios/")]
    [ApiController]
    public class Demo_Api_Usuario : ControllerBase
    {
        private readonly IDao_Usuarios _Usuarios;

        public Demo_Api_Usuario(IDao_Usuarios usuarios)
        { 
            _Usuarios = usuarios;
        
        }


        [SwaggerOperation(summary:"Mostra datos de los usuarios")]
        [SwaggerResponse((int)HttpStatusCode.OK,"Exitos",Type= typeof(List<Dto_Usuarios>))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "fail", Type = typeof(List<Dto_Usuarios>))]
        [Produces("application/json")]
        [HttpGet]
        public async Task<List<Dto_Usuarios>> GetallUsuarios()
        { 
            return await _Usuarios.Getall_Usuario();
        }

        [SwaggerOperation(summary: "Mostra datos de un usuario")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Exitos", Type = typeof(Dto_Usuarios))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "fail", Type = typeof(Dto_Usuarios))]
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<Dto_Usuarios> GetidUsuarios(int id)
        {
            return await _Usuarios.GetID_Usuario(id);
        }

        [SwaggerOperation(summary: "Insertar y modificar datos")]
        [SwaggerResponse((int)HttpStatusCode.OK, "Exitos", Type = typeof(Boolean))]
        [SwaggerResponse((int)HttpStatusCode.NoContent, "fail", Type = typeof(Boolean))]
        [Produces("application/json")]
        [HttpPost]
        public async Task<Boolean> Mante_Usuarios(Dto_Usuarios dto_Usuarios)
        {
            return await _Usuarios.Mante_Usuario(dto_Usuarios);
        }
    }
}
