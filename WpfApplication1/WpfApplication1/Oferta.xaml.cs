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
using System.IO;
using System.Net;
using System.ComponentModel;
using Microsoft.Win32;
using Negocio;
using System.Text.RegularExpressions;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para Oferta.xaml
    /// </summary>
    public partial class Oferta : Window
    {
        byte[] imagen;
        BitmapDecoder bitCoder;
        Negocio.Oferta _oferta = new Negocio.Oferta();
        OpenFileDialog fd = new OpenFileDialog();

        public Oferta()
        {
            InitializeComponent();
        }

        private void btnExaminar_Click(object sender, RoutedEventArgs e)
        {
    
            fd.Filter = "Imagenes (*.jpg; *.png; *.jpeg)|*.jpg; *.png; *.jpeg|All Files(*.*)|*.*";
            if (fd.ShowDialog() == true)
            {
                using (Stream stream = fd.OpenFile())
                {
                    bitCoder = BitmapDecoder.Create(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
                    vtPrevia.Source = bitCoder.Frames[0];
                    txtImagen.Text = fd.FileName; 
                }
            }
            else
            {
                vtPrevia.Source = null;
            }
            System.IO.FileStream fs;

            fs = new System.IO.FileStream(txtImagen.Text, System.IO.FileMode.Open);
            imagen = new byte[Convert.ToInt32(fs.Length.ToString())];
            fs.Read(imagen, 0, imagen.Length);



        }

        private void dtgOferta_Loaded(object sender, RoutedEventArgs e)
        {
           actualizarGrilla();
        }

        private void actualizarGrilla()
        {
            Negocio.Oferta us = new Negocio.Oferta();
            var list = us.getOferta();
            dtgOferta.ItemsSource = list;          

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            Negocio.Oferta oferta = new Negocio.Oferta();
            oferta.cantidadMinima = int.Parse(txtCantMin.Text);
            oferta.cantidadMaxima = int.Parse(txtCantMax.Text);
            oferta.precioNormal = int.Parse(txtPrecioNormal.Text);
            oferta.precioOferta = int.Parse(txtPrecioOferta.Text);
            oferta.fecha = DateTime.Now;
            oferta.imagen = fd.SafeFileName;
            oferta.campanaFk = cbxCampana.SelectedValue.ToString();
            oferta.productoFk = cbxProducto.SelectedValue.ToString();

            string usuario = "usuarioftp";
            string pass = "Portafolio2018";
            string ftp = "ftp://18.222.173.173/";
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(ftp+"/"+ fd.SafeFileName);
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(usuario, pass);
            req.UseBinary = true;
            req.UsePassive = true;
            req.ContentLength = imagen.Length;
            Stream streams;
            streams = req.GetRequestStream();
            streams.Write(imagen, 0, imagen.Length);
            streams.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();

            oferta.insertarOferta(oferta);
            actualizarGrilla();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            Negocio.Oferta oferta = new Negocio.Oferta();
            oferta.cantidadMinima = int.Parse(txtCantMin.Text);
            oferta.cantidadMaxima = int.Parse(txtCantMax.Text);
            oferta.precioNormal = int.Parse(txtPrecioNormal.Text);
            oferta.precioOferta = int.Parse(txtPrecioOferta.Text);
            oferta.fecha = DateTime.Now;
            oferta.imagen = fd.SafeFileName;
            oferta.campanaFk = cbxCampana.SelectedValue.ToString();
            oferta.productoFk = cbxProducto.SelectedValue.ToString();

            string usuario = "usuarioftp";
            string pass = "Portafolio2018";
            string ftp = "ftp://18.222.173.173/";
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(ftp + "/" + fd.SafeFileName);
            req.Proxy = null;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential(usuario, pass);
            req.UseBinary = true;
            req.UsePassive = true;
            req.ContentLength = imagen.Length;
            Stream streams;
            streams = req.GetRequestStream();
            streams.Write(imagen, 0, imagen.Length);
            streams.Close();
            FtpWebResponse res = (FtpWebResponse)req.GetResponse();

            oferta.editarOferta(oferta);
            actualizarGrilla();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cbxCampana_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.Campana campana = new Negocio.Campana();
            List<Negocio.Campana> lista = new List<Negocio.Campana>();
            var campanas = campana.getCampana();
            lista = campanas;

            cbxCampana.SelectedValuePath = "idCampana";
            cbxCampana.ItemsSource = lista;
        }

        private void cbxProducto_Loaded(object sender, RoutedEventArgs e)
        {
            Negocio.Producto prod   = new Negocio.Producto();
            List<Negocio.Producto> lista = new List<Negocio.Producto>();
            var product = prod.getProducto();
            lista = product;

            cbxProducto.SelectedValuePath = "idProducto";
            cbxProducto.ItemsSource = lista;
        }

        private void dtgOferta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
