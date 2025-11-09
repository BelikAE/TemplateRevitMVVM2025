using System.Windows;
using Autodesk.Revit.UI;
using TemplateRevitMVVM2025.ViewModel;

namespace TemplateRevitMVVM2025.View
{
    public partial class WindowView : Window
    {
        public WindowView(ExternalCommandData commandData)
        {
            InitializeComponent();  //инициализируем компоненты
            MainViewModel vm = new MainViewModel(commandData);  //создаем MainViewModel
            vm.CloseRequest += (s, e) => this.Close();  //Создаем событие на закрытие окна интерфейса
            vm.HideRequest += (s, e) => this.Hide();  //Создаем событие на скрытие окна интерфейса
            vm.ShowRequest += (s, e) => this.Show();  //Создаем событие на октрытие окна интерфейса
            DataContext = vm;   //Привязывает MainViewModel к WindowView
        }
    }
}
