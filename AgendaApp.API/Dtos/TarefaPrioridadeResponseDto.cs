namespace AgendaApp.API.Dtos
{
    /// <summary>
    /// Classe DTO para modelar os dados de resposta da API
    /// para a consulta de tarefas por prioridade.
    /// </summary>
    public class TarefaPrioridadeResponseDto
    {
        public string NomePrioridade { get; set; } = string.Empty;
        public int QtdTarefas { get; set; }
    }
}
