using SistemaPedidosFornecedores.Models;

public interface IPedidoRepository
{
    // Método que retorna todos os pedidos
    Task<IEnumerable<Pedido>> GetAllPedidosAsync();

    // Método que retorna um pedido específico pelo Id
    Task<Pedido> GetPedidoByIdAsync(int id);

    // Método que cria um novo pedido
    Task<Pedido> CreatePedidoAsync(Pedido pedido);

    // Método que atualiza um pedido existente
    Task<Pedido> UpdatePedidoAsync(Pedido pedido);

    // Método que deleta um pedido pelo Id
    Task<bool> DeletePedidoAsync(int id);
}