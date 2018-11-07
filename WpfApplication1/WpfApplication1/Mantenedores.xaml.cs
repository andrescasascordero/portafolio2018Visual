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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Mantenedores.xaml
    /// </summary>
    public partial class Mantenedores : Window
    {
        public Mantenedores()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Campana campana = new Campana();
            campana.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Producto productos = new Producto();
            productos.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Empresas empresas = new Empresas();
            empresas.ShowDialog();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Tiendas tiendas = new Tiendas();
            tiendas.ShowDialog();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuarios = new Usuario();
            usuarios.ShowDialog();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            Tramos tramos = new Tramos();
            tramos.ShowDialog();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Rubros rubro = new Rubros();
            rubro.ShowDialog();
        }

        private void button7_Click(object sender, RoutedEventArgs e)
        {
            Oferta oferta = new Oferta();
            oferta.ShowDialog();
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            try
            {
                Negocio.Oferta us = new Negocio.Oferta();
                var list = us.getOferta();
                Negocio.Campana campanas = new Negocio.Campana();
                var list2 = campanas.getCampana();
                Negocio.Tienda users = new Negocio.Tienda();
                var list3 = users.getTienda();
                dataGrid.ItemsSource = list;
                dataGrid1.ItemsSource = list2;
                dataGrid1_Copy.ItemsSource = list3;
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar datos, compruebe su conexión a internet y vuelva a iniciar la aplicación");
            }



        }

        private void dataGrid1_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid1_Copy_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
