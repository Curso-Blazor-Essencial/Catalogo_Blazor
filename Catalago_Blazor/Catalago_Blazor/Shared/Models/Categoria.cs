using System.ComponentModel.DataAnnotations;

namespace Catalago_Blazor.Shared.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Descricao { get; set; }

        // Criando uma coleção de Produtos para fazer o relaciomento entre as classes
        public ICollection<Produto> Produtos { get; set; }

    }
}

