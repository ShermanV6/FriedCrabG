using System;
using System.Collections.Generic;
using System.Data;
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
using DAO.Implementation;
using DAO.Model;

namespace FriedCrab.Product
{
    /// <summary>
    /// Lógica de interacción para uscIngredient.xaml
    /// </summary>
    public partial class uscIngredient : UserControl
    {
        IngredientImpl implIngredient;
        Ingredients ingredient;
        sbyte option = -1;

        public uscIngredient()
        {
            InitializeComponent();
        }

        void LoadDataGrid()
        {
            try
            {
                implIngredient = new IngredientImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implIngredient.Select().DefaultView;
                dgvDatos.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void EnableButtons()
        {
            btnInsert.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            btnDelete.IsEnabled = false;

            btnSave.IsEnabled = true;
            btnCancel.IsEnabled = true;
            txtNameIngredient.IsEnabled = true;
            txtNameIngredient.Focus();
        }

        void DisabledButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtNameIngredient.IsEnabled = false;
            txtNameIngredient.Text = "";

        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 1;
            stpDatos.Visibility = Visibility.Visible;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            EnableButtons();
            this.option = 2;
            stpDatos.Visibility = Visibility.Visible;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                if (MessageBox.Show("Está realemente segur@ \nde eliminar el registro?", "Eliminar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        implIngredient = new IngredientImpl();
                        int res = implIngredient.Delete(ingredient);
                        if (res > 0)
                        {
                            MessageBox.Show("Se eliminó el registro de la Base de Datos");
                            LoadDataGrid();
                            txtNameIngredient.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (this.option)
            {
                case 1://Insert
                    try
                    {
                        ingredient = new Ingredients(txtNameIngredient.Text,3);
                        implIngredient = new IngredientImpl();
                        int res = implIngredient.Insert(ingredient);
                        if (res > 0)
                        {
                            MessageBox.Show("Registro Insertado con éxito");
                            DisabledButtons();
                            LoadDataGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
                case 2://Update
                    try
                    {
                        ingredient.IngredientName = txtNameIngredient.Text;
                        implIngredient = new IngredientImpl();
                        int res = implIngredient.Update(ingredient);
                        if (true)
                        {
                            MessageBox.Show(res + " Registro Modificado");
                            LoadDataGrid();
                            DisabledButtons();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
            stpDatos.Visibility = Visibility.Collapsed;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DisabledButtons();
            stpDatos.Visibility = Visibility.Collapsed;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
            DisabledButtons();
        }

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implIngredient = new IngredientImpl();
                    ingredient = implIngredient.Get(id);

                    txtNameIngredient.Text = ingredient.IngredientName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCollapseOpen_Click(object sender, RoutedEventArgs e)
        {
            btnCollapse.Visibility = Visibility.Visible;
            btnCollapseOpen.Visibility = Visibility.Collapsed;

            gridButtons.Visibility = Visibility.Visible;
        }

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            btnCollapse.Visibility = Visibility.Collapsed;
            btnCollapseOpen.Visibility = Visibility.Visible;

            gridButtons.Visibility = Visibility.Visible;
        }
    }
}
