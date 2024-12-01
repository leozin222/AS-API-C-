using SistemaPedidosFornecedores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidosFornecedores.Repositories
{
    // A interface define os métodos que a implementação do repositório deverá ter.
    // Essas operações representam as ações CRUD para os fornecedores.
    public interface IFornecedorRepository
    {
        // Método assíncrono para obter todos os fornecedores
        Task<List<Fornecedor>> GetAllFornecedoresAsync();

        // Método assíncrono para obter um fornecedor específico pelo seu ID
        Task<Fornecedor> GetFornecedorByIdAsync(int id);

        // Método assíncrono para criar um novo fornecedor
        Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor);

        // Método assíncrono para atualizar as informações de um fornecedor existente
        Task UpdateFornecedorAsync(Fornecedor fornecedor);

        // Método assíncrono para excluir um fornecedor pelo ID
        Task<bool> DeleteFornecedorAsync(int id);
    }
}