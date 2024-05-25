using AbpFramework.Estudo.Categorias.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Categorias
{
    public class CategoriaAppService : ApplicationService, ICategoriaAppService
    {
        private readonly ICategoriaManager _manager;
        private readonly ICategoriaRepository _repository;

        public CategoriaAppService(ICategoriaManager manager, ICategoriaRepository repository)
        {
            _manager = manager;
            _repository = repository;
        }

        public async Task<CategoriaDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Categoria, CategoriaDto>(await _repository.GetAsync(c => c.Id == id));
        }

        public async Task<PagedResultDto<CategoriaDto>> GetListAsync(CategoriaGetListInput input)
        {
            var categorias = await _repository.GetQueryableAsync();

            var categoriasQueryable = categorias
                .WhereIf(!input.Nome.IsNullOrWhiteSpace(), x => x.Nome.Contains(input.Nome))
                .WhereIf(!input.Descricao.IsNullOrWhiteSpace(), x => x.Descricao.Contains(input.Descricao))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting != null ? input.Sorting : nameof(input.Nome))
                .ToList();

            return new PagedResultDto<CategoriaDto>(categoriasQueryable.Count,ObjectMapper.Map<List<Categoria>, List<CategoriaDto>>(categoriasQueryable));
        }

        public async Task<ListResultDto<CategoriaDto>> GetCategoriasAsync()
        {
            var categorias = await _repository.GetListAsync();
            var itens = ObjectMapper.Map<List<Categoria>, List<CategoriaDto>>(categorias);

            return new ListResultDto<CategoriaDto>(itens);
        }

        public async Task<CategoriaDto> CreateAsync(CreateUpdateCategoriaDto input)
        {
            var categoria = ObjectMapper.Map<CreateUpdateCategoriaDto, Categoria>(input);

            await _manager.Inserir(categoria);

            return ObjectMapper.Map<Categoria, CategoriaDto>(categoria);
        }

        public async Task<CategoriaDto> UpdateAsync(Guid id, CreateUpdateCategoriaDto input)
        {
            var categoria = await _repository.GetAsync(c => c.Id == id);

            if (categoria == null)
                throw new EntityNotFoundException("Categoria não encontrada");

            categoria.SetNome(input.Nome);
            categoria.SetDescricao(input.Descricao);

            await _manager.Alterar(categoria);

            return ObjectMapper.Map<Categoria, CategoriaDto>(categoria);
        }

        public async Task DeleteAsync(Guid id)
        {
            var categoria = await _repository.GetAsync(c => c.Id == id);

            await _manager.Excluir(categoria, true, default);
        }
    }
}
