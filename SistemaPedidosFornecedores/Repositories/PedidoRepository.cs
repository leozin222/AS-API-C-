using Microsoft.EntityFrameworkCore;
using SistemaPedidosFornecedores.Data;
using SistemaPedidosFornecedores.Models;

public class PedidoRepository : IPedidoRepository
{
    // Contexto do banco de dados para interagir com as tabelas
    private readonly ApplicationDbContext _context;

    // Construtor para injetar o contexto do banco de dados
    public PedidoRepository(ApplicationDbContext context)
    {
        _context = context; // Inicializa o contexto com a injeção de dependência
    }

    // Obtém todos os pedidos do banco de dados
    public async Task<IEnumerable<Pedido>> GetAllPedidosAsync() =>
        await _context.Pedidos.ToListAsync();

    // Obtém um pedido específico pelo Id
    public async Task<Pedido> GetPedidoByIdAsync(int id) =>
        await _context.Pedidos.FindAsync(id);

    // Cria um novo pedido no banco de dados
    public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Add(pedido); // Adiciona o pedido à tabela Pedidos
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        return pedido; // Retorna o pedido criado
    }

    // Atualiza um pedido existente
    public async Task<Pedido> UpdatePedidoAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido); // Marca o pedido para ser atualizado
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        return pedido; // Retorna o pedido atualizado
    }

    // Deleta um pedido pelo Id
    public async Task<bool> DeletePedidoAsync(int id)
    {
        var pedido = await _context.Pedidos.FindAsync(id); // Busca o pedido pelo Id
        if (pedido == null) return false; // Se não encontrar, retorna falso

        _context.Pedidos.Remove(pedido); // Remove o pedido da tabela
        await _context.SaveChangesAsync(); // Salva as alterações no banco de dados
        return true; // Retorna verdadeiro indicando que o pedido foi removido
    }
}