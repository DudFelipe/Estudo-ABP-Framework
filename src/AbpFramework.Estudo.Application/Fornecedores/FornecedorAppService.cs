using AbpFramework.Estudo.Fornecedores.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Fornecedores
{
    public class FornecedorAppService : ApplicationService, IFornecedorAppService
    {
        private readonly IFornecedorManager _fornecedorManager;
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorAppService(IFornecedorManager fornecedorManager, IFornecedorRepository fornecedorRepository)
        {
            _fornecedorManager = fornecedorManager;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<FornecedorDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Fornecedor, FornecedorDto>(await _fornecedorRepository.GetAsync(x => x.Id == id));
        }

        public async Task<PagedResultDto<FornecedorDto>> GetListAsync(FornecedorGetListInput input)
        {
            var fornecedores = await _fornecedorRepository.GetQueryableAsync();

            var fornecedoresQuery = fornecedores
                .WhereIf(!input.Nome.IsNullOrWhiteSpace(), x => x.Nome.Contains(input.Nome))
                .WhereIf(!input.Cnpj.IsNullOrWhiteSpace(), x => x.Cnpj.Contains(input.Cnpj))
                .WhereIf(!input.Descricao.IsNullOrWhiteSpace(), x => x.Descricao.Contains(input.Descricao))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting != null ? input.Sorting : nameof(input.Nome))
                .ToList();

            return new PagedResultDto<FornecedorDto>(fornecedoresQuery.Count, ObjectMapper.Map<List<Fornecedor>, List<FornecedorDto>>(fornecedoresQuery));
        }

        public async Task<ListResultDto<FornecedorDto>> GetFornecedoresAsync()
        {
            var fornecedores = await _fornecedorRepository.GetListAsync();
            var itens = ObjectMapper.Map<List<Fornecedor>, List<FornecedorDto>>(fornecedores);

            return new ListResultDto<FornecedorDto>(itens);
        }

        public async Task<FornecedorDto> CreateAsync(CreateFornecedorDto input)
        {
            var fornecedor = ObjectMapper.Map<CreateFornecedorDto, Fornecedor>(input);

            await _fornecedorManager.Inserir(fornecedor);

            return ObjectMapper.Map<Fornecedor, FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> UpdateAsync(Guid id, UpdateFornecedorDto input)
        {
            var fornecedor = await _fornecedorRepository.GetAsync(x => x.Id == id);

            if(fornecedor == null)
                throw new EntityNotFoundException("Fornecedor não encontrado");

            fornecedor.SetNome(input.Nome);
            fornecedor.SetDescricao(input.Descricao);

            await _fornecedorManager.Alterar(fornecedor);

            return ObjectMapper.Map<Fornecedor, FornecedorDto>(fornecedor);
        }

        public async Task DeleteAsync(Guid id)
        {
            var fornecedor = await _fornecedorRepository.GetAsync(x => x.Id == id);

            await _fornecedorManager.Excluir(fornecedor);
        }
    }
}
