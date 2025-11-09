using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevitMVVM2025.View;

namespace TemplateRevitMVVM2025
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            var windowView = new WindowView(commandData); //Создаем новый интерфейс WindowView
            windowView.Show(); //Открываем окно интерфейса

            return Result.Succeeded;
        }
    }
}