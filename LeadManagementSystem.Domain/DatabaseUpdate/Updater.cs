using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Updating;
using LeadManagementSystem.Domain.ApplicationUsers;

namespace LeadManagementSystem.Domain.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();
        
        var adminUser = CreateUser.Admin(ObjectSpace);
        var adminRole = CreateRole.SysAdmin(ObjectSpace);
        adminUser.Roles.Add(adminRole);

        var appAdmin = CreateUser.AppAdmin(ObjectSpace);
        var appAdminRole = CreateRole.AppAdmin(ObjectSpace);
        appAdmin.Roles.Add(appAdminRole);
        
        _ = CreateRole.Agent(ObjectSpace);

        ObjectSpace.CommitChanges();
    }
}
