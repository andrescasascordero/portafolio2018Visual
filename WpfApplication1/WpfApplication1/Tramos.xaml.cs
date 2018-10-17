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
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Tramos.xaml
    /// </summary>
    public partial class Tramos : Window
    {
        public Tramos()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarGrilla();
        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Tramo tramo = new Tramo();
            tramo.minimo= Int32.Parse(txtMinimo.Text);
            tramo.maximo = Int32.Parse(txtMaximo.Text);
            tramo.insertarTramo(tramo);
            actualizarGrilla();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {

            Tramo tramo = new Tramo();
            tramo.idTramo = Int32.Parse(txtId.Text);
            tramo.minimo = Int32.Parse(txtMinimo.Text);
            tramo.maximo = Int32.Parse(txtMaximo.Text);
            tramo.editarTramo(tramo);
            actualizarGrilla();

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Tramo tramo = new Tramo();
            tramo.idTramo = Int32.Parse(txtId.Text);

            tramo.eliminarPermanenteTramo(tramo);
            actualizarGrilla();
        }
        private void actualizarGrilla()
        {
            Tramo tramo= new Tramo();
            var list = tramo.getTramo();

            dtgTramo.ItemsSource = list;

        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
