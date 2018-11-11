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
using System.ComponentModel;


namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Usuario.xaml
    /// </summary>
    public partial class Usuario : Window, IDataErrorInfo
    {
        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Usuario() 
        {
            InitializeComponent();
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
            try
            {
                Usuarios usuarios = new Usuarios();
                usuarios.nombres = txtNombres.Text;
                usuarios.apellidoPaterno = txtApellidoP.Text;
                usuarios.apellidoMaterno = txtApellidoM.Text;
                usuarios.correo = txtCorreo.Text;
                usuarios.contrasena = passwordBox.Password;
                usuarios.rut = txtRut.Text;
                usuarios.estado = cbxEstado.SelectionBoxItem.ToString();
                usuarios.fecha = DateTime.Now;
                usuarios.rolUsuarioFk = (cbxRol.SelectedValue.ToString());



                usuarios.insertarUsuarios(usuarios);
            }
            catch (Exception)
            {

                MessageBox.Show("Debe rellenar todos los campos para agregar un nuevo usuario");
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

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
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

                usuario.editarUsuario(usuario);
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un usuario y rellene los campos a editar");
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
            }
            catch (Exception)
            {

                MessageBox.Show("Seleccione un usuario para eliminar");
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

        private void btnContrasena_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Usuarios usuario = new Usuarios();
                usuario.idUsuario = Int32.Parse(txtId.Text);
                usuario.contrasena = passwordBox.Password;

                usuario.editarContrasena(usuario);
            }
            catch (Exception)
            {

                MessageBox.Show("Se debe seleccionar un usuario y la nueva contraseña");
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
    }
}
