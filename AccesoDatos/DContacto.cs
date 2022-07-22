using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using Entidad;
using System.Data;

namespace AccesoDatos
{
    public class DContacto
    {
        SqlConnection miConexion = new SqlConnection(ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString);

        public DataTable  ListContacto(int nId)
        {
            DataTable dtDato = new DataTable();
            
            SqlCommand cmd = new SqlCommand("ListarContactos", miConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            miConexion.Open();
            cmd.Parameters.AddWithValue("@IdConctacto", nId);
            SqlDataAdapter oAdaptador = new SqlDataAdapter(cmd);
            oAdaptador.Fill(dtDato);           
            miConexion.Close();
            

            return dtDato;
        }
        public void AddContacto(EContacto oContacto)
        {
            SqlCommand cmd = new SqlCommand("AddContactos", miConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            miConexion.Open();
            cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", oContacto.Apellido);
            cmd.Parameters.AddWithValue("@FechaNac", oContacto.FechaNac);
            cmd.Parameters.AddWithValue("@Direccion", oContacto.Direccion);
            cmd.Parameters.AddWithValue("@Genero", oContacto.Genero);
            cmd.Parameters.AddWithValue("@EstadoCivil", oContacto.EstadoCivil);
            cmd.Parameters.AddWithValue("@Celular", oContacto.Celular);
            cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
            cmd.Parameters.AddWithValue("@Email", oContacto.Email);
            cmd.ExecuteNonQuery();
            miConexion.Close();


        }
        public void EditContacto(EContacto oContacto)
        {
            SqlCommand cmd = new SqlCommand("EditContactos", miConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            miConexion.Open();
            cmd.Parameters.AddWithValue("@IdContacto", oContacto.IdContacto);
            cmd.Parameters.AddWithValue("@Nombre", oContacto.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", oContacto.Apellido);
            cmd.Parameters.AddWithValue("@FechaNac", oContacto.FechaNac);
            cmd.Parameters.AddWithValue("@Direccion", oContacto.Direccion);
            cmd.Parameters.AddWithValue("@Genero", oContacto.Genero);
            cmd.Parameters.AddWithValue("@EstadoCivil", oContacto.EstadoCivil);
            cmd.Parameters.AddWithValue("@Celular", oContacto.Celular);
            cmd.Parameters.AddWithValue("@Telefono", oContacto.Telefono);
            cmd.Parameters.AddWithValue("@Email", oContacto.Email);
            cmd.ExecuteNonQuery();
            miConexion.Close();
        }
        public void DeletContacto(int nId)
        {
            SqlCommand cmd = new SqlCommand("DeleteContactos", miConexion);
            cmd.CommandType = CommandType.StoredProcedure;
            miConexion.Open();
            cmd.Parameters.AddWithValue("@IdContacto", nId);
            cmd.ExecuteNonQuery();
            miConexion.Close();
        }

    }
}
