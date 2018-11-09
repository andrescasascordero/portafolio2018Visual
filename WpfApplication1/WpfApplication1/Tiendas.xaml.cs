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
using Negocio;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Tiendas.xaml
    /// </summary>
    public partial class Tiendas : Window
    {
        public Tiendas()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarGrilla();
        }
    
    private void actualizarGrilla()
    {
        Negocio.Tienda ti = new Tienda();
        var list = ti.getTienda();
        dtgTienda.ItemsSource = list;

    }

    private void dtgUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void cbxRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    //private void btnAgregar_Click(object sender, RoutedEventArgs e)
    //{
    //    Tienda tienda = new Tienda();
    //    tienda.nombre = txtNombre.Text;
    //    tienda.direccion = txtDireccion.Text;
    //    tienda.estado = cbxEstado.SelectionBoxItem.ToString();
    //    tienda.empresaFk = int.Parse(cbxEmpresa.SelectedValue.ToString());
    //    tienda.usuarioFk= int.Parse(cbxAdministrador.SelectedValue.ToString());
    //    tienda.insertarTienda(tienda);
    //    actualizarGrilla();
    //}

    //private void btnActualizar_Click(object sender, RoutedEventArgs e)
    //{
    //    Tienda tienda= new Tienda();
    //    tienda.idTienda= Int32.Parse(txtIdTienda.Text);
    //    tienda.nombre = txtNombre.Text;
    //    tienda.estado = cbxEstado.SelectionBoxItem.ToString();

    //    tienda.editarTienda(tienda);
    //    actualizarGrilla();
    //}

    //private void btnEliminar_Click(object sender, RoutedEventArgs e)
    //{
    //    if (chkEliminar.IsChecked ?? true)
    //    {
    //        Tienda tienda = new Tienda();
    //        tienda.idTienda = Int32.Parse(txtIdTienda.Text);
    //        tienda.eliminarPermanenteTienda(tienda);
    //    }
    //    else
    //    {
    //        Tienda tienda = new Tienda(); ;
    //        tienda.idTienda= Int32.Parse(txtIdTienda.Text);
    //        tienda.eliminarTienda(tienda);
    //    }

    //    actualizarGrilla();
    //}

    //private void chkEliminar_Checked(object sender, RoutedEventArgs e)
    //{
    //    MessageBox.Show("Esta acción no se podrá deshacer, seleccione eliminar para continuar");
    //}

        private void cbxEmpresa_Loaded(object sender, RoutedEventArgs e)
        {
            Empresa emp = new Empresa();
            List<Empresa> lista = new List<Empresa>();
            var empresa = emp.getEmpresa();
            lista = empresa;

            cbxEmpresa.SelectedValuePath = "idEmpresa";
            cbxEmpresa.ItemsSource = lista;
        }

        private void cbxAdministrador_Loaded(object sender, RoutedEventArgs e)
        {
            Usuarios us = new Usuarios();
            List<Usuarios> lista = new List<Usuarios>();
            var usuarios = us.getUsuario();
            lista = usuarios;

            cbxAdministrador.SelectedValuePath = "idUsuario";
            cbxAdministrador.ItemsSource = lista;
        }

        private void btnAgregar_Click_1(object sender, RoutedEventArgs e)
        {
            Tienda tienda = new Tienda();
            tienda.nombre = txtNombre.Text;
            tienda.direccion = txtDireccion.Text;
            tienda.estado = cbxEstado.SelectionBoxItem.ToString();
            tienda.empresaFk = (cbxEmpresa.SelectedValue.ToString());
            tienda.usuarioFk = (cbxAdministrador.SelectedValue.ToString());
            tienda.insertarTienda(tienda);
            actualizarGrilla();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Tienda tienda = new Tienda();
            tienda.idTienda = Int32.Parse(txtIdTienda.Text);
            tienda.nombre = txtNombre.Text;
            tienda.direccion = txtDireccion.Text;
            tienda.estado = cbxEstado.SelectionBoxItem.ToString();
            tienda.empresaFk = cbxEmpresa.SelectedValue.ToString();
            tienda.usuarioFk = cbxAdministrador.SelectedValue.ToString();
            tienda.editarTienda(tienda);
            actualizarGrilla();
        }

        private void btnEliminar_Click_1(object sender, RoutedEventArgs e)
        {
            if (chkEliminar.IsChecked ?? true)
            {
                Tienda tienda = new Tienda();
                tienda.idTienda = Int32.Parse(txtIdTienda.Text);
                tienda.eliminarPermanenteTienda(tienda);
            }
            else
            {
                Tienda tienda = new Tienda(); ;
                tienda.idTienda = Int32.Parse(txtIdTienda.Text);
                tienda.eliminarTienda(tienda);
            }

            actualizarGrilla();
        }

        private void chkEliminar_Checked_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esta acción no se podrá deshacer, seleccione eliminar para continuar");
        }
    }
}
