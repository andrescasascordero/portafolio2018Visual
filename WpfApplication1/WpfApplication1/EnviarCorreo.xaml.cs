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
    /// Lógica de interacción para EnviarCorreo.xaml
    /// </summary>
    public partial class EnviarCorreo : Window
    {
        public EnviarCorreo()
        {
            InitializeComponent();
            
        }

        private void btnEnviarCorreos_Click(object sender, RoutedEventArgs e)
        {
           // try
            //{
                Correos emp = new Negocio.Correos();
                var list = emp.getCorreos();
                emp.enviarCorreos(list);
            //}
            //catch (Exception)
            //{

              //  MessageBox.Show("Compruebe su conexión a internet");
            //}

        }
        private void actualizarGrilla()
        {
            Negocio.Correos emp = new Negocio.Correos();
            var list = emp.getCorreos();

            dtgMails.ItemsSource = list;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarGrilla();
        }
    }
}
