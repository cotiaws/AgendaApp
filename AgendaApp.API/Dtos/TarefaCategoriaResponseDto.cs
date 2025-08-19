namespace AgendaApp.API.Dtos
{
    /// <summary>
    /// Classe DTO para modelar os dados de resposta da API
    /// para a consulta de tarefas por categoria.
    /// </summary>
    public class TarefaCategoriaResponseDto
    {
        public string NomeCategoria { get; set; } = string.Empty;
        public int QtdTarefas { get; set; }
    }
}
