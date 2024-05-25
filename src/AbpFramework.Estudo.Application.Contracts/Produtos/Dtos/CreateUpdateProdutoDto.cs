using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AbpFramework.Estudo.Produtos.Dtos
{
    public class CreateUpdateProdutoDto
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Preço")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Não é possível inserir um produto sem definir uma Categoria!")]
        public Guid CategoriaId { get; set; }

        [Required(ErrorMessage = "Não é possível inserir um produto sem definir um Fornecedor!")]
        public Guid FornecedorId { get; set; }
    }
}
