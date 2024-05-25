using System.Threading.Tasks;
using AbpFramework.Estudo.Localization;
using AbpFramework.Estudo.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace AbpFramework.Estudo.Web.Menus;

public class EstudoMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<EstudoResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                EstudoMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        context.Menu.Items.Insert(1, new ApplicationMenuItem(EstudoMenus.GerenciamentoProdutos, "Gerenciamento de Produtos", "~/", icon: "fa-solid fa-folder-closed", order: 1));

        if (MultiTenancyConsts.IsEnabled)
        {
            administration.SetSubItemOrder(TenantManagementMenuNames.GroupName, 1);
        }
        else
        {
            administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        }

        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 2);
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        var gerenciamentoProduto = context.Menu.GetMenuItem(EstudoMenus.GerenciamentoProdutos);
        gerenciamentoProduto.Items.Insert(0, new ApplicationMenuItem(EstudoMenus.Categoria, "Categorias", "/Categorias", icon: "fa-solid fa-list", order: 0));
        gerenciamentoProduto.Items.Insert(0, new ApplicationMenuItem(EstudoMenus.Produto, "Produtos", "/Produtos", icon: "fa-solid fa-lightbulb", order: 1));
        gerenciamentoProduto.Items.Insert(0, new ApplicationMenuItem(EstudoMenus.Fornecedor, "Fornecedores", "/Fornecedores", icon: "fa-solid fa-truck-fast", order: 2));

        return Task.CompletedTask;
    }
}
