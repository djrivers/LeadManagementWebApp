using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace LeadManagementSystem.Application;

public sealed class ApplicationModule : ModuleBase
{
    public ApplicationModule()
    {
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb)
    {
        ModuleUpdater updater = new Domain.DatabaseUpdate.Updater(objectSpace, versionFromDb);
        return new[] { updater };
    }
}