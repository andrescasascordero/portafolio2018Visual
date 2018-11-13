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
            Rubro rubro = new Rubro();
            rubro.nombreRubro = txtNombre.Text;
            rubro.insertarRubro(rubro);
            actualizarGrilla();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Rubro rubro = new Rubro();
            rubro.idRubro = Int32.Parse(txtID.Text);
            rubro.nombreRubro = txtNombre.Text;

            rubro.editarRubro(rubro);
            actualizarGrilla();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Rubro rubro = new Rubro();
            rubro.idRubro = Int32.Parse(txtID.Text);

            rubro.eliminarPermanenteRubro(rubro);
            actualizarGrilla();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            Rubro rubro = new Rubro();
            var list = rubro.getRubro();

            dtgRubro.ItemsSource = list;
        }
    }
}
