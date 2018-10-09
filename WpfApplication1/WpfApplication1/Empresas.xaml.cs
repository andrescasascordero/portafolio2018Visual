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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Empresas.xaml
    /// </summary>
    public partial class Empresas : Window
    {
        OracleConnection con = null;

        public Empresas()
        {   

            InitializeComponent();
        }

        private void setConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["conectar"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception exp)
            {

                throw;
            }
        }
        private void actualizarGrilla() {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "Select ID_EMPRESA, NOMBRE, RAZON_SOCIAL from EMPRESA order by ID_EMPRESA ASC";
            cmd.CommandType = CommandType.Text;
            OracleDataReader odr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(odr);
            dtgEmpresa.ItemsSource = dt.DefaultView;
            odr.Close();

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            con.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.actualizarGrilla();
        }
    }
}
