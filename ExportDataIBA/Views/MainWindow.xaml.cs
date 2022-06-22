using System.Globalization;
using System.Windows;

namespace ExportDataIBA
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            ExportData.UI.Properties.Resource.Culture = CultureInfo.GetCultureInfo("ru-RU");
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
