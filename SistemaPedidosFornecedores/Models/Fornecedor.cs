// Classe que representa a entidade Fornecedor no sistema
public class Fornecedor
{
    // Identificador único do fornecedor 
    public int Id { get; set; }

    // Nome do fornecedor
    public string Nome { get; set; }

    // CNPJ do fornecedor
    public string Cnpj { get; set; }

    // Número de telefone do fornecedor
    public string Telefone { get; set; }

    // E-mail de contato do fornecedor
    public string Email { get; set; }

    // Endereço do fornecedor
    public string Endereco { get; set; }
}