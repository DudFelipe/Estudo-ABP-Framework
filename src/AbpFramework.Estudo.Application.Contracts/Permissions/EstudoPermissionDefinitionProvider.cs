using AbpFramework.Estudo.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace AbpFramework.Estudo.Permissions;

public class EstudoPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(EstudoPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EstudoPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EstudoResource>(name);
    }
}
