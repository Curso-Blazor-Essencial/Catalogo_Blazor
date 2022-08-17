namespace Catalago_Blazor.Shared.Models
{
    internal class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Criando uma coleção de Produtos para fazer o relaciomento entre as classes
        public ICollection<Produto> Produtos { get; set; }

    }
}
