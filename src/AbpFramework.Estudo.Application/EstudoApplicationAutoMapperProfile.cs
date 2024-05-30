using AbpFramework.Estudo.Categorias;
using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Fornecedores;
using AbpFramework.Estudo.Fornecedores.Dtos;
using AbpFramework.Estudo.Produtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Dtos;

namespace AbpFramework.Estudo;

public class EstudoApplicationAutoMapperProfile : Profile
{
    public EstudoApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Categoria, CategoriaDto>().ReverseMap();
        CreateMap<List<Categoria>, PagedResultDto<CategoriaDto>>().ReverseMap();
        CreateMap<CreateUpdateCategoriaDto, Categoria>(MemberList.Source).ReverseMap();

        CreateMap<Produto, ProdutoDto>().ReverseMap();
        //CreateMap<List<Produto>, List<ProdutoDto>>().ReverseMap();
        CreateMap<List<Produto>, PagedResultDto<ProdutoDto>>().ReverseMap();
        CreateMap<CreateUpdateProdutoDto, Produto>(MemberList.Source).ReverseMap();

        CreateMap<Fornecedor, FornecedorDto>().ReverseMap();
        CreateMap<List<Fornecedor>, PagedResultDto<FornecedorDto>>().ReverseMap();
        CreateMap<CreateFornecedorDto, Fornecedor>(MemberList.Source).ReverseMap();
        CreateMap<UpdateFornecedorDto, Fornecedor>(MemberList.Source).ReverseMap();

        CreateMap<ImagemProduto, ImagemProdutoDto>().ReverseMap();
    }
}
