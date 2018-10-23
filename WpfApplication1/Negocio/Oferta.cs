﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using DALC;
using System.Reflection;

namespace Negocio
{
    public class Oferta
    {
        public decimal idOferta { get; set; }
        public decimal cantidadMinima{ get; set; }
        public decimal cantidadMaxima { get; set; }
        public decimal precioNormal { get; set; }
        public decimal precioOferta { get; set; }
        public string imagen { get; set; }
        public DateTime fecha { get; set; }
        public decimal campanaFk { get; set; }
        public decimal productoFk { get; set; }

        public Oferta()
        {

        }
        public Oferta(decimal cantidadMinima, decimal cantidadMaxima, decimal precioNormal, decimal precioOferta, string imagen, DateTime fecha, decimal campanaFk, decimal productoFk)
        {
            this.idOferta = idOferta;
            this.cantidadMinima = cantidadMinima;
            this.cantidadMaxima = cantidadMaxima;
            this.precioNormal = precioNormal;
            this.precioOferta = precioOferta;
            this.imagen = imagen;
            this.fecha = fecha;
            this.campanaFk = campanaFk;
            this.productoFk = productoFk; 
        }

        public List<Oferta> getOferta()
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "selectOferta";
            OracleParameter parametro1 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.RefCursor;
            parametro1.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(parametro1);
            cmd.ExecuteNonQuery();
            OracleRefCursor cursor = (OracleRefCursor)parametro1.Value;
            OracleDataReader dr = cursor.GetDataReader();
            FieldInfo fi = dr.GetType().GetField("m_rowSize", BindingFlags.Instance | BindingFlags.NonPublic);
            int rowsize = Convert.ToInt32(fi.GetValue(dr));
            dr.FetchSize = rowsize * 100;

            List<Oferta> listaOferta= new List<Oferta>();
            while (dr.Read())
            {
                Oferta objOferta = new Oferta();
                objOferta.idOferta= Convert.ToInt32(dr["id_oferta"]);
                objOferta.cantidadMinima = Convert.ToInt32(dr["cantidad_minima"]);
                objOferta.cantidadMaxima = Convert.ToInt32(dr["cantidad_maxima"]);
                objOferta.precioNormal = Convert.ToInt32(dr["precio_normal"]);
                objOferta.precioOferta = Convert.ToInt32(dr["precio_oferta"]);
                objOferta.imagen = dr["marca"].ToString();
                objOferta.fecha = Convert.ToDateTime(dr["fecha"]); 
                objOferta.campanaFk = Convert.ToInt32(dr["campana_fk"]);
                objOferta.productoFk = Convert.ToInt32(dr["producto_fk"]);

                listaOferta.Add(objOferta);
            }
            cn.Close();
            parametro1.Dispose();
            cmd.Dispose();
            cn.Dispose();
            con = null;
            return listaOferta;

        }

        public void insertarOferta(Oferta pOferta)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertOferta";
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            OracleParameter parametro7 = new OracleParameter();
            OracleParameter parametro8 = new OracleParameter();
            parametro1.OracleDbType = OracleDbType.Int32;
            parametro1.Value = pOferta.cantidadMinima;
            parametro2.OracleDbType = OracleDbType.Int32;
            parametro2.Value = pOferta.cantidadMaxima;
            parametro3.OracleDbType = OracleDbType.Int32;
            parametro3.Value = pOferta.precioNormal;
            parametro4.OracleDbType = OracleDbType.Int32;
            parametro4.Value = pOferta.precioOferta;
            parametro5.OracleDbType = OracleDbType.Clob;
            parametro5.Value = pOferta.imagen;
            parametro6.OracleDbType = OracleDbType.Date;
            parametro6.Value = pOferta.fecha;
            parametro7.OracleDbType = OracleDbType.Int32;
            parametro7.Value = pOferta.campanaFk;
            parametro8.OracleDbType = OracleDbType.Int32;
            parametro8.Value = pOferta.productoFk;
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.Parameters.Add(parametro6);
            cmd.Parameters.Add(parametro7);
            cmd.Parameters.Add(parametro8);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro5.Dispose();
            parametro6.Dispose();
            parametro7.Dispose();
            parametro8.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

        public void editarOferta(Oferta pOferta)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "updateOferta";
            OracleParameter parametro0 = new OracleParameter();
            OracleParameter parametro1 = new OracleParameter();
            OracleParameter parametro2 = new OracleParameter();
            OracleParameter parametro3 = new OracleParameter();
            OracleParameter parametro4 = new OracleParameter();
            OracleParameter parametro5 = new OracleParameter();
            OracleParameter parametro6 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pOferta.idOferta;
            parametro1.OracleDbType = OracleDbType.Int32;
            parametro1.Value = pOferta.cantidadMinima;
            parametro2.OracleDbType = OracleDbType.Int32;
            parametro2.Value = pOferta.cantidadMaxima;
            parametro3.OracleDbType = OracleDbType.Int32;
            parametro3.Value = pOferta.precioNormal;
            parametro4.OracleDbType = OracleDbType.Int32;
            parametro4.Value = pOferta.precioOferta;
            parametro5.OracleDbType = OracleDbType.Clob;
            parametro5.Value = pOferta.imagen;
            parametro6.OracleDbType = OracleDbType.Date;
            parametro6.Value = pOferta.fecha;
            cmd.Parameters.Add(parametro0);
            cmd.Parameters.Add(parametro1);
            cmd.Parameters.Add(parametro2);
            cmd.Parameters.Add(parametro3);
            cmd.Parameters.Add(parametro4);
            cmd.Parameters.Add(parametro5);
            cmd.Parameters.Add(parametro6);

            cn.Close();
            parametro0.Dispose();
            parametro1.Dispose();
            parametro2.Dispose();
            parametro3.Dispose();
            parametro4.Dispose();
            parametro6.Dispose();


            cmd.Dispose();
            cn.Dispose();
            con = null;
        }


        public void eliminarProducto(Oferta pOferta)
        {
            Conexion con = new Conexion();
            OracleConnection cn = con.getConexion();
            cn.Open();
            OracleCommand cmd = cn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "deleteOferta";
            OracleParameter parametro0 = new OracleParameter();
            parametro0.OracleDbType = OracleDbType.Decimal;
            parametro0.Value = pOferta.idOferta;
            cmd.Parameters.Add(parametro0);
            cmd.ExecuteNonQuery();

            cn.Close();
            parametro0.Dispose();

            cmd.Dispose();
            cn.Dispose();
            con = null;
        }

    }

}
