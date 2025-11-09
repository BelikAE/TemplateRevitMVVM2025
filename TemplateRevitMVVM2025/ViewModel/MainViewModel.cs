using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using TemplateRevitMVVM2025.Model;

namespace TemplateRevitMVVM2025.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private ExternalCommandData _commandData;

        public DelegateCommand FindWallTypeCommand { get; }
        public DelegateCommand CloseCommand { get; }

        private List<WallType> wallsType;
        public List<WallType> WallsType
        {
            get => wallsType;
            set
            {
                wallsType = value;
                OnPropertyChanged(nameof(WallsType));
            }
        }

        public MainViewModel(ExternalCommandData commandData)
        {
            _commandData = commandData;
            FindWallTypeCommand = new DelegateCommand(OnFindWallTypeCommand);
            CloseCommand = new DelegateCommand(OnCloseCommand);
        }

        private void OnFindWallTypeCommand()
        {
            UIApplication uiapp = _commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            WallsType = RevitCommand.GetWallType(doc);
        }

        private void OnCloseCommand()
        {
            RaiseCloseRequest();
        }

    }
}
