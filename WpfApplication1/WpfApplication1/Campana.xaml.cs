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
    /// Lógica de interacción para Campana.xaml
    /// </summary>
    public partial class Campana : Window
    {
        public Campana()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (chkEliminar.IsChecked ?? true)
                {
                    Negocio.Campana campana = new Negocio.Campana();
                    campana.idCampana = Int32.Parse(txtID.Text);
                    campana.eliminarPermanenteCampana(campana);
                }
                else
                {
                    Negocio.Campana campana = new Negocio.Campana();
                    campana.idCampana = Int32.Parse(txtID.Text);
                    campana.eliminarCampana(campana);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Seleccione una campaña para eliminar");
            }
            try
            {
                actualizarGrilla();
            }
            catch (Exception)
            {

                MessageBox.Show("Compruebe su conexión a internet");
            }

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rich = new TextRange(rtDescripcion.Document.ContentStart, rtDescripcion.Document.ContentEnd).Text;
                Negocio.Campana campana = new Negocio.Campana();
                campana.nombre = txtNombre.Text;
                campana.descripcion = rich;
                campana.fechaInicio = dpInicio.SelectedDate.Value;
                campana.fechaFin = dpFin.SelectedDate.Value;
                campana.fecha = DateTime.Now;
                campana.estado = cbxEstado.SelectionBoxItem.ToString();
                campana.usuarioFk = cbxDueno.SelectedValue.ToString();
                campana.tiendaFk = cbxTienda.SelectedValue.ToString();

                campana.insertarCampana(campana);
                new TextRange(rtDescripcion.Document.ContentStart, rtDescripcion.Document.ContentEnd).Text = null;
                
            }
            catch (Exception)
            {

                MessageBox.Show("Rellene todos los campos para agregar una campaña");
            }

            try
            {
                actualizarGrilla();
            }
            catch (Exception)
            {

                MessageBox.Show("Compruebe su conexión a internet");
            }
        }

        private void chkEliminar_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esta acción no se podrá deshacer, seleccione eliminar para continuar");

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                actualizarGrilla();
            }
            catch (Exception)
            {

                MessageBox.Show("Compruebe su conexión a internet");
            }
        }

        private void actualizarGrilla()
        {
            Negocio.Campana us = new Negocio.Campana();
            var list = us.getCampana();

            dtgCampana.ItemsSource = list;

        }

        private void cbxDueno_Loaded(object sender, RoutedEventArgs e)
        {
            Usuarios us = new Usuarios();
            List<Usuarios> lista = new List<Usuarios>();
            var usuarios = us.getUsuario();
            lista = usuarios;
            cbxDueno.SelectedValuePath = "idUsuario";
            cbxDueno.ItemsSource = lista;
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rich = new TextRange(rtDescripcion.Document.ContentStart, rtDescripcion.Document.ContentEnd).Text;

                Negocio.Campana campana = new Negocio.Campana();
                campana.idCampana = Int32.Parse(txtID.Text);
                campana.nombre = txtNombre.Text;
                campana.descripcion = rich;
                campana.fechaInicio = dpInicio.SelectedDate.Value;
                campana.fechaFin = dpFin.SelectedDate.Value;
                campana.fecha = DateTime.Now;
                campana.estado = cbxEstado.SelectionBoxItem.ToString();
                campana.usuarioFk = cbxDueno.SelectedValue.ToString();
                campana.tiendaFk = cbxTienda.SelectedValue.ToString();

                campana.editarCampana(campana);
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione una campaña y rellene sus campos");
            }

            try
            {
                actualizarGrilla();
            }
            catch (Exception)
            {

                MessageBox.Show("Compruebe su conexión a internet");
            }

        }

        private void cbxDueno_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxTienda_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.Tienda us = new Tienda();
            List<Tienda> lista = new List<Tienda>();
            var Tiendas = us.getTienda();
            lista = Tiendas;
            cbxTienda.SelectedValuePath = "idTienda";
            cbxTienda.ItemsSource = lista;
        }
    }
}
