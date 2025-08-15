using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            //Instanciando a classe do repositório de categorias
            var categoriaRepository = new CategoriaRepository();

            //Consultando todas as categorias
            var categorias = categoriaRepository.ObterTodos();

            //Retornando as categorias
            return Ok(categorias);
        }
    }
}
