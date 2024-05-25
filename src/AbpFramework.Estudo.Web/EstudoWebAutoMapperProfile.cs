using AbpFramework.Estudo.Categorias.Dtos;
using AbpFramework.Estudo.Fornecedores.Dtos;
using AbpFramework.Estudo.Produtos.Dtos;
using AbpFramework.Estudo.Web.Pages.Categorias.ViewModels;
using AbpFramework.Estudo.Web.Pages.Fornecedores.ViewModels;
using AbpFramework.Estudo.Web.Pages.Produtos.ViewModels;
using AutoMapper;

namespace AbpFramework.Estudo.Web;

public class EstudoWebAutoMapperProfile : Profile
{
    public EstudoWebAutoMapperProfile()
    {
        //Define your AutoMapper configuration here for the Web project.
        CreateMap<CategoriaDto, CreateEditCategoriaViewModel>();
        CreateMap<CreateEditCategoriaViewModel, CreateUpdateCategoriaDto>();

        CreateMap<ProdutoDto, CreateEditProdutoViewModel>();
        CreateMap<CreateEditProdutoViewModel, CreateUpdateProdutoDto>();

        CreateMap<FornecedorDto, CreateFornecedorViewModel>();
        CreateMap<FornecedorDto, UpdateFornecedorViewModel>();
        CreateMap<CreateFornecedorViewModel, CreateFornecedorDto>();
        CreateMap<UpdateFornecedorViewModel, UpdateFornecedorDto>();
    }
}
