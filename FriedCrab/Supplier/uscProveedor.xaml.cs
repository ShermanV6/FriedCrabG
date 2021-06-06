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

namespace FriedCrab.Supplier
{
    /// <summary>
    /// Lógica de interacción para uscProveedor.xaml
    /// </summary>
    public partial class uscProveedor : UserControl
    {
        SupplierImpl implSupplier;
        Suppliers supplier;
        sbyte option = -1;

        public uscProveedor()
        {
            InitializeComponent();
        }

        void LoadDataGrid()
        {
            try
            {
                implSupplier = new SupplierImpl();
                dgvDatos.ItemsSource = null;
                dgvDatos.ItemsSource = implSupplier.Select().DefaultView;
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
            txtName.IsEnabled = true;
            txtPhone.IsEnabled = true;
            txtName.Focus();
        }

        void DisabledButtons()
        {
            btnInsert.IsEnabled = true;
            btnUpdate.IsEnabled = true;
            btnDelete.IsEnabled = true;

            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
            txtPhone.IsEnabled = false;
            txtName.Text = "";
            txtPhone.Text = "";
            txtName.IsEnabled = false;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
            DisabledButtons();
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
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Delete(supplier);
                        if (res > 0)
                        {
                            MessageBox.Show("Se eliminó el registro de la Base de Datos");
                            LoadDataGrid();
                            txtName.Text = "";
                            txtPhone.Text = "";
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
                        supplier = new Suppliers(txtName.Text,txtPhone.Text, 3);
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Insert(supplier);
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
                        supplier.SupplierName = txtName.Text;
                        supplier.NumberPhone = txtPhone.Text;
                        implSupplier = new SupplierImpl();
                        int res = implSupplier.Update(supplier);
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

        private void dgvDatos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvDatos.Items.Count > 0 && dgvDatos.SelectedItem != null)
            {
                try
                {
                    DataRowView dataRow = (DataRowView)dgvDatos.SelectedItem;
                    byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                    implSupplier = new SupplierImpl();
                    supplier = implSupplier.Get(id);

                    txtName.Text = supplier.SupplierName;
                    txtPhone.Text = supplier.NumberPhone;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            btnCollapse.Visibility = Visibility.Collapsed;
            btnCollapseOpen.Visibility = Visibility.Visible;
            
            gridButtons.Visibility = Visibility.Visible;
        }

        private void btnCollapseOpen_Click(object sender, RoutedEventArgs e)
        {
            btnCollapse.Visibility = Visibility.Visible;
            btnCollapseOpen.Visibility = Visibility.Collapsed;
            
            gridButtons.Visibility = Visibility.Visible;
        }
    }
}
