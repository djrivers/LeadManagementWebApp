using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace LeadManagementSystem.Infrastructure;

public sealed class InfrastructureModule : ModuleBase
{
    public InfrastructureModule()
    {
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb)
    {
        ModuleUpdater updater = new Domain.DatabaseUpdate.Updater(objectSpace, versionFromDb);
        return new[] { updater };
    }
}