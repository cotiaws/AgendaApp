using AgendaApp.API.Dtos;
using AgendaApp.API.Entities;
using AgendaApp.API.Enums;
using AgendaApp.API.Repositories;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        #region Atributos

        private readonly string _categoriaNaoEncontrado = "Categoria não encontrada. Verifique o ID informado.";
        private readonly string _tarefaNaoEncontrado = "Tarefa não encontrada. Verifique o ID informado.";
        private readonly string _nenhumRegistroEncontrado = "Nenhum registro foi encontrado.";

        #endregion

        [HttpPost]
        public IActionResult Post([FromBody] TarefaRequestDto request)
        {
            //Criando uma instância da classe de repositório de categorias
            var categoriaRepository = new CategoriaRepository();

            //Verificar se a categoria não existe (condição de segurança)
            if (!categoriaRepository.CategoriaExiste(request.CategoriaId.Value))
                return NotFound(new { mensagem = _categoriaNaoEncontrado });

            //Capturar os dados da tarefa
            var tarefa = new Tarefa
            {
                Nome = request.Nome ?? string.Empty,
                DataHora = DateTime.Parse($"{request.Data} {request.Hora}"),
                Prioridade = (Prioridade) request.Prioridade.Value,
                CategoriaId = request.CategoriaId.Value
            };

            //Criando uma instância da classe de repositório de tarefas
            var tarefaRepository = new TarefaRepository();

            //Salvar a tarefa no banco de dados
            tarefaRepository.Inserir(tarefa);

            //Retornar a resposta (HTTP 201 CREATED)
            return StatusCode(201, new { tarefa.Id, request });
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] TarefaRequestDto request)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefa = tarefaRepository.ObterPorId(id);
            if (tarefa == null)
                return NotFound(new { mensagem = _tarefaNaoEncontrado });

            var categoriaRepository = new CategoriaRepository();
            if(!categoriaRepository.CategoriaExiste(request.CategoriaId.Value))
                return NotFound(new { mensagem = _categoriaNaoEncontrado });

            //Capturar os dados da tarefa
            tarefa.Nome = request.Nome ?? string.Empty;
            tarefa.DataHora = DateTime.Parse($"{request.Data} {request.Hora}");
            tarefa.Prioridade = (Prioridade)request.Prioridade.Value;
            tarefa.CategoriaId = request.CategoriaId.Value;

            //Atualizando a tarefa no banco de dados
            tarefaRepository.Atualizar(tarefa);

            //Retornar a resposta (HTTP 200 OK)
            return StatusCode(200, new { tarefa.Id, request });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefa = tarefaRepository.ObterPorId(id);
            if (tarefa == null)
                return NotFound(new { mensagem = _tarefaNaoEncontrado });

            //Excluindo a tarefa
            tarefaRepository.Excluir(tarefa);

            //Retornar a resposta (HTTP 200 OK)
            return StatusCode(200, new { tarefa.Id });
        }

        [HttpGet("{dataHoraInicio}/{dataHoraFim}")]
        public IActionResult GetAll(DateTime dataHoraInicio, DateTime dataHoraFim)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefas = tarefaRepository.ObterPorDatas(dataHoraInicio, dataHoraFim);

            //Verificar se nenhum registro foi encontrado.
            if (!tarefas.Any())
                return StatusCode(204, new { mensagem = _nenhumRegistroEncontrado });

            //Retornar a resposta (HTTP 200 OK)
            return StatusCode(200, tarefas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var tarefaRepository = new TarefaRepository();

            var tarefa = tarefaRepository.ObterPorId(id);

            //Verificar se nenhum registro foi encontrado.
            if (tarefa == null)
                return StatusCode(204, new { mensagem = _nenhumRegistroEncontrado });

            //Retornar a resposta (HTTP 200 OK)
            return StatusCode(200, tarefa);
        }
    }
}
