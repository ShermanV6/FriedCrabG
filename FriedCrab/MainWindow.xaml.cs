using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FriedCrab
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MoveCursorMenu(int index)
        {
            TrainsitionigContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (120 + (60 * index)), 0, 0);
        }

        private void btnCollapseMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Collapsed;
            btnOpenMenu.Visibility = Visibility.Visible;
            
        }

        private void btnOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            btnCollapseMenu.Visibility = Visibility.Visible;
            btnOpenMenu.Visibility = Visibility.Collapsed;

        }

        private void lvwMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvwMenu.SelectedIndex;
            MoveCursorMenu(index);

            UserControl usc = null;

            gridMain.Children.Clear();

            switch (((ListViewItem)(((ListView)sender).SelectedItem)).Name)
            {
                case "itemInicio":
                    
                    break;
                case "itemProducto":
                    usc = new Product.uscProduct();
                    break;
                case "itemProveedor":
                    usc = new Supplier.uscProveedor();
                    break;
                case "itemUsuario":
                    usc = new Users.uscUsers();
                    break;
                case "itemVentas":
                    
                    break;
                case "itemSucursal":
                    
                    break;


            }
            if (usc != null)
            {
                gridMain.Children.Add(usc);
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Acercade_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            gridMain.Children.Clear();
            usc = new AcercaDe.uscAcercaDe();
            gridMain.Children.Add(usc);
        }
    }
}
