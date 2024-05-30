using AbpFramework.Estudo.Produtos.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace AbpFramework.Estudo.Produtos
{
    public class ProdutoAppService : ApplicationService, IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoManager _produtoManager;
        private readonly IImagemProdutoManager _imagemProdutoManager;

        public ProdutoAppService(IProdutoRepository produtoRepository,
                                 IProdutoManager produtoManager,
                                 IImagemProdutoManager imagemProdutoManager)
        {
            _produtoRepository = produtoRepository;
            _produtoManager = produtoManager;
            _imagemProdutoManager = imagemProdutoManager;
        }

        public async Task<ProdutoDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Produto, ProdutoDto>(await _produtoRepository.GetAsync(p => p.Id == id));
        }

        public async Task<ProdutoDto> GetWithImages(Guid id)
        {
            var produto = await _produtoRepository.WithDetailsAndImagesAsync(id);

            return ObjectMapper.Map<Produto, ProdutoDto>(produto.FirstOrDefault());
        }

        public async Task<List<ProdutoDto>> GetWithImages()
        {
            var produtos = await _produtoRepository.WithDetailsAndImagesAsync();

            return ObjectMapper.Map<List<Produto>, List<ProdutoDto>>(produtos);
        }

        public async Task<PagedResultDto<ProdutoDto>> GetListAsync(ProdutoGetListInput input)
        {
            var produtos = await _produtoRepository.WithDetailsAsync();

            var produtosQueryable = produtos
                .WhereIf(!input.Nome.IsNullOrWhiteSpace(), x => x.Nome.Contains(input.Nome))
                .WhereIf(input.Preco > 0, x => x.Preco == input.Preco)
                .WhereIf(input.CategoriaId.HasValue, x => x.CategoriaId == input.CategoriaId)
                .WhereIf(input.FornecedorId.HasValue, x => x.FornecedorId == input.FornecedorId)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
                .OrderBy(input.Sorting != null ? input.Sorting : nameof(input.Nome))
                .ToList();

            return new PagedResultDto<ProdutoDto>(produtosQueryable.Count, ObjectMapper.Map<List<Produto>, List<ProdutoDto>>(produtosQueryable));
        }

        public async Task<ProdutoDto> CreateAsync(CreateUpdateProdutoDto input)
        {
            var produto = ObjectMapper.Map<CreateUpdateProdutoDto, Produto>(input);

            return ObjectMapper.Map<Produto, ProdutoDto>(await _produtoManager.Inserir(produto));
        }

        public async Task<ProdutoDto> UpdateAsync(Guid id, CreateUpdateProdutoDto input)
        {
            var produto = await _produtoRepository.GetAsync(x => x.Id == id);

            if(id != produto.Id)
                throw new EntityNotFoundException("Categoria não encontrada");

            produto.SetNome(input.Nome);
            produto.SetPreco(input.Preco);
            produto.SetCategoria(input.CategoriaId);
            produto.SetImagens(ObjectMapper.Map<List<ImagemProdutoDto>, List<ImagemProduto>>(input.Imagens));
            produto.SetDescricao(input.Descricao);

            await _imagemProdutoManager.Excluir(i => i.ProdutoId == produto.Id);

            return ObjectMapper.Map<Produto, ProdutoDto>(await _produtoManager.Alterar(produto));
        }

        public async Task DeleteAsync(Guid id)
        {
            var produto = await _produtoRepository.GetAsync(x => x.Id == id);

            await _produtoManager.Excluir(produto, true, default);
        }
    }
}
