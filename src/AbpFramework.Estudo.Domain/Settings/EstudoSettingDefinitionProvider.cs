using Volo.Abp.Settings;

namespace AbpFramework.Estudo.Settings;

public class EstudoSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(EstudoSettings.MySetting1));
    }
}
