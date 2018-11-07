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
using System.Security.Cryptography;


namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        public Usuario()
        {
            InitializeComponent();
            actualizarGrilla();

            
        }
        private void actualizarGrilla()
        {
            Negocio.Usuarios us = new Usuarios();
            var list = us.getUsuario();

            dtgUsuario.ItemsSource = list;

        }

        private void dtgUsuario_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxRol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxRol_Loaded(object sender, RoutedEventArgs e)
        {

            RolUsuario rol = new RolUsuario();
            List<RolUsuario> lista = new List<RolUsuario>();
            var roles = rol.getRol();
            lista = roles;

            cbxRol.SelectedValuePath = "idRolUsuario";
            cbxRol.ItemsSource = lista;


        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.nombres = txtNombres.Text;
            usuarios.apellidoPaterno = txtApellidoP.Text;
            usuarios.apellidoMaterno = txtApellidoM.Text;
            usuarios.correo = txtCorreo.Text;
            usuarios.contrasena = passwordBox.Password;
            usuarios.rut = txtRut.Text;
            usuarios.estado = cbxEstado.SelectionBoxItem.ToString();
            usuarios.fecha =  DateTime.Now;
            usuarios.rolUsuarioFk = (cbxRol.SelectedValue.ToString()); 



            usuarios.insertarUsuarios(usuarios);
            actualizarGrilla();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.actualizarGrilla();
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.idUsuario = Int32.Parse(txtId.Text);
            usuario.nombres = txtNombres.Text;
            usuario.apellidoPaterno = txtApellidoP.Text;
            usuario.apellidoMaterno = txtApellidoM.Text;
            usuario.correo = txtCorreo.Text;
            usuario.rut = txtRut.Text;
            usuario.estado = cbxEstado.SelectionBoxItem.ToString();
            usuario.rolUsuarioFk = (cbxRol.SelectedValue.ToString());
            usuario.contrasena = passwordBox.Password;

            usuario.editarUsuario(usuario);
            actualizarGrilla();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (chkEliminar.IsChecked ?? true)
            {
                Usuarios usuario = new Usuarios();
                usuario.idUsuario = Int32.Parse(txtId.Text);
                usuario.eliminarPermanenteUsuario(usuario);
            }
            else
            {
                Usuarios usuario = new Usuarios(); ;
                usuario.idUsuario = Int32.Parse(txtId.Text);
                usuario.eliminarUsuario(usuario);
            }

            actualizarGrilla();
        }

        private void chkEliminar_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Esta acción no se podrá deshacer, seleccione eliminar para continuar");
        }

    }
}
