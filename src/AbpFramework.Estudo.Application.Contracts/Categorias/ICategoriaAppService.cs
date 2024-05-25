using AbpFramework.Estudo.Categorias.Dtos;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFramework.Estudo.Categorias
{
    public interface ICategoriaAppService : ICrudAppService<CategoriaDto, Guid, CategoriaGetListInput, CreateUpdateCategoriaDto, CreateUpdateCategoriaDto>
    {
        Task<ListResultDto<CategoriaDto>> GetCategoriasAsync();
    }
}
