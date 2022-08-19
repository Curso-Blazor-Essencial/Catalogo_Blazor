using System.ComponentModel.DataAnnotations;

namespace Catalago_Blazor.Shared.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        public string ImagemUrl { get; set; }

        // Indica o relacionamento do produto com 1 categoria
        public int CategoriaId { get; set; }
        // Propriedade de navegação
        public virtual Categoria Categoria { get; set; }
    }
}
