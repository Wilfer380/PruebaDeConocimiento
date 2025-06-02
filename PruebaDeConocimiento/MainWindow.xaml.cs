using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PruebaDeConocimiento.View;
using PruebaDeConocimiento.ViewModels;

namespace PruebaDeConocimiento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 1. Crear instancia del UserControl
            var recordsView = new RecordsView();

            // 2. Crear instancia del ViewModel
            var userViewModel = new UserViewModel();

            // 3. Asignar el ViewModel al DataContext del UserControl
            recordsView.DataContext = userViewModel;

            // 4. Agregar el UserControl al Grid llamado MainContainer
            MainContainer.Children.Clear();
            MainContainer.Children.Add(recordsView);
        }
    }
}