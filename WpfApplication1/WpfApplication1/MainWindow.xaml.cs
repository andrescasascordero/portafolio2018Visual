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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.DataAccess.Client;
using Negocio;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.contrasena = txtPassword.Password;
            usuarios.correo = tXtUser.Text;

            try
            {
                var resultado = usuarios.getLogin(usuarios);
                if(resultado == "Administrador") {
                    MessageBox.Show("Dirigiendo a la pantalla principal");
                    Mantenedores mantenedores = new Mantenedores();
                    this.Close();
                    mantenedores.ShowDialog();
                    
                }
                else {
                    MessageBox.Show("No posee los privilegios necesarios para acceder a este sistema: ingrese desde la página web.");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Usuario o contraseña incorrecta"); 
            }
        }
    }
}
