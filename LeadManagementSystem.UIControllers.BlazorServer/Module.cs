using DevExpress.ExpressApp;

namespace LeadManagementSystem.UIControllers.BlazorServer;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
public sealed class BlazorServerModule : ModuleBase
{
    public BlazorServerModule()
    {
        RequiredModuleTypes.Add(typeof(DevExpress.ExpressApp.SystemModule.SystemModule));
    }
}