using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using LeadManagementSystem.Module.BusinessObjects;

namespace LeadManagementSystem.Domain.ApplicationUsers;

public class CreateUser
{
    public static ApplicationUser AppAdmin(IObjectSpace objectSpace)
    {
        var brgyAdmin = objectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "AppAdmin");
        if (brgyAdmin == null)
        {
            brgyAdmin = objectSpace.CreateObject<ApplicationUser>();
            brgyAdmin.UserName = "AppAdmin";
            // Set a password if the standard authentication type is used
            brgyAdmin.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            objectSpace.CommitChanges(); //This line persists created object(s).
            ((ISecurityUserWithLoginInfo)brgyAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication,
                                                                        objectSpace.GetKeyValueAsString(brgyAdmin));
        }

        return brgyAdmin;
    }

    public static ApplicationUser Admin(IObjectSpace objectSpace)
    {
        var userAdmin = objectSpace.FirstOrDefault<ApplicationUser>(u => u.UserName == "Admin");
        if (userAdmin == null)
        {
            userAdmin = objectSpace.CreateObject<ApplicationUser>();
            userAdmin.UserName = "Admin";
            // Set a password if the standard authentication type is used
            userAdmin.SetPassword("");

            // The UserLoginInfo object requires a user object Id (Oid).
            // Commit the user object to the database before you create a UserLoginInfo object. This will correctly initialize the user key property.
            objectSpace.CommitChanges(); //This line persists created object(s).
            ((ISecurityUserWithLoginInfo)userAdmin).CreateUserLoginInfo(SecurityDefaults.PasswordAuthentication,
                                                                        objectSpace.GetKeyValueAsString(userAdmin));
        }

        return userAdmin;
    }
}