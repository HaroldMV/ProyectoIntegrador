using ProyectoTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProyectoTest.Logica
{
    public class VentaLogica
    {
        private static VentaLogica _instancia = null;

        public static VentaLogica Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new VentaLogica();
                }

                return _instancia;
            }
        }


        public List<Ventas> Listar(int IDUsuario)
        {

            List<Ventas> rptListaVentas = new List<Ventas>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                SqlCommand cmd = new SqlCommand("SP_PRODUCTOS_VENTA_XUSUARIO", oConexion);
                cmd.Parameters.AddWithValue("IDUsuario", IDUsuario);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        rptListaVentas.Add(new Ventas()
                        {
                            ID_Compra=Convert.ToInt32(dr["IdCompra"].ToString()),
                            ID_Estado= Convert.ToInt32(dr["ID_Estado"].ToString()),
                            Comprador = dr["Comprador"].ToString(),
                            ProDesc = dr["ProDesc"].ToString(),
                            Total = Convert.ToDecimal(dr["Total"].ToString()),
                            Telefono=dr["Telefono"].ToString(),
                            Fecha=dr["FechaCompra"].ToString(),
                        });;
                    }
                    dr.Close();

                    return rptListaVentas;

                }
                catch (Exception ex)
                {
                    rptListaVentas = null;
                    return rptListaVentas;
                }
            }
        }

        public bool ActualizarEstado(int id,int estado)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Conexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("update Compra set ID_Estado=@Estado where IdCompra = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@Estado", estado);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }
    }
}