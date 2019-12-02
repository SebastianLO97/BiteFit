using BiteFit.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BiteFit.Data
{
    public class RegisterUser
    {
        public void RegisterUsers(User user)
        {
            var idDireccion = RegisterDireccion(user);
            var idPersona = RegisterPersona(user, idDireccion);
            RegisterUsuario(user, idPersona);
        }
        public int RegisterDireccion(User user)
        {
            int idDireccion = 0;
            SqlHelper sqlHelper = new SqlHelper();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarDireccionUsuario", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pais", user.pais);
                cmd.Parameters.AddWithValue("@estado", user.estado);
                cmd.Parameters.AddWithValue("@municipio", user.municipio);
                cmd.Parameters.AddWithValue("@fraccionamiento", user.fraccionamiento);
                cmd.Parameters.AddWithValue("@calle", user.calle);
                cmd.Parameters.AddWithValue("@numeroExterior", SqlDbType.Int).Value = user.numeroExterior;
                cmd.Parameters.AddWithValue("@numeroInterior", SqlDbType.Int).Value = user.numeroInterior;
                cmd.Parameters.AddWithValue("@cp", SqlDbType.Int).Value = user.cp;
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select Top 1 id From Direccion Order By id Desc;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        idDireccion = Convert.ToInt16(dr["id"]);
                    }
                }
            }
            return idDireccion;
        }
        public int RegisterPersona(User user, int idDireccion)
        {
            int idPersona = 0;
            SqlHelper sqlHelper = new SqlHelper();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarPersonaUsuario", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre", user.nombre);
                cmd.Parameters.AddWithValue("@apellidoPat", user.apellidoPat);
                cmd.Parameters.AddWithValue("@apellidoMat", user.apellidoMat);
                cmd.Parameters.AddWithValue("@fechaNacimiento", SqlDbType.Date).Value = user.fechaNacimiento;
                cmd.Parameters.AddWithValue("@genero", SqlDbType.Bit).Value = user.genero;
                cmd.Parameters.AddWithValue("@idDireccion", SqlDbType.Int).Value = idDireccion;
                cmd.ExecuteNonQuery();
            }
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("Select Top 1 id From Persona Order By id Desc;", connection);
                connection.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        idPersona = Convert.ToInt16(dr["id"]);
                    }
                }
            }
            return idPersona;
        }
        public void RegisterUsuario(User user, int idPersona)
        {
            SqlHelper sqlHelper = new SqlHelper();
            using (SqlConnection connection = new SqlConnection(sqlHelper.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarUsuario", connection);
                connection.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@username", user.username);
                cmd.Parameters.AddWithValue("@passwordUsuario", user.password);
                cmd.Parameters.AddWithValue("@idPersona", SqlDbType.Int).Value = idPersona;
                cmd.ExecuteNonQuery();
            }
        }
    }
}
