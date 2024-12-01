using Microsoft.AspNetCore.Mvc;
using SistemaPedidosFornecedores.Models;
using SistemaPedidosFornecedores.Repositories;

namespace SistemaPedidosFornecedores.Controllers
{
    // Define a rota para o controlador. [controller] será substituído por "fornecedores"
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        // Injeção de dependência para acessar o repositório de Fornecedores
        private readonly IFornecedorRepository _fornecedorRepository;

        // Construtor que recebe o repositório de fornecedores através da injeção de dependência
        public FornecedoresController(IFornecedorRepository fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository; // Inicializa o repositório de fornecedores
        }

        // Endpoint GET para obter todos os fornecedores
        [HttpGet]
        public async Task<IActionResult> GetAllFornecedores()
        {
            // Chama o repositório para obter todos os fornecedores
            var fornecedores = await _fornecedorRepository.GetAllFornecedoresAsync();
            return Ok(fornecedores); // Retorna os fornecedores encontrados com status 200 OK
        }

        // Endpoint GET para obter um fornecedor específico pelo Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFornecedorById(int id)
        {
            // Busca o fornecedor pelo Id
            
            if (fornecedor == null) return NotFound(); // Se o fornecedor não for encontrado, retorna 404 Not Found
            return Ok(fornecedor); // Caso contrário, retorna o fornecedor com status 200 OK
        }

        // Endpoint POST para criar um novo fornecedor
        [HttpPost]
        public async Task<IActionResult> CreateFornecedor(Fornecedor fornecedor)
        {
            // Cria o novo fornecedor no banco de dados
            var newFornecedor = await _fornecedorRepository.CreateFornecedorAsync(fornecedor);
            return CreatedAtAction(nameof(GetFornecedorById), new { id = newFornecedor.Id }, newFornecedor); 
            // Retorna status 201 Created com o novo fornecedor, incluindo o Id gerado
        }

        // Endpoint PUT para atualizar um fornecedor existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFornecedor(int id, Fornecedor fornecedor)
        {
            // Verifica se o Id na URL corresponde ao Id do objeto no corpo da requisição
            if (id != fornecedor.Id) return BadRequest(); // Se não corresponder, retorna 400 BadRequest

            // Atualiza as informações do fornecedor
            await _fornecedorRepository.UpdateFornecedorAsync(fornecedor);
            return NoContent(); // Retorna status 204 No Content (sem corpo na resposta)
        }

        // Endpoint DELETE para excluir um fornecedor pelo Id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {
            // Tenta excluir o fornecedor
            var result = await _fornecedorRepository.DeleteFornecedorAsync(id);
            if (!result) return NotFound(); // Se o fornecedor não for encontrado, retorna 404 Not Found
            return NoContent(); // Caso contrário, retorna 204 No Content (sem corpo na resposta)
        }
    }
}