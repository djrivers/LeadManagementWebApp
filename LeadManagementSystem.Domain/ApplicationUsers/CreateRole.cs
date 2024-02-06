using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;
using LeadManagementSystem.Module.BusinessObjects;

namespace LeadManagementSystem.Domain.ApplicationUsers;

public class CreateRole
{
    // Role for Application Administrator
    public static PermissionPolicyRole AppAdmin(IObjectSpace objectSpace)
    {
        var role = objectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "AppAdmin");
        if (role == null)
        {
            role = objectSpace.CreateObject<PermissionPolicyRole>();
            role.Name = "AppAdmin";
            role.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;

            // Navigation permission 
            role.AddNavigationPermission(@"Application/NavigationItems/Items/Reports/Items/Dashboards",
                                         SecurityPermissionState.Deny);
            //Application/NavigationItems/Items/Reports/Items/ReportsV2
            role.AddNavigationPermission(@"Application/NavigationItems/Items/Reports/Items/ReportsV2",
                                         SecurityPermissionState.Deny);
            
            // System permissions
            role.AddTypePermission<ReportDataV2>(SecurityOperations.FullAccess, SecurityPermissionState.Deny);
            role.AddTypePermission<ReportDataV2>(SecurityOperations.ReadOnlyAccess, SecurityPermissionState.Allow);
            
        }

        return role;
    }

    public static PermissionPolicyRole SysAdmin(IObjectSpace objectSpace)
    {
        var adminRole = objectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "SysAdministrator");
        if (adminRole == null)
        {
            adminRole = objectSpace.CreateObject<PermissionPolicyRole>();
            adminRole.Name = "SysAdministrator";
        }

        adminRole.IsAdministrative = true;
        objectSpace.CommitChanges();

        return adminRole;
    }
    
    public static PermissionPolicyRole Agent(IObjectSpace objectSpace)
    {
        var agentRole = objectSpace.FirstOrDefault<PermissionPolicyRole>(r => r.Name == "Agent Role");
        if(agentRole is not null) return agentRole;
        
        agentRole = objectSpace.CreateObject<PermissionPolicyRole>();
        agentRole.Name = "Agent Role";
        agentRole.PermissionPolicy = SecurityPermissionPolicy.AllowAllByDefault;
        
        // Application User Permissions
        agentRole.AddObjectPermissionFromLambda<ApplicationUser>(SecurityOperations.FullObjectAccess,
            o => o.ID != (Guid)CurrentUserIdOperator.CurrentUserId(), SecurityPermissionState.Deny);
        agentRole.AddTypePermissionsRecursively<ApplicationUser>(SecurityOperations.Create,
            SecurityPermissionState.Deny);
        agentRole.AddTypePermissionsRecursively<ApplicationUser>(SecurityOperations.Delete,
            SecurityPermissionState.Deny);
        agentRole.AddMemberPermissionFromLambda<ApplicationUser>( SecurityOperations.Write, "Email",
            null, SecurityPermissionState.Deny);
        agentRole.AddMemberPermissionFromLambda<ApplicationUser>( SecurityOperations.Write, "UserName",
            null, SecurityPermissionState.Deny);
        agentRole.AddMemberPermissionFromLambda<ApplicationUser>( SecurityOperations.Read, "UserName",
            x => x.UserName == "Admin" , SecurityPermissionState.Deny);
        agentRole.AddMemberPermissionFromLambda<ApplicationUser>( SecurityOperations.Read, "UserName",
            null, SecurityPermissionState.Allow);
        agentRole.AddMemberPermissionFromLambda<ApplicationUser>( SecurityOperations.Write, "IsActive",
            null, SecurityPermissionState.Deny);
        
        
        // Permission Policy Role Permissions
        agentRole.AddObjectPermissionFromLambda<PermissionPolicyRole>(SecurityOperations.FullObjectAccess,
            null, SecurityPermissionState.Deny);
        agentRole.AddTypePermissionsRecursively<PermissionPolicyRole>(SecurityOperations.CRUDAccess,
            SecurityPermissionState.Deny);
        
        // Binder Log Permissions
        // agentRole.AddTypePermissionsRecursively<BinderLog>(SecurityOperations.Delete,
        //     SecurityPermissionState.Deny);
        //
        // // Import Data
        // agentRole.AddNavigationPermission(@"Application/NavigationItems/Items/ImportData",
        //     SecurityPermissionState.Deny);
        //
        // // Hit List
        // agentRole.AddTypePermissionsRecursively<ExclusionHitList>( SecurityOperations.Write, SecurityPermissionState.Deny);
        // agentRole.AddTypePermissionsRecursively<ExclusionHitList>( SecurityOperations.Delete, SecurityPermissionState.Deny);
        
        
        objectSpace.CommitChanges();
        return agentRole;
    }
}