using Microsoft.EntityFrameworkCore;
using SistemaPedidosFornecedores.Data;
using SistemaPedidosFornecedores.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedidosFornecedores.Repositories
{
    // Implementação do repositório de fornecedores, que utiliza o Entity Framework Core para acessar o banco de dados.
    public class FornecedorRepository : IFornecedorRepository
    {
        // A classe precisa de uma instância do DbContext para interagir com o banco de dados.
        private readonly ApplicationDbContext _context;

        // O construtor recebe a instância do DbContext, que é injetada pelo mecanismo de injeção de dependência.
        public FornecedorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Método para obter todos os fornecedores do banco de dados.
        public async Task<List<Fornecedor>> GetAllFornecedoresAsync()
        {
            // O método AsNoTracking() melhora a performance para leitura de dados, pois não rastreia as entidades.
            return await _context.Fornecedores.AsNoTracking().ToListAsync();
        }

        // Método para obter um fornecedor específico, identificado pelo seu ID.
        public async Task<Fornecedor> GetFornecedorByIdAsync(int id)
        {
            // Retorna o fornecedor com o ID fornecido ou null se não encontrar.
            return await _context.Fornecedores.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        // Método para criar um novo fornecedor no banco de dados.
        public async Task<Fornecedor> CreateFornecedorAsync(Fornecedor fornecedor)
        {
            // Adiciona o fornecedor ao DbContext. 
            // O Entity Framework Core irá automaticamente atribuir um ID ao novo fornecedor.
            await _context.Fornecedores.AddAsync(fornecedor);

            // Salva as mudanças no banco de dados.
            await _context.SaveChangesAsync();

            // Retorna o fornecedor recém-criado (com ID atribuído).
            return fornecedor;
        }

        // Método para atualizar um fornecedor existente.
        public async Task UpdateFornecedorAsync(Fornecedor fornecedor)
        {
            // Marca o fornecedor como modificado no DbContext.
            _context.Fornecedores.Update(fornecedor);

            // Salva as mudanças no banco de dados.
            await _context.SaveChangesAsync();
        }

        // Método para excluir um fornecedor pelo seu ID.
        public async Task<bool> DeleteFornecedorAsync(int id)
        {
            // Busca o fornecedor pelo ID.
            var fornecedor = await _context.Fornecedores.FindAsync(id);

            // Se o fornecedor não for encontrado, retorna false.
            if (fornecedor == null)
            {
                return false;
            }

            // Remove o fornecedor do DbContext.
            _context.Fornecedores.Remove(fornecedor);

            // Salva as mudanças no banco de dados e retorna true.
            await _context.SaveChangesAsync();
            return true;
        }
    }
}