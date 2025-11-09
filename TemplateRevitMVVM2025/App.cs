using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace TemplateRevitMVVM2025
{
    public class App : IExternalApplication
    {

        public Result OnStartup(UIControlledApplication app)
        {
            // Путь к текущей сборке
            string assemblyPath = Assembly.GetExecutingAssembly().Location;

            // Создаем кастомную вкладку
            app.CreateRibbonTab("МоиПлагины");

            // Создаем панель на вкладке
            RibbonPanel ribbonPanel = app.CreateRibbonPanel("МоиПлагины", "МояГруппа");

            // Создаем кнопку
            Image img = Properties.Resources.icon32x32;

            AddButton(ribbonPanel, "МойПлагин", assemblyPath, "TemplateRevitMVVM2025.MyCommand", "Описание плагина", img);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            return Result.Succeeded;
        }


        public BitmapImage Convert(Image img)
        {
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }

        private void AddButton(RibbonPanel ribbonPanel, string buttonName, string path, string linkToCommand, string toolTip, Image img)
        {
            PushButtonData buttonData = new PushButtonData(
                buttonName, // Уникальный идентификатор
                buttonName,  // Надпись на кнопке
                path, // Путь к сборке
                linkToCommand); // Полное имя класса команды

            PushButton button = ribbonPanel.AddItem(buttonData) as PushButton;
            button.ToolTip = toolTip;
            ImageSource imgConvert = Convert(img);
            button.LargeImage = imgConvert;
            button.Image = imgConvert;
        }

    }
}
