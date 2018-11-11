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
    /// Lógica de interacción para Producto.xaml
    /// </summary>
    public partial class Producto : Window
    {
        public Producto()
        {
            InitializeComponent();
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

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string rich = new TextRange(rtbDescripcion.Document.ContentStart, rtbDescripcion.Document.ContentEnd).Text;
                Negocio.Producto producto = new Negocio.Producto();
                producto.nombre = txtNombre.Text;
                producto.descripcion = rich;
                producto.color = txtColor.Text;
                producto.perecible = cbxPerecible.SelectionBoxItem.ToString();
                producto.marca = txtMarca.Text;
                producto.rubroFk = cbxRubro.SelectedValue.ToString();

                producto.insertarProducto(producto);
            }
            catch (Exception)
            {

                MessageBox.Show("Rellene todos los campos para agregar un producto");
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
                string rich = new TextRange(rtbDescripcion.Document.ContentStart, rtbDescripcion.Document.ContentEnd).Text;

                Negocio.Producto producto = new Negocio.Producto();
                producto.idProducto = Int32.Parse(txtID.Text);
                producto.nombre = txtNombre.Text;
                producto.descripcion = rich;
                producto.color = txtColor.Text;
                producto.perecible = cbxPerecible.SelectionBoxItem.ToString();
                producto.marca = txtMarca.Text;

                producto.editarProducto(producto);
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un producto y rellene los campos que desea editar");
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
                Negocio.Producto producto = new Negocio.Producto();
                producto.idProducto = Int32.Parse(txtID.Text);
                producto.eliminarProducto(producto);
            }
            catch (Exception)
            {

                MessageBox.Show("Debe elegir un producto desde la grilla para eliminar");
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

        private void cbxRubro_Loaded(object sender, RoutedEventArgs e)
        {
            Rubro us = new Rubro();
            List<Rubro> lista = new List<Rubro>();
            var rubros = us.getRubro();
            lista = rubros;
            cbxRubro.SelectedValuePath = "idRubro";
            cbxRubro.ItemsSource = lista;
        }

        private void actualizarGrilla()
        {
            Negocio.Producto us = new Negocio.Producto();
            var list = us.getProducto();

            dtgProducto.ItemsSource = list;

        }
    }
}
