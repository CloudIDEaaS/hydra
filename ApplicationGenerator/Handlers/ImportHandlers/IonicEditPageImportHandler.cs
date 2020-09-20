using AbstraX.Handlers.ImportHandlers.Packages;

namespace AbstraX.Handlers.ImportHandlers
{
    [ImportHandler(ModuleImports.IONICEDITPAGE_HANDLER_ID)]
    public class IonicEditPageImportHandler : IonicImportHandler
    {
        public override void AddImport(ulong moduleId)
        {
            base.AddImport((IonicEditPageModules)moduleId);
        }
    }
}
