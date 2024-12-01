using Microsoft.AspNetCore.Mvc;
using SistemaPedidosFornecedores.Models;
using SistemaPedidosFornecedores.Repositories;

namespace SistemaPedidosFornecedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        // Injeção de dependência para acessar o repositório de Pedidos
        private readonly IPedidoRepository _pedidoRepository;

        public PedidosController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository; // Inicializa o repositório de pedidos
        }

        // Endpoint GET para obter todos os pedidos
        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            var pedidos = await _pedidoRepository.GetAllPedidosAsync(); // Chama o repositório para obter todos os pedidos
            return Ok(pedidos); // Retorna os pedidos encontrados com status 200 OK
        }

        // Endpoint GET para obter um pedido específico pelo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPedidoById(int id)
        {
            var pedido = await _pedidoRepository.GetPedidoByIdAsync(id); // Busca o pedido pelo Id
            if (pedido == null) return NotFound(); // Se o pedido não for encontrado, retorna 404 Not Found
            return Ok(pedido); // Caso contrário, retorna o pedido com status 200 OK
        }

        // Endpoint POST para criar um novo pedido
        [HttpPost]
        public async Task<IActionResult> CreatePedido(Pedido pedido)
        {
            var newPedido = await _pedidoRepository.CreatePedidoAsync(pedido); // Cria o novo pedido
            return CreatedAtAction(nameof(GetPedidoById), new { id = newPedido.Id }, newPedido); // Retorna status 201 Created com o novo pedido
        }

        // Endpoint PUT para atualizar um pedido existente
        [HttpPut("{id} 
        public async Task<IActionResult> UpdatePedido(int id, Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest(); // Se o Id da URL não corresponder ao Id do corpo, retorna BadRequest
            await _pedidoRepository.UpdatePedidoAsync(pedido); // Atualiza o pedido
            return NoContent(); // Retorna status 204 No Content (sem corpo na resposta)
        }

        // Endpoint DELETE para excluir um pedido pelo Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedido(int id)
        {
            var result = await _pedidoRepository.DeletePedidoAsync(id); // Tenta excluir o pedido
            if (!result) return NotFound(); // Se o pedido não for encontrado, retorna 404 Not Found
            return NoContent(); // Caso contrário, retorna 204 No Content (sem corpo na resposta)
        }
    }
}