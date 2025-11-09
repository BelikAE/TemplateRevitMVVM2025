using Autodesk.Revit.DB;

namespace TemplateRevitMVVM2025.Model
{
    public class RevitCommand
    {
        public static List<WallType> GetWallType(Document doc)
        {
            List<WallType> wallTypes = new FilteredElementCollector(doc)
                                                        .OfClass(typeof(WallType))
                                                        .Cast<WallType>()
                                                        .ToList();
            return wallTypes;
        }
    }
}
