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
using System.Windows.Shapes;
using System.Data;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Configuration;
using Negocio;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Empresas.xaml
    /// </summary>
    public partial class Empresas : Window
    {
        //OracleConnection con = null;

        public Empresas()
        {   

            InitializeComponent();
        }

        //private void setConnection()
        //{
        //    String connectionString = ConfigurationManager.ConnectionStrings["conectar"].ConnectionString;
        //    con = new OracleConnection(connectionString);
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (Exception exp)
        //    {

        //        throw;
        //    }
        //}
        private void actualizarGrilla() {
            Negocio.Empresa emp = new Empresa();
            var list = emp.getEmpresa();

            dtgEmpresa.ItemsSource = list; 

        }

        private void Window_Closed(object sender, EventArgs e)
        {
        
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.actualizarGrilla();
        }

        private void txtBNombre_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dtgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btnInsertar_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.nombre = txtBNombre.Text;
            empresa.razonSocial = txtBRazonSocial.Text;
            empresa.estado = cbxEstado.SelectionBoxItem.ToString();
            empresa.rut = txtBRut.Text;

            empresa.insertarEmpresa(empresa);
            actualizarGrilla();
        }

        private void dtgEmpresa_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e){}

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Empresa empresa = new Empresa();
            empresa.idEmpresa = Int32.Parse(txtBId.Text);
            empresa.nombre = txtBNombre.Text;
            empresa.razonSocial = txtBRazonSocial.Text;
            empresa.estado = cbxEstado.SelectionBoxItem.ToString();
            empresa.rut = txtBRut.Text;

            empresa.editarEmpresa(empresa);
            actualizarGrilla();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked ?? true)
            {
                Empresa empresa = new Empresa();
                empresa.idEmpresa = Int32.Parse(txtBId.Text);
                empresa.nombre = txtBNombre.Text;
                empresa.razonSocial = txtBRazonSocial.Text;
                empresa.estado = cbxEstado.SelectionBoxItem.ToString();
                empresa.rut = txtBRut.Text;
                empresa.eliminarPermanenteEmpresa(empresa);
            }
            else
            {
                Empresa empresa = new Empresa();
                empresa.idEmpresa = Int32.Parse(txtBId.Text);
                empresa.nombre = txtBNombre.Text;
                empresa.razonSocial = txtBRazonSocial.Text;
                empresa.estado = cbxEstado.SelectionBoxItem.ToString();
                empresa.rut = txtBRut.Text;
                empresa.eliminarEmpresa(empresa);
            }

            actualizarGrilla();
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esta acción no se podrá deshacer, seleccione eliminar para continuar");
        }
    }
}
