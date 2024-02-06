﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;

namespace LeadManagementSystem.Domain;

public sealed class PersistenceModule : ModuleBase
{
    public PersistenceModule()
    {
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
    }

    public override IEnumerable<ModuleUpdater> GetModuleUpdaters(IObjectSpace objectSpace, Version versionFromDb)
    {
        ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDb);
        return new[] { updater };
    }
}