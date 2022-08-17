namespace Catalago_Blazor.Shared.Models
{
    internal class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }

        // Indica o relacionamento do produto com 1 categoria
        public int CategoriaId { get; set; }
        // Propriedade de navegação
        public virtual Categoria Categoria { get; set; }
    }
}
