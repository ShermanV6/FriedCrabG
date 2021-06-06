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

namespace FriedCrab.Product
{
    /// <summary>
    /// Lógica de interacción para uscProduct.xaml
    /// </summary>
    public partial class uscProduct : UserControl
    {
        public uscProduct()
        {
            InitializeComponent();
        }

        private void btnProduct_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            usc = new Product.uscProductCRUD();
            gridProduct.Children.Add(usc);
        }

        private void btnIngredient_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = null;
            usc = new Product.uscIngredient();
            gridProduct.Children.Add(usc);
        }
    }
}
