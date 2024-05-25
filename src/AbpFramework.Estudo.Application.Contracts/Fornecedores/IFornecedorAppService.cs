using AbpFramework.Estudo.Fornecedores.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpFramework.Estudo.Fornecedores
{
    public interface IFornecedorAppService : ICrudAppService<FornecedorDto, Guid, FornecedorGetListInput, CreateFornecedorDto, UpdateFornecedorDto>
    {
        Task<ListResultDto<FornecedorDto>> GetFornecedoresAsync();
    }
}
