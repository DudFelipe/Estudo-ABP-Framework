using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Fornecedores.Dtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AbpFramework.Estudo.Web.Pages.Categorias.ViewModels;
using AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels;
using AbpFramework.Estudo.Web.Pages.Loja.ViewModels;
using AbpFramework.Estudo.Web.Pages.Produtos.ViewModels;
using AutoMapper;

namespace AbpFramework.Estudo.Web;

public class EstudoWebAutoMapperProfile : Profile
{
    public EstudoWebAutoMapperProfile()
    {
        //Categorias
        CreateMap<CategoriaDto, CreateEditCategoriaViewModel>();
        CreateMap<CreateEditCategoriaViewModel, CreateUpdateCategoriaDto>();

        //Produtos
        CreateMap<ProdutoDto, CreateEditProdutoViewModel>();
        CreateMap<ProdutoDto, DetailProdutoViewModel>()
            .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria.Nome))
            .ForMember(dest => dest.Fornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        CreateMap<CreateEditProdutoViewModel, CreateUpdateProdutoDto>();

        //Imagens dos produtos
        CreateMap<ImagemProdutoViewModel, ImagemProdutoDto>().ReverseMap();

        //Loja
        CreateMap<ProdutoDto, ProdutoViewModel>();

        //Fornecedores
        CreateMap<FornecedorDto, CreateFornecedorViewModel>();
        CreateMap<FornecedorDto, UpdateFornecedorViewModel>();
        CreateMap<CreateFornecedorViewModel, CreateFornecedorDto>();
        CreateMap<UpdateFornecedorViewModel, UpdateFornecedorDto>();
    }
}
