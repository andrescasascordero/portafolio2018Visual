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
    /// Lógica de interacción para Rubros.xaml
    /// </summary>
    public partial class Rubros : Window
    {
        public Rubros()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rubro rubro = new Rubro();
                rubro.nombreRubro = txtNombre.Text;
                rubro.insertarRubro(rubro);
            }
            catch (Exception)
            {

                MessageBox.Show("Debe rellenar todos los campos para agregar una tienda");
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

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rubro rubro = new Rubro();
                rubro.idRubro = Int32.Parse(txtID.Text);
                rubro.nombreRubro = txtNombre.Text;

                rubro.editarRubro(rubro);
            }
            catch (Exception)
            {

                MessageBox.Show("Selecione un rubro y rellene los campos a editar");
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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Rubro rubro = new Rubro();
                rubro.idRubro = Int32.Parse(txtID.Text);

                rubro.eliminarPermanenteRubro(rubro);
            }
            catch (Exception)
            {

                MessageBox.Show("No ha seleccionado ningún rubro o este se encuentra siendo usado por algún producto");
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
            Rubro rubro = new Rubro();
            var list = rubro.getRubro();

            dtgRubro.ItemsSource = list;
        }
    }
}
