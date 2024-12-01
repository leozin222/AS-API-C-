// Classe que representa a entidade Pedido no sistema
public class Pedido
{
    // Identificador único do pedido
    public int Id { get; set; }

    // Data em que o pedido foi realizado
    public DateTime Data { get; set; }

    // Valor total do pedido
    public decimal ValorTotal { get; set; }

    // Status do pedido, como "Pendente", "Concluído" ou "Cancelado"
    public string Status { get; set; }

    // Descrição do pedido, informações adicionais
    public string Descricao { get; set; } 
}