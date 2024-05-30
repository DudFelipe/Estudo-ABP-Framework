using AbpFramework.Estudo.Produtos.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AbpFramework.Estudo.Produtos
{
    public interface IProdutoAppService : ICrudAppService<ProdutoDto, Guid, ProdutoGetListInput, CreateUpdateProdutoDto, CreateUpdateProdutoDto>
    {
        Task<ProdutoDto> GetWithImages(Guid id);
        Task<List<ProdutoDto>> GetWithImages();
    }
}
